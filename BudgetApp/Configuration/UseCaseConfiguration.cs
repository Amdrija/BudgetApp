using BudgetApp.Apllication;
using BudgetApp.Apllication.Category.AddCategory;
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
            return services.AddTransient<IUseCase<AddCategoryRequest, AddCategoryResponse>, AddCategoryUseCase>();
        }
    }
}