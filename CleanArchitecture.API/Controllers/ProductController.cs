using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            return await _productService.GetProductsAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> InsertProduct(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
               await _productService.InsertAsync(productDTO);

                return Ok(new
                {
                    message = $"Product {productDTO.Name} added."
                });
            }

            return BadRequest(ModelState);
        }
    }
}
