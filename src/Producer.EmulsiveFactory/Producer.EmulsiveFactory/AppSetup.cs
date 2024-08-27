using Producer.EmulsiveFactory.Repository;
using Producer.EmulsiveFactory.Repository.Internal;
using Serilog;

namespace Producer.EmulsiveFactory;

internal static class AppSetup
{
    public static void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<IFilmStore, FakeFilmStore>();
        builder.Services.AddSingleton<IFilmStockRepo, FakeFilmStockRepo>();
        
        // Logging
        Log.Logger =  new LoggerConfiguration()
            .WriteTo.Console().CreateBootstrapLogger();
        Log.Information("Staring up logging");
        
        builder.Services.Configure<ConsoleLifetimeOptions>(options =>  // configure the options
            options.SuppressStatusMessages = true);
        
        builder.Host.UseSerilog((context, logConfig) => logConfig
            .WriteTo.Console()
            .ReadFrom.Configuration(context.Configuration));
    }

    public static void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseAuthorization();
    }
}