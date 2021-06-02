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
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync()
        {
            IEnumerable<ProductDTO> products = await _productService.GetProductsAsync();

            if (!products.Any())
                return NoContent();

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> InsertProduct(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
               await _productService.InsertAsync(productDTO);

                return Ok(new
                {
                    message = $"Product '{productDTO.Name}' added."
                });
            }

            return BadRequest(ModelState);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByCategoryIdAsync([FromQuery] int categoryId)
        {
            IEnumerable<ProductDTO> products = await _productService.GetProductsByCategoryIdAsync(categoryId);

            if (!products.Any())
                return NoContent();

            return Ok(products);
        }
    }
}
