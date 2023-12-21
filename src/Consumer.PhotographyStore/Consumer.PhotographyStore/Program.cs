using Consumer.PhotographyStore.ThirdParty;
using Consumer.PhotographyStore.ThirdParty.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();