using OnlineShopAPI.Services;

namespace OnlineShopAPI.Configurations
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ProductService>();
            services.AddTransient<CategoryServices>();
            services.AddTransient<DesiredProductService>();
        }
    }
}
