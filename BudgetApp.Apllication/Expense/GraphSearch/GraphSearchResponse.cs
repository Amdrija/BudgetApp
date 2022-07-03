using System;
using System.Collections.Generic;

namespace BudgetApp.Apllication.Expense.GraphSearch
{
    public class GraphSearchResponse
    {
        public decimal TotalAmount { get; set; }
        
        public List<GraphSearchByCategory> ByCategory { get; set; }
    }

    public class GraphSearchByCategory
    {
        public Domain.Category.Category Category { get; set; }

        public decimal Amount { get; set; }
    }

    public class GraphSearchByCategoryId
    {
        public Guid CategoryId { get; set; }

        public decimal Amount { get; set; }
    }
}