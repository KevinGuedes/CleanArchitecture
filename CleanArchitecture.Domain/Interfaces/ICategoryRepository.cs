using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<Category> GetByIdAsync(int id);

        Task<Category> InsertAsync(Category category);

        Task<Category> UpdateAsync(Category category);

        Task<Category> DeleteAsync(Category category);
    }
}
