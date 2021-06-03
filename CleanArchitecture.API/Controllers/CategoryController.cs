using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            IEnumerable<CategoryDTO> categories = await _categoryService.GetCategoriesAsync();

            return categories.Any() ? Ok(categories) : NotFound(new { message = "No categories found" });
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> InsertCategory(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.InsertAsync(category);

                return Ok(new
                {
                    message = $"Category '{category.Name}' inserted"
                });
            }

            return BadRequest(ModelState);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            CategoryDTO category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound(new { message = $"Category not found" });

            await _categoryService.DeleteAsync(id);

            return Ok(new { message = $"Category {category.Name} deleted" });
        }
    }
}
