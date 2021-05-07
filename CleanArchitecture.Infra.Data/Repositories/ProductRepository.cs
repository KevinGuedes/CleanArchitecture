using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _applicationDbContext.Products.Include(p => p.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _applicationDbContext.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> InsertAsync(Product product)
        {
            await _applicationDbContext.Products.AddAsync(product);
            await _applicationDbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> RemoveAsync(Product product)
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
