using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Apllication.Category.Exception;
using BudgetApp.Apllication.Category.Interfaces;
using BudgetApp.Domain.Category;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BudgetApp.EntityFramework
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BudgetAppContext dbContext;

        public CategoryRepository(BudgetAppContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> GetAsync(Guid id, string userId)
        {
            Category? category = await this.dbContext.Categories.Where(c => c.Id == id && c.UserId == userId)
                                           .FirstOrDefaultAsync();

            if (category == null)
            {
                throw new CategoryNotFoundException(id, userId);
            }

            return category;
        }

        public async Task<Category> AddAsync(Category category)
        {
            await this.dbContext.AddAsync(category);

            try
            {
                await this.dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException e) when (e.InnerException is PostgresException pge)
            {
                throw new CategoryNameTakenException(category.Name);
            }

            return category;
        }

        public async Task<Category> EditAsync(Category category)
        {
            this.dbContext.Update(category);

            try
            {
                await this.dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException e) when (e.InnerException is PostgresException pge)
            {
                throw new CategoryNameTakenException(category.Name);
            }

            return category;
        }
    }
}