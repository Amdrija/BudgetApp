using System;

namespace BudgetApp.Requests
{
    public class ModifyExpenseAPIRequest
    {
        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string? Decription { get; set; }
    }
}