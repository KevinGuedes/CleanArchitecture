using CleanArchitecture.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();

        Task<IEnumerable<ProductDTO>> GetProductsByCategoryIdAsync(int categoryId);

        Task<ProductDTO> GetByIdAsync(int id);

        Task InsertAsync(ProductDTO productDTO);

        Task UpdateAsync(ProductDTO productDTO);

        Task DeleteAsync(int id);
    }
}
