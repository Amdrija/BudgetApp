using System;
using System.Collections.Generic;

namespace BudgetApp.Requests
{
    public class SearchAPIRequest
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<Guid>? CategoryIds { get; set; }

        public decimal? MinimumAmount { get; set; }

        public decimal? MaximumAmount { get; set; }
    }
}