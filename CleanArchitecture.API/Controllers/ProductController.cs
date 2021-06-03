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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync([FromQuery] bool filter, [FromQuery] int categoryId)
        {
            IEnumerable<ProductDTO> products;

            if (filter)
                products = await _productService.GetProductsByCategoryIdAsync(categoryId);
            else
                products = await _productService.GetProductsAsync();

            return products.Any() ? Ok(products) : NotFound(new { message  = "No products found"});
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> InsertProduct(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                await _productService.InsertAsync(productDTO);

                return Ok(new { message = $"Product '{productDTO.Name}' inserted" });
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            ProductDTO product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound(new { message = $"Product not found" });

            await _productService.DeleteAsync(id);

            return Ok(new { message = $"Product {product.Name} deleted" });
        }
    }
}
