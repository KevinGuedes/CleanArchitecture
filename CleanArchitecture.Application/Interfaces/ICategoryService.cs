using CleanArchitecture.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();

        Task<CategoryDTO> GetByIdAsync(int id);

        Task InsertAsync(CategoryDTO categoryDTO);

        Task UpdateAsync(CategoryDTO categoryDTO);

        Task DeleteAsync(int id);
    }
}
