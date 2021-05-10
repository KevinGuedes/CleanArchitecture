using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(ICategoryRepository));
            _mapper = mapper;
        }

        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            IEnumerable<Category> categories = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task InsertAsync(CategoryDTO categoryDTO)
        {
            Category newCategory = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.InsertAsync(newCategory);
        }

        public async Task RemoveAsync(int? id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.RemoveAsync(category);
        }

        public async Task UpdateAsync(CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
