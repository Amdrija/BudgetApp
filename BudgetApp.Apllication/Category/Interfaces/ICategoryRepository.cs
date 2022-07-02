using System.Threading.Tasks;

namespace BudgetApp.Apllication.Category.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Domain.Category.Category> AddAsync(Domain.Category.Category category);
    }
}