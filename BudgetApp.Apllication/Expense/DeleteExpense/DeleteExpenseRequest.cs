using System;

namespace BudgetApp.Apllication.Expense.DeleteExpense
{
    public class DeleteExpenseRequest
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
    }
}