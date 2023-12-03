using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Configurations.Common;
using Store.DAL.Entities;

namespace Store.DAL.Configurations;

public sealed class StoreProductConfiguration : BaseEntityConfiguration<StoreProduct>
{
    protected override string TableName => Tables.StoreProduct;

    protected override void ConfigureProperties(EntityTypeBuilder<StoreProduct> builder)
    {
        builder.Property(e => e.StoreId).HasColumnName($"{Tables.Store}_id").IsRequired();
        builder.Property(e => e.ProductId).HasColumnName($"{Tables.Product}_id").IsRequired();
        builder.Property(e => e.Price).HasColumnName("price").IsRequired();
        builder.Property(e => e.Quantity).HasColumnName("quantity").IsRequired();

        builder.HasOne(e => e.Store)
            .WithMany(e => e.StoreProducts)
            .HasForeignKey(e => e.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Product)
            .WithMany(e => e.StoreProducts)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}