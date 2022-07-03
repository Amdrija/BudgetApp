using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Apllication.Category.Interfaces;
using BudgetApp.Apllication.Expense.Interfaces;

namespace BudgetApp.Apllication.Expense.GraphSearch
{
    public class GraphSearchUseCase : IUseCase<GraphSearchRequest, GraphSearchResponse>
    {
        private readonly IExpenseRepository repository;
        private readonly ICategoryRepository categoryRepository;

        public GraphSearchUseCase(IExpenseRepository repository, ICategoryRepository categoryRepository)
        {
            this.repository = repository;
            this.categoryRepository = categoryRepository;
        }

        public async Task<GraphSearchResponse> ExecuteAsync(GraphSearchRequest request)
        {
            List<Domain.Category.Category>? categories = request.CategoryIds == null ? 
                    await this.categoryRepository.GetAsync(request.UserId) :
                    await this.categoryRepository.GetByIdsAsync(request.UserId, request.CategoryIds);
            var amounts = await this.repository.GetAmountByCategory(
                request.UserId,
                request.StartDate,
                request.EndDate,
                request.CategoryIds);
            
            
            return new GraphSearchResponse()
            {
                TotalAmount = amounts.Select(a => a.Amount).Sum(),
                ByCategory = categories.Join(amounts,
                    c => c.Id,
                    graphSearch => graphSearch.CategoryId,
                    (category, graphSearch) => new GraphSearchByCategory()
                    {
                        Category = category,
                        Amount = graphSearch.Amount,
                    }).ToList()
            };
        }
    }
}