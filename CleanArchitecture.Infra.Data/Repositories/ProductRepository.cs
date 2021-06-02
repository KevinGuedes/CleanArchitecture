using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            IEnumerable<Product> products = await _applicationDbContext.Products.Include(p => p.Category).ToListAsync();

            return products.Where(p => p.Id == id).Select(p => new Product(p.Id, p.Name, p.Description, p.Price, p.Stock, p.Image, p.CategoryId)).SingleOrDefault();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            IEnumerable<Product> products = await _applicationDbContext.Products.Include(p => p.Category).ToListAsync();

            return products.Select(p => new Product(p.Id, p.Name, p.Description, p.Price, p.Stock, p.Image, p.CategoryId));
        }

        public async Task<Product> InsertAsync(Product product)
        {
            await _applicationDbContext.Products.AddAsync(product);
            await _applicationDbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> DeleteAsync(Product product)
        {
            _applicationDbContext.Products.Remove(product);
            await _applicationDbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _applicationDbContext.Products.Update(product);
            await _applicationDbContext.SaveChangesAsync();

            return product;
        }
    }
}
