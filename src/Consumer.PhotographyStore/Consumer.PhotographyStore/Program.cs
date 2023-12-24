using Ardalis.GuardClauses;
using Consumer.PhotographyStore.Models;
using Consumer.PhotographyStore.ThirdParty.Services;
using Consumer.PhotographyStore.ThirdParty.Services.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Load Config
var photographyStoreConfig =
    Guard.Against.Null(builder.Configuration.GetSection("PhotographyStoreConfig").Get<PhotographyStoreConfig>());

builder.Services.AddSingleton(photographyStoreConfig);

// Add custom services
builder.Services.AddHttpClient<IStockService, StockService>(c =>
{
    c.BaseAddress = new Uri(photographyStoreConfig.EmulsiveFactoryServer);
});

builder.Services.AddHttpClient<IEmulsiveFactoryService, EmulsiveFactoryService>(c =>
{
    c.BaseAddress = new Uri(photographyStoreConfig.EmulsiveFactoryServer);
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