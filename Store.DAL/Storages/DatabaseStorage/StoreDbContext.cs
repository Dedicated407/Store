using Microsoft.EntityFrameworkCore;
using Store.DAL.Configurations;
using Store.DAL.Entities;
using StoreEntity = Store.DAL.Entities.Store;

namespace Store.DAL.Storages.DatabaseStorage;

public sealed class StoreDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<StoreEntity> Stores { get; set; } = null!;
    public DbSet<StoreProduct> StoresProducts { get; set; } = null!;

    public StoreDbContext() { }

    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
        new StoreConfiguration().Configure(modelBuilder.Entity<StoreEntity>());
        new StoreProductConfiguration().Configure(modelBuilder.Entity<StoreProduct>());
    }
}