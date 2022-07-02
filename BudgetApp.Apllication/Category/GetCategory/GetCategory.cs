using System;
using System.Threading.Tasks;
using BudgetApp.Apllication.Category.GetCategories;
using BudgetApp.Apllication.Category.Interfaces;

namespace BudgetApp.Apllication.Category.GetCategory
{
    public class GetCategoryUseCase : IUseCase<GetCategoryRequest, GetCategoryResponse>
    {
        private readonly ICategoryRepository categoryRepository;

        public GetCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<GetCategoryResponse> ExecuteAsync(GetCategoryRequest request)
        {
            return new GetCategoryResponse()
            {
                Category = await this.categoryRepository.GetOneAsync(request.Id, request.UserId)
            };
        }
    }
}