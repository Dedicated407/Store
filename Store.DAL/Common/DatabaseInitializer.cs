using Microsoft.EntityFrameworkCore;
using Store.DAL.Storages.DatabaseStorage;

namespace Store.DAL.Common;

public static class DatabaseInitializer
{
    public static void Initialize(StoreDbContext context)
    {
        if (context.Database.CanConnect())
        {
            context.Database.Migrate();
        }
        else
        {
            throw new InvalidOperationException($"Database: {nameof(StoreDbContext)} not available");
        }
    }
}