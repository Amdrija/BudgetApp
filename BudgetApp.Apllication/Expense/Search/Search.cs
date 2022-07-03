using System;
using System.Threading.Tasks;
using BudgetApp.Apllication.Expense.Interfaces;

namespace BudgetApp.Apllication.Expense.Search
{
    public class SearchUseCase : IUseCase<SearchRequest, SearchResponse>
    {
        private readonly IExpenseRepository repository;

        public SearchUseCase(IExpenseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SearchResponse> ExecuteAsync(SearchRequest request)
        {
            return new SearchResponse()
            {
                Expenses = await this.repository.GetAsync(request)
            };
        }
    }
}