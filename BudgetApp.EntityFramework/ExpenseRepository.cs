using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Apllication.Category.Exception;
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
    }
}