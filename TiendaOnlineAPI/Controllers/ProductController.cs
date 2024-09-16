using Microsoft.AspNetCore.Mvc;
using OnlineShopAPI.Services;

namespace OnlineShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var product = _productService.GetAllProducts();
            return Ok(product);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

    }


}
