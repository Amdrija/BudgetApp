using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetApp.Apllication.Expense.Interfaces
{
    public interface IExpenseRepository
    {
        Task<List<Domain.Expense.Expense>> AddExpensesAsync(List<Domain.Expense.Expense> expenses);
    }
}