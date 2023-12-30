using Producer.EmulsiveFactory.Repository;
using Producer.EmulsiveFactory.Repository.Internal;
using Serilog;

namespace Producer.EmulsiveFactory;

public class Startup
{
    // Required for Pact Contract Testing
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddSingleton<IFilmStore, FakeFilmStore>();
        services.AddSingleton<IFilmStockRepo, FakeFilmStockRepo>();
        
        // Logging
        Log.Logger =  new LoggerConfiguration()
            .WriteTo.Console().CreateBootstrapLogger();
        Log.Information("Staring up logging");
        
        services.Configure<ConsoleLifetimeOptions>(options =>  // configure the options
            options.SuppressStatusMessages = true);
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseRouting();
        
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}