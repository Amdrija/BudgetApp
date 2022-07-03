using System;

namespace BudgetApp.Domain.Expense
{
    public class Expense
    {
        public Guid Id { get; init; }

        public string Name { get; set; }

        public Category.Category Category { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string UserId { get; init; }
    }
}