using System.Threading.Tasks;
using BudgetApp.Apllication.Category.Interfaces;
using BudgetApp.Domain.Category;

namespace BudgetApp.EntityFramework
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BudgetAppContext dbContext;

        public CategoryRepository(BudgetAppContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> AddAsync(Category category)
        {
            await this.dbContext.AddAsync(category);
            await this.dbContext.SaveChangesAsync();

            return category;
        }
    }
}