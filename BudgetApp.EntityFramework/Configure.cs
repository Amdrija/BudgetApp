using BudgetApp.Apllication.Category.Interfaces;
using BudgetApp.Apllication.Expense.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetApp.EntityFramework
{
    public static class Configure
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<BudgetAppContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("budgetDb")));
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddTransient<ICategoryRepository, CategoryRepository>()
                           .AddTransient<IExpenseRepository, ExpenseRepository>();
        }
    }
}