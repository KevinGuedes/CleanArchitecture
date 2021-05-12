using CleanArchitecture.Application.Products.Queries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {

        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
                throw new ApplicationException($"Product with id {request.Id} not found");

            return product;
        }
    }
}
