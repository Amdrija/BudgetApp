using System;
using System.Threading.Tasks;
using BudgetApp.Apllication.Category.Interfaces;

namespace BudgetApp.Apllication.Category.EditCategory
{
    public class EditCategoryUseCase : IUseCase<EditCategoryRequest, EditCategoryResponse>
    {
        private readonly ICategoryRepository repository;

        public EditCategoryUseCase(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<EditCategoryResponse> ExecuteAsync(EditCategoryRequest request)
        {
            var category = await this.repository.GetOneAsync(request.Id, request.UserId);
            
            category.Color = request.Color;
            category.Name = request.Name;

            await this.repository.EditAsync(category);
            
            return new EditCategoryResponse()
            {
                Category = category
            };
        }
    }
}