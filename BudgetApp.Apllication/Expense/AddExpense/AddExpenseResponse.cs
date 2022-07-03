using System.Collections.Generic;

namespace BudgetApp.Apllication.Expense.AddExpense
{
    public class AddExpenseResponse
    {
        public List<Domain.Expense.Expense> Expenses { get; set; }
    }
}