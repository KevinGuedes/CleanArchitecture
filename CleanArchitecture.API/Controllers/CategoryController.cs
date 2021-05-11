using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            return await _categoryService.GetCategoriesAsync();
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> InsertCategory(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.InsertAsync(categoryDTO);

                return Ok(new
                {
                    message = $"Category {categoryDTO.Name} added."
                });
            }

            return BadRequest(ModelState);
        }
    }
}
