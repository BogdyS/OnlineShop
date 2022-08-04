using BusinessLogic.Mapping;
using BusinessLogic.Repositories.Implementations;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services.Implementations;
using BusinessLogic.Services.Interfaces;
using DataConnection;
using Microsoft.EntityFrameworkCore;
namespace OnlineShop;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddDataConnection(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("ShopDatabase"));
            options.UseEnumCheckConstraints();
            options.UseValidationCheckConstraints();
        });
        return builder;
    }

    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
        builder.Services.AddScoped<ITypeRepository, TypeRepository>();
        builder.Services.AddScoped<ITypeService, TypeService>();
        builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);
        return builder;
    }
}