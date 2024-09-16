using DB;
using Microsoft.EntityFrameworkCore;
using OnlineShopAPI.Models;

namespace OnlineShopAPI.Services
{
    public class DesiredProductService
    {
        private readonly ShopContext _shopContext;

        public DesiredProductService(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public IEnumerable<ProductoDesiredDto> GetAllDesiredProducts()
        {
            return _shopContext.DesiredProducts
                .Include(dp => dp.Product)
                .Include(dp => dp.User)
                .Select(dp => new ProductoDesiredDto
                {
                    ProductId = dp.Product.ProductId,
                    Title = dp.Product.Title,
                    Price = dp.Product.Price,
                    Description = dp.Product.Description,
                    Image = dp.Product.Image,
                    CreatedDate = dp.Product.CreatedDate,
                    UpdatedDate = dp.Product.UpdatedDate,
                    User = new UserResponse
                    {
                        UserId = dp.User.UserId,
                        Username = dp.User.Username
                    }
                })
                .ToList();
        }

        public ProductoDesiredDto GetDesiredProductById(int id)
        {
            var desiredProduct = _shopContext.DesiredProducts
                .Include(dp => dp.Product)
                .Include(dp => dp.User)
                .FirstOrDefault(dp => dp.DesiredId == id);

            if (desiredProduct == null)
            {
                return null;
            }

            return new ProductoDesiredDto
            {
                ProductId = desiredProduct.Product.ProductId,
                Title = desiredProduct.Product.Title,
                Price = desiredProduct.Product.Price,
                Description = desiredProduct.Product.Description,
                Image = desiredProduct.Product.Image,
                CreatedDate = desiredProduct.Product.CreatedDate,
                UpdatedDate = desiredProduct.Product.UpdatedDate,
                User = new UserResponse
                {
                    UserId = desiredProduct.User.UserId,
                    Username = desiredProduct.User.Username
                }
            };
        }


        public IEnumerable<DesiredProduct> GetDesiredProductsByUserId(int userId)
        {
            return _shopContext.DesiredProducts
                .Include(dp => dp.Product)
                .Where(dp => dp.UserId == userId)
                .ToList();
        }

        public bool AddDesiredProduct(int productId, int userId)
        {
            var product = _shopContext.Products.Find(productId);
            if (product == null)
            {
                return false;
            }

            var exists = _shopContext.DesiredProducts.Any(dp => dp.ProductId == productId && dp.UserId == userId);
            if (exists)
            {
                return false;
            }

            var desiredProduct = new DesiredProduct
            {
                ProductId = productId,
                UserId = userId
            };

            _shopContext.DesiredProducts.Add(desiredProduct);
            _shopContext.SaveChanges();
            return true;
        }

        public bool DeleteDesiredProduct(int id)
        {
            var desiredProduct = _shopContext.DesiredProducts
               .Include(dp => dp.Product)
               .FirstOrDefault(dp => dp.DesiredId == id);

            if (desiredProduct == null)
            {
                return false;
            }

            _shopContext.DesiredProducts.Remove(desiredProduct);
            _shopContext.SaveChanges();
            return true;
        }
    }
}
