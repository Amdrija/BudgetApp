using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetApp.Apllication.Expense.Interfaces
{
    public interface IExpenseRepository
    {
        Task<Domain.Expense.Expense> GetOneAsync(Guid id, string userId);
        
        Task<List<Domain.Expense.Expense>> AddExpensesAsync(List<Domain.Expense.Expense> expenses);

        Task<Domain.Expense.Expense> EditExpenseAsync(Domain.Expense.Expense expense);
    }
}