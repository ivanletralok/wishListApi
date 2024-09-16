using Microsoft.AspNetCore.Mvc;
using OnlineShopAPI.Services;

namespace OnlineShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryServices _categoryServices;
        public CategoryController(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var category = _categoryServices.GetAllCategories();
            return Ok(category);
        }
    }
}
