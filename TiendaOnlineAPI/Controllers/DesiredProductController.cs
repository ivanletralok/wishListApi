using Microsoft.AspNetCore.Mvc;
using OnlineShopAPI.Models;
using OnlineShopAPI.Services;

namespace OnlineShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesiredProductController : ControllerBase
    {
        private readonly DesiredProductService _desiredProductService;

        public DesiredProductController(DesiredProductService desiredProductService)
        {
            _desiredProductService = desiredProductService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var desiredProducts = _desiredProductService.GetAllDesiredProducts();
            return Ok(desiredProducts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var desiredProduct = _desiredProductService.GetDesiredProductById(id);
            if (desiredProduct == null)
            {
                return NotFound($"DesiredProduct with ID {id} not found.");
            }
            return Ok(desiredProduct);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetDesiredProductsByUser(int userId)
        {
            var desiredProducts = _desiredProductService.GetDesiredProductsByUserId(userId);
            if (!desiredProducts.Any())
            {
                return NotFound("No desired products found for this user.");
            }
            return Ok(desiredProducts);
        }

        [HttpPost]
        public IActionResult Post([FromBody] DesiredProductRequest request)
        {
            if (request.ProductId <= 0 || request.UserId <= 0)
            {
                return BadRequest("Invalid product ID or user ID.");
            }

            bool added = _desiredProductService.AddDesiredProduct(request.ProductId, request.UserId);

            if (!added)
            {
                return Conflict("The product could not be added or is already in the list.");
            }

            return Ok("DesiredProduct added successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_desiredProductService.DeleteDesiredProduct(id))
            {
                return NotFound($"DesiredProduct with ID {id} not found.");
            }

            return NoContent();
        }
    }
}
