using System;

namespace BudgetApp.Apllication.Expense.EditExpense
{
    public class EditExpenseRequest
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public string UserId { get; set; }
    }
}