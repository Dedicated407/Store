using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities.Abstract;

namespace Store.DAL.Configurations.Common;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> 
    where TEntity : BaseEntity
{
    protected abstract string TableName { get; }

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ConfigureTable(builder);
        ConfigureId(builder);
        ConfigureProperties(builder);
    }

    protected virtual void ConfigureTable(EntityTypeBuilder<TEntity> builder) => builder.ToTable(TableName);

    protected virtual void ConfigureId(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName($"{TableName}_pkey");
        builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
    }

    protected abstract void ConfigureProperties(EntityTypeBuilder<TEntity> builder);
}