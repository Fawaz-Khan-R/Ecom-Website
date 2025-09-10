using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using dotnetapp.DTOs;
using dotnetapp.Services;
namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(
            [FromQuery] string searchTerm = "",
            [FromQuery] string category = "")
        {
            if (!string.IsNullOrEmpty(searchTerm) || !string.IsNullOrEmpty(category))
            {
                var searchResults = await _productService.SearchProductsAsync(searchTerm, category);
                return Ok(searchResults);
            }
            
            var products = await _productService.GetApprovedProductsAsync();
            return Ok(products);
        }
        
        [HttpPost]
        [Authorize(Roles = "Seller")]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto dto)
        {
            var sellerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var product = await _productService.CreateProductAsync(dto, sellerId);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();
            
            return Ok(product);
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = "Seller")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, [FromBody] UpdateProductDto dto)
        {
            var sellerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            try
            {
                var product = await _productService.UpdateProductAsync(id, dto, sellerId);
                return Ok(product);
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}