using System;
using System.Threading.Tasks;
using BudgetApp.Apllication.Category.Interfaces;

namespace BudgetApp.Apllication.Category.GetCategories
{
    public class GetCategoriesUseCase : IUseCase<GetCategoriesRequest, GetCategoriesResponse>
    {
        private readonly ICategoryRepository repository;

        public GetCategoriesUseCase(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetCategoriesResponse> ExecuteAsync(GetCategoriesRequest request)
        {
            return new GetCategoriesResponse()
            {
                Categories = await this.repository.GetAsync(request.UserId)
            };
        }
    }
}