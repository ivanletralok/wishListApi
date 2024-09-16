using DB;

namespace OnlineShopAPI.Services
{
    public class CategoryServices
    {
        public readonly ShopContext _shopContext;
        public CategoryServices(ShopContext shopContext) {
            _shopContext = shopContext;
        }

        public IEnumerable<Category> GetAllCategories() => _shopContext.Categories.ToList();
    }
}
