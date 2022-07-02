using BudgetApp.Apllication;
using BudgetApp.Apllication.Category.AddCategory;
using BudgetApp.Apllication.Category.EditCategory;
using BudgetApp.Apllication.Category.GetCategories;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetApp.Configuration
{
    public static class UseCaseConfiguration
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            return services.AddCategoryUseCases();
        }
        
        public static IServiceCollection AddCategoryUseCases(this IServiceCollection services)
        {
            return services.AddTransient<IUseCase<AddCategoryRequest, AddCategoryResponse>, AddCategoryUseCase>()
                           .AddTransient<IUseCase<EditCategoryRequest, EditCategoryResponse>, EditCategoryUseCase>()
                           .AddTransient<IUseCase<GetCategoriesRequest, GetCategoriesResponse>, GetCategoriesUseCase>();
        }
    }
}