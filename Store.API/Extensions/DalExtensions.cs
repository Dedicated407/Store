using Microsoft.EntityFrameworkCore;
using Store.BLL.Services.Products;
using Store.BLL.Services.Stores;
using Store.BLL.Services.StoresProducts;
using Store.DAL.Common;
using Store.DAL.Storages.DatabaseStorage;

namespace Store.API.Extensions;

public static class DalExtensions
{
    public static void AddDAL(this WebApplicationBuilder builder)
    {
        var implementationType = bool.TryParse(builder.Configuration["IsFileStorage"], out var isFileStorage);

        if (implementationType && isFileStorage)
        {
            builder.AddFileStorage();
        }
        else
        {
            builder.AddDatabase();
        }
    }

    private static void AddFileStorage(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductsService, ProductsFileService>();
        builder.Services.AddScoped<IStoresService, StoresFileService>();
        builder.Services.AddScoped<IStoresProductsService, StoresProductsFileService>();
    }

    private static void AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductsService, ProductsDatabaseService>();
        builder.Services.AddScoped<IStoresService, StoresService>();
        builder.Services.AddScoped<IStoresProductsService, StoresProductsService>();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("Connection string is missing.");
        }

        builder.Services.AddDbContext<StoreDbContext>(options => options.UseNpgsql(connectionString));
    }

    public static void SeedDatabase(this WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();
        var storeDbContext = serviceScope.ServiceProvider.GetRequiredService<StoreDbContext>();

        DatabaseInitializer.Initialize(storeDbContext);
    }
}