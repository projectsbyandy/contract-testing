using Consumer.PhotographyStore.Models;
using Consumer.PhotographyStore.ThirdParty.Services;
using Consumer.PhotographyStore.ThirdParty.Services.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Load Config
var test = builder.Configuration.GetSection("PhotographyStoreConfig");

// Add custom services
builder.Services.AddHttpClient<IStockService, StockService>(c =>
{
    c.BaseAddress = new Uri("https://localhost:7194");
});

builder.Services.AddHttpClient<IEmulsiveFactoryService, EmulsiveFactoryService>(c =>
{
    c.BaseAddress = new Uri("https://localhost:7194");
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();