using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Store.DAL.Extensions;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<TEnum> HasEnumToStringConversion<TEnum>(this PropertyBuilder<TEnum> propertyBuilder)
        where TEnum : struct
        => propertyBuilder.HasConversion(new EnumToStringConverter<TEnum>());
}