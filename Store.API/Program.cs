using Store.API.Extensions;
using Store.BLL.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddServices();

builder.AddAutoMapper();
builder.AddDAL();
builder.AddSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// TODO: надо подумать где свитч между базой и файловым хранилищем делать
app.SeedDatabase();

app.MapControllers();
app.Run();