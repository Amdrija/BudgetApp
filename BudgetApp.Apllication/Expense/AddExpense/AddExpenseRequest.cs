using System;

namespace BudgetApp.Apllication.Expense.AddExpense
{
    public class AddExpenseRequest
    {
        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public string UserId { get; set; }
    }
}