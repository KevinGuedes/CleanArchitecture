using CleanArchitecture.Application.Products.Commands;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.Handlers
{
    public class ProductInsertCommandHandler : IRequestHandler<ProductInsertCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductInsertCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> Handle(ProductInsertCommand request, CancellationToken cancellationToken)
        {
            Product product = new(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);

            if (product == null)
                throw new ApplicationException("Invalid product");

            return await _productRepository.InsertAsync(product);
        }
    }
}
