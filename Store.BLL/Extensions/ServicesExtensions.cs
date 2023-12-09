using Microsoft.Extensions.DependencyInjection;
using Store.BLL.Services.Products;
using Store.BLL.Services.Stores;
using Store.BLL.Services.StoresProducts;

namespace Store.BLL.Extensions;

public static class ServicesExtensions
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductsService, ProductsService>();
        serviceCollection.AddScoped<IStoresService, StoresService>();
        serviceCollection.AddScoped<IStoresProductsService, StoresProductsService>();
    }
}