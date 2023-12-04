using Microsoft.EntityFrameworkCore;
using Store.DAL.Storages.DatabaseStorage;

namespace Store.API.Extensions;

public static class DatabaseExtensions
{
    public static void AddDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("Connection string is missing.");
        }

        builder.Services.AddDbContext<StoreDbContext>(options => options.UseNpgsql(connectionString));
    }
}