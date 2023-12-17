using Producer_EmulsiveFilm.Repository;
using Producer_EmulsiveFilm.Repository.Internal;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFilmStore, FakeFilmStore>();
builder.Services.AddSingleton<IFilmStockRepo, FakeFilmStockRepo>();

// Logging
Log.Logger =  new LoggerConfiguration()
    .WriteTo.Console().CreateBootstrapLogger();
Log.Information("Staring up logging");

builder.Host.UseSerilog((context, logConfig) => logConfig
    .WriteTo.Console()
    .ReadFrom.Configuration(context.Configuration));

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
