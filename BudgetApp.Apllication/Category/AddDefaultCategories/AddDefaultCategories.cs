using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.Apllication.Category.Interfaces;
using BudgetApp.Domain.Category;

namespace BudgetApp.Apllication.Category.AddDefaultCategories
{
    public class AddDefaultCategoriesUseCase : IUseCase<AddDefaultCategoriesRequest, AddDefaultCategoriesResponse>
    {
        private readonly ICategoryRepository repository;

        public AddDefaultCategoriesUseCase(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AddDefaultCategoriesResponse> ExecuteAsync(AddDefaultCategoriesRequest request)
        {
            await this.repository.AddRangeAsync(DefaultCategories.Get(request.UserId));
            
            return new AddDefaultCategoriesResponse();
        }
    }
}