using System;
using System.Threading.Tasks;
using BudgetApp.Apllication.Category.Interfaces;

namespace BudgetApp.Apllication.Category.DeleteCategory
{
    public class DeleteCategoryUseCase : IUseCase<DeleteCategoryRequest, DeleteCategoryResponse>
    {
        private readonly ICategoryRepository repository;

        public DeleteCategoryUseCase(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteCategoryResponse> ExecuteAsync(DeleteCategoryRequest request)
        {
            //TODO: CHECK IF ANY EXPENSE IS ASOCIATED WITH THIS CATEGORY
            await this.repository.DeleteAsync(new Domain.Category.Category()
            {
                UserId = request.UserId,
                Id = request.Id
            });
            
            return new DeleteCategoryResponse();
        }
    }
}