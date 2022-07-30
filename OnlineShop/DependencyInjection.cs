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
}