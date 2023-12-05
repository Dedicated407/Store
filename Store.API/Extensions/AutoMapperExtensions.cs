using AutoMapper;
using Store.BLL.Mapping;

namespace Store.API.Extensions;

public static class AutoMapperExtensions
{
    public static void AddAutoMapper(this WebApplicationBuilder builder) =>
        builder.Services.AddSingleton<IMapper>(_ =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
            });

            return config.CreateMapper();
        });
}