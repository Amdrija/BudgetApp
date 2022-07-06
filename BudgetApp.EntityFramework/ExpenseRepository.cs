using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Xml;
using BudgetApp.Apllication.Category.Exception;
using BudgetApp.Apllication.Expense.Exceptions;
using BudgetApp.Apllication.Expense.GraphSearch;
using BudgetApp.Apllication.Expense.Interfaces;
using BudgetApp.Apllication.Expense.Search;
using BudgetApp.Domain.Expense;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BudgetApp.EntityFramework
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly BudgetAppContext dbContext;

        public ExpenseRepository(BudgetAppContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Expense> GetOneAsync(Guid id, string userId)
        {
            var expense = await this.dbContext.Expenses.Where(e => e.Id == id && e.UserId == userId)
                                    .Include(e => e.Category)
                                    .FirstOrDefaultAsync();

            if (expense == null)
            {
                throw new ExpenseNotFoundException(id, userId);
            }

            return expense;
        }

        public async Task<List<Expense>> AddExpensesAsync(List<Expense> expenses)
        {
            await this.dbContext.AddRangeAsync(expenses);

            try
            {
                await this.dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException e) when (e.InnerException is PostgresException { SqlState: "23503" })
            {
                throw new CategoryNotFoundException(Guid.Empty, expenses.First().UserId);
            }

            return expenses;
        }

        public async Task<Expense> EditExpenseAsync(Expense expense)
        {
            this.dbContext.Update(expense);

            try
            {
                await this.dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException e) when (e.InnerException is PostgresException { SqlState: "23503" })
            {
                throw new CategoryNotFoundException(expense.CategoryId, expense.UserId);
            }

            return expense;
        }

        public async Task DeleteExpenseAsync(Expense expense)
        {
            this.dbContext.Remove(expense);

            try
            {
                await this.dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new ExpenseNotFoundException(expense.Id, expense.UserId);
            }
        }

        public Task<decimal> GetTotalAmount(string userId, DateTime? startDate, DateTime? endDate)
        {
            return this.FilterByDate(startDate, endDate)
                       .Where(expense => expense.UserId == userId)
                       .SumAsync(e => e.Amount);
        }

        public Task<List<GraphSearchByCategoryId>> GetAmountByCategory(
            string userId,
            DateTime? startDate,
            DateTime? endDate,
            List<Guid>? categoryIds)
        {
            return this.FilterByDate(startDate, endDate)
                       .Where(expense => expense.UserId == userId)
                       .Where(expense => categoryIds == null || categoryIds.Contains(expense.CategoryId))
                       .GroupBy(e => e.CategoryId)
                       .Select(g => new GraphSearchByCategoryId()
                       {
                           CategoryId = g.Key,
                           Amount = g.Sum(x => x.Amount)
                       })
                       .ToListAsync();
        }

        public Task<List<Expense>> GetAsync(SearchRequest request)
        {
            var query = this.FilterByDate(request.StartDate, request.EndDate)
                            .Where(e => e.UserId == request.UserId);

            if (request.CategoryIds != null)
            {
                query = query.Where(e => request.CategoryIds.Contains(e.CategoryId));
            }

            if (request.MinimumAmount != null)
            {
                query = query.Where(e => e.Amount >= request.MinimumAmount);
            }

            if (request.MaximumAmount != null)
            {
                query = query.Where(e => e.Amount <= request.MaximumAmount);
            }

            return query.Include(e => e.Category).OrderByDescending(e => e.Date).ToListAsync();
        }

        private IQueryable<Expense> FilterByDate(DateTime? startDate, DateTime? endDate)
        {
            var query = this.dbContext.Expenses.AsQueryable();
            if (startDate != null)
            {
                query = query.Where(e => e.Date >= startDate);
            }

            if (endDate != null)
            {
                query = query.Where(e => e.Date <= endDate);
            }

            return query;
        }
    }
}