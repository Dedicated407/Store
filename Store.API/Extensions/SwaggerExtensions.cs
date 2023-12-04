using Microsoft.OpenApi.Models;

namespace Store.API.Extensions;

public static class SwaggerExtensions
{
    public static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Store.API",
                Description = "Сервис магазин",
                Contact = new OpenApiContact
                {
                    Name = "Цыпин Илья Павлович",
                    Email = "some_email@mail.ru",
                    Url = new Uri("https://t.me/some_email"),
                },
            });
        });
    }
}