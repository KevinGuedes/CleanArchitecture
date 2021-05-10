using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository categoryRepository, IMapper mapper)
        {
            _productRepository = categoryRepository ?? throw new ArgumentNullException(nameof(IProductRepository)); ;
            _mapper = mapper;
        }


        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            IEnumerable<Product> categories = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(categories);
        }

        public async Task InsertAsync(ProductDTO categoryDTO)
        {
            Product newProduct = _mapper.Map<Product>(categoryDTO);
            await _productRepository.InsertAsync(newProduct);
        }

        public async Task RemoveAsync(int? id)
        {
            Product category = await _productRepository.GetByIdAsync(id);
            await _productRepository.RemoveAsync(category);
        }

        public async Task UpdateAsync(ProductDTO categoryDTO)
        {
            Product category = _mapper.Map<Product>(categoryDTO);
            await _productRepository.UpdateAsync(category);
        }
    }
}
