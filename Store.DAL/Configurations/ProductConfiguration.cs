using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Configurations.Common;
using Store.DAL.Entities;
using Store.DAL.Extensions;

namespace Store.DAL.Configurations;

public sealed class ProductConfiguration : BaseEntityConfiguration<Product>
{
    protected override string TableName => Tables.Product;

    protected override void ConfigureProperties(EntityTypeBuilder<Product> builder)
    {
        builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(255).IsRequired();
        builder.Property(e => e.Color).HasColumnName("color")
            .HasEnumToStringConversion().HasMaxLength(20).IsRequired();
        builder.Property(e => e.Description).HasColumnName("description");
    }
}