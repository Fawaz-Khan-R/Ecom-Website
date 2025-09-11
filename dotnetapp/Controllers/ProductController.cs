using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using dotnetapp.DTOs;
using dotnetapp.Services;
using System.Security.Claims;
using dotnetapp.Models;


namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        // Example minimal endpoint
        [HttpGet]
        public IActionResult Get() => Ok("Product service is available.");

        [HttpGet("all")]
        public IActionResult GetAll() => Ok(_service.GetAllProducts());

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_service.GetProductById(id));

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _service.CreateProduct(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            _service.UpdateProduct(id, product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteProduct(id);
            return NoContent();
        }
    }
}