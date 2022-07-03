using System.Collections.Generic;

namespace BudgetApp.Apllication.Expense.Search
{
    public class SearchResponse
    {
        public List<Domain.Expense.Expense> Expenses { get; set; }
    }
}