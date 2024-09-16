using DB;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopAPI.Services
{
    public class ProductService
    {
        private readonly ShopContext _shopContext;
        public ProductService(ShopContext shopContext) {
            _shopContext = shopContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _shopContext.Products.Include(p => p.Category).ToList();
        }

        public Product GetProductById(int id)
        {
            var product = _shopContext.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return null;
            }

            return product;
        }
    }
}
