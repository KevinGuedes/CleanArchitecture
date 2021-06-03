using CleanArchitecture.Application.Products.Queries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.Handlers.Commands
{
    public class GetProductByCategoryIdHandler : IRequestHandler<GetProductsByCategoryIdQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetProductByCategoryIdHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsync(request.CategoryId); 

            if(category == null)
                return null;

            IEnumerable<Product> products = await _productRepository.GetByCategoryIdAsync(request.CategoryId);

            return products;
        }
    }
}
