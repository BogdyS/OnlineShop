namespace OnlineShop.Authorization;

public static class DependencyInjection
{
    public static IServiceCollection ConfigurationServer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddIdentityServer();
        return serviceCollection;
    }
}