using System;
using System.Collections.Generic;
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

        public async Task<Category> GetOneAsync(Guid id, string userId)
        {
            Category? category = await this.dbContext.Categories.Where(c => c.Id == id && c.UserId == userId)
                                           .FirstOrDefaultAsync();

            if (category == null)
            {
                throw new CategoryNotFoundException(id, userId);
            }

            return category;
        }

        public Task<List<Category>> GetAsync(string userId)
        {
            return this.dbContext.Categories.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<Category> AddAsync(Category category)
        {
            await this.dbContext.AddAsync(category);

            try
            {
                await this.dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException e) when (e.InnerException is PostgresException { SqlState: "23505" })
            {
                throw new CategoryNameTakenException(category.Name);
            }

            return category;
        }

        public async Task<List<Category>> AddRangeAsync(List<Category> categories)
        {
            await this.dbContext.AddRangeAsync(categories);
            try
            {
                await this.dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException e) when (e.InnerException is PostgresException { SqlState: "23505" })
            {
                throw new CategoryNameTakenException(String.Join(" or ", categories.Select(c => c.Name)));
            }
            
            return categories;
        }

        public async Task<Category> EditAsync(Category category)
        {
            this.dbContext.Update(category);

            try
            {
                await this.dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException e) when (e.InnerException is PostgresException { SqlState: "23505" })
            {
                throw new CategoryNameTakenException(category.Name);
            }

            return category;
        }

        public async Task DeleteAsync(Category category)
        {
            this.dbContext.Categories.Remove(category);

            try
            {
                await this.dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException e) when (e.InnerException is PostgresException)
            {
                //TODO: UPDATE TO PREFENT DELETE IF THERE ARE EXPENSES IN THE CATEGORY
                throw new CategoryNameTakenException(category.Name);
            }
        }
    }
}