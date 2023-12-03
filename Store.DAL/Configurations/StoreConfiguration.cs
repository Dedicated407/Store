using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Configurations.Common;
using StoreEntity = Store.DAL.Entities.Store;

namespace Store.DAL.Configurations;

public sealed class StoreConfiguration : BaseEntityConfiguration<StoreEntity>
{
    protected override string TableName => Tables.Store;

    protected override void ConfigureProperties(EntityTypeBuilder<StoreEntity> builder)
    {
        builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(255).IsRequired();
        builder.Property(e => e.Address).HasColumnName("address").HasMaxLength(255).IsRequired();
    }
}