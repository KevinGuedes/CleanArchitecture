using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Products.Commands;
using CleanArchitecture.Application.Products.Queries;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            GetProductByIdQuery getProductByIdQuery = new(id);

            Product product = await _mediator.Send(getProductByIdQuery);

            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);

            return productDTO;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            GetProductsQuery getProductsQuery = new();

            IEnumerable<Product> products = await _mediator.Send(getProductsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryIdAsync(int categoryId)
        {
            GetProductsByCategoryIdQuery getProductsByCategoryIdQuery = new(categoryId);

            IEnumerable<Product> products = await _mediator.Send(getProductsByCategoryIdQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task InsertAsync(ProductDTO productDTO)
        {
            ProductInsertCommand productInsertCommand = _mapper.Map<ProductInsertCommand>(productDTO);

            await _mediator.Send(productInsertCommand);
        }

        public async Task DeleteAsync(int id)
        {
            ProductDeleteCommand productDeleteCommand = new(id);

            await _mediator.Send(productDeleteCommand);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            ProductUpdateCommand productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);

            await _mediator.Send(productUpdateCommand);
        }
    }
}
