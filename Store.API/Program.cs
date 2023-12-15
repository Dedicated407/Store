using Store.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.AddAutoMapper();
builder.AddDAL();
builder.AddSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// TODO: продумать seeds
// app.SeedDatabase();

app.MapControllers();
app.Run();