using System.Collections.Generic;
using BudgetApp.Apllication;
using BudgetApp.Apllication.Category.AddCategory;
using BudgetApp.Apllication.Category.AddDefaultCategories;
using BudgetApp.Apllication.Category.DeleteCategory;
using BudgetApp.Apllication.Category.EditCategory;
using BudgetApp.Apllication.Category.GetCategories;
using BudgetApp.Apllication.Category.GetCategory;
using BudgetApp.Apllication.Expense.AddExpense;
using BudgetApp.Apllication.Expense.EditExpense;
using BudgetApp.Apllication.Expense.GetExpense;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetApp.Configuration
{
    public static class UseCaseConfiguration
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            return services.AddCategoryUseCases()
                           .AddExpenseUseCases();
        }
        
        public static IServiceCollection AddCategoryUseCases(this IServiceCollection services)
        {
            return services.AddTransient<IUseCase<AddCategoryRequest, AddCategoryResponse>, AddCategoryUseCase>()
                           .AddTransient<IUseCase<EditCategoryRequest, EditCategoryResponse>, EditCategoryUseCase>()
                           .AddTransient<IUseCase<GetCategoriesRequest, GetCategoriesResponse>, GetCategoriesUseCase>()
                           .AddTransient<IUseCase<GetCategoryRequest, GetCategoryResponse>, GetCategoryUseCase>()
                           .AddTransient<IUseCase<DeleteCategoryRequest, DeleteCategoryResponse>, DeleteCategoryUseCase>()
                           .AddTransient<IUseCase<AddDefaultCategoriesRequest, AddDefaultCategoriesResponse>, AddDefaultCategoriesUseCase>();
        }
        
        public static IServiceCollection AddExpenseUseCases(this IServiceCollection services)
        {
            return services.AddTransient<IUseCase<List<AddExpenseRequest>, AddExpenseResponse>, AddExpenseUseCase>()
                           .AddTransient<IUseCase<EditExpenseRequest, EditExpenseResponse>, EditExpenseUseCase>()
                           .AddTransient<IUseCase<GetExpenseRequest, GetExpenseResponse>, GetExpenseUseCase>();
        }
    }
}