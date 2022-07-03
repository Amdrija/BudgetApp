using System;
using System.Collections.Generic;

namespace BudgetApp.Apllication.Expense.Search
{
    public class SearchRequest
    {
        public string UserId { get; set; }
        
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<Guid>? CategoryIds { get; set; }

        public decimal? MinimumAmount { get; set; }

        public decimal? MaximumAmount { get; set; }
    }
}