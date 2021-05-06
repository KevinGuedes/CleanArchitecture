using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int? id);

        Task<Product> GetByIdAsync(int? id);

        Task<Product> CreateAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<Product> RemoveAsync(Product product);
    }
}
