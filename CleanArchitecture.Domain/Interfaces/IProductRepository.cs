using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);

        Task<Product> GetByIdAsync(int id);

        Task<Product> InsertAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<Product> DeleteAsync(Product product);
    }
}
