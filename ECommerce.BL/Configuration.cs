using ECommerce.BL.Profiles.ProductProfiles;
using ECommerce.BL.Services.Abstractions;
using ECommerce.BL.Services.Implementations;
using ECommerce.Data.Repositories.Abstractions;
using ECommerce.Data.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.BL
{
    public static class Configuration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
        }
        public static void AddProfileServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile).Assembly);
        }

        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        }
    }
}
