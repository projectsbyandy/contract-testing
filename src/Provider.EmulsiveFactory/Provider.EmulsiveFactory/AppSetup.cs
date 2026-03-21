using Provider.EmulsiveFactory.Repository;
using Provider.EmulsiveFactory.Repository.Internal;
using Scalar.AspNetCore;
using Serilog;

namespace Provider.EmulsiveFactory;

internal static class AppSetup
{
    public static void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddSingleton<IFilmStore, FakeFilmStore>();
        builder.Services.AddSingleton<IFilmStockRepo, FakeFilmStockRepo>();
        
        // Logging
        builder.Services.Configure<ConsoleLifetimeOptions>(options =>
            options.SuppressStatusMessages = true);

        builder.Services.AddSerilog(configuration =>
        {
            configuration
                .WriteTo.Console()
                .MinimumLevel.Debug();
        });
    }

    public static void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseAuthorization();
    }
}