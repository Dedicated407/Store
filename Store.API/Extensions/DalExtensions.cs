using Microsoft.EntityFrameworkCore;
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
        // TODO: (Ilya) file storage
    }

    private static void AddDatabase(this WebApplicationBuilder builder)
    {
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