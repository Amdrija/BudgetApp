using System;
using System.Threading.Tasks;

namespace BudgetApp.Apllication.Category.Interfaces
{
    public interface ICategoryRepository
    {
        Task<BudgetApp.Domain.Category.Category> GetAsync(Guid id, string userId);
        
        Task<Domain.Category.Category> AddAsync(Domain.Category.Category category);

        Task<Domain.Category.Category> EditAsync(Domain.Category.Category category);
    }
}