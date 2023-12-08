using Microsoft.Extensions.DependencyInjection;
using Store.BLL.Services.Products;
using Store.BLL.Services.Stores;

namespace Store.BLL.Extensions;

public static class ServicesExtensions
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductsService, ProductsService>();
        serviceCollection.AddScoped<IStoresService, StoresService>();
    }
}