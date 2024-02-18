using APSTUnitTesting.Models;
using APSTUnitTesting.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APSTUnitTesting.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService product)
        {
            _productService = product;
        }
        [HttpGet]
        public ActionResult Get() => Ok(_productService.Get());

        [HttpGet("{id}")]

        public IActionResult GetById(int Id)
        {
            var product = _productService.Get(Id);
            if(product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            try
            {
                var addedProduct = _productService.AddProduct(product);
                return CreatedAtAction(nameof(GetById), new { id = addedProduct.Id }, addedProduct);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
