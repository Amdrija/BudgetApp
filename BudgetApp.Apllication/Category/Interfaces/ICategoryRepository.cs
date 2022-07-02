using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetApp.Apllication.Category.Interfaces
{
    public interface ICategoryRepository
    {
        Task<BudgetApp.Domain.Category.Category> GetOneAsync(Guid id, string userId);

        Task<List<BudgetApp.Domain.Category.Category>> GetAsync(string userId);
        
        Task<Domain.Category.Category> AddAsync(Domain.Category.Category category);

        Task<List<BudgetApp.Domain.Category.Category>> AddRangeAsync(List<Domain.Category.Category> categories);

        Task<Domain.Category.Category> EditAsync(Domain.Category.Category category);

        Task DeleteAsync(Domain.Category.Category category);
    }
}