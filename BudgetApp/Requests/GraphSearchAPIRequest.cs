using System;
using System.Collections.Generic;

namespace BudgetApp.Requests
{
    public class GraphSearchAPIRequest
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<Guid>? CategoryIds { get; set; }
    }
}