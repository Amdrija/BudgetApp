using System;
using System.Threading.Tasks;
using BudgetApp.Apllication.Category.Interfaces;

namespace BudgetApp.Apllication.Category.AddCategory
{
    public class AddCategoryUseCase: IUseCase<AddCategoryRequest, AddCategoryResponse>
    {
        private readonly ICategoryRepository repository;

        public AddCategoryUseCase(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AddCategoryResponse> ExecuteAsync(AddCategoryRequest request)
        {
            Domain.Category.Category category = new()
            {
                Name = request.Name,
                Color = request.Color,
                UserId = request.UserId
            };

            return new AddCategoryResponse()
            {
                Category = await this.repository.AddAsync(category)
            };
        }
    }
}