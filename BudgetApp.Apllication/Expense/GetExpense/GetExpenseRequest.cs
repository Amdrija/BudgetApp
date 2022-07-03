using System;

namespace BudgetApp.Apllication.Expense.GetExpense
{
    public class GetExpenseRequest
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
    }
}