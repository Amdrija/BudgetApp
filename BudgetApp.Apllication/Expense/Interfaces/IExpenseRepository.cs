using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.Apllication.Expense.GraphSearch;
using BudgetApp.Apllication.Expense.Search;

namespace BudgetApp.Apllication.Expense.Interfaces
{
    public interface IExpenseRepository
    {
        Task<Domain.Expense.Expense> GetOneAsync(Guid id, string userId);
        
        Task<List<Domain.Expense.Expense>> AddExpensesAsync(List<Domain.Expense.Expense> expenses);

        Task<Domain.Expense.Expense> EditExpenseAsync(Domain.Expense.Expense expense);

        Task DeleteExpenseAsync(Domain.Expense.Expense expense);

        Task<decimal> GetTotalAmount(string userId, DateTime? startDate, DateTime? endDate);

        Task<List<GraphSearchByCategoryId>> GetAmountByCategory(string userId, DateTime? startDate, DateTime? endDate, List<Guid>? categoryIds);

        Task<List<Domain.Expense.Expense>> GetAsync(SearchRequest request);
    }
}