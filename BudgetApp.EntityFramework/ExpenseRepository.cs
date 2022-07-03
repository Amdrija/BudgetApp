using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Xml;
using BudgetApp.Apllication.Category.Exception;
using BudgetApp.Apllication.Expense.Exceptions;
using BudgetApp.Apllication.Expense.Interfaces;
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
    }
}