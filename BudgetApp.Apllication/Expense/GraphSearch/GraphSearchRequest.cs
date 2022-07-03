using System;
using System.Collections.Generic;

namespace BudgetApp.Apllication.Expense.GraphSearch
{
    public class GraphSearchRequest
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<Guid>? CategoryIds { get; set; }

        public string UserId { get; set; }
    }
}