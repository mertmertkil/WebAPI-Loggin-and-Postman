using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApp.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var products = new List<Product>()
            {
                new Product(){Id=1, ProductName="Computer"},
                new Product(){Id=2, ProductName="Keybord"},
                new Product(){Id=3, ProductName="Mouse"}
            };
            _logger.LogInformation("ProductsGetAll has been called");
            return Ok(products);
        }

        [HttpPost ]
        public IActionResult GetAllProduct([FromBody] Product product)
        {
            _logger.LogWarning("Product has been created.");
            return StatusCode(201); // created.
        }

    }
}

