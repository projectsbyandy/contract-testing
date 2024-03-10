using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Producer.EmulsiveFactory.Contract.Tests.Fixtures;

[TestFixture]
public class StockServiceFixture : IDisposable
{
    private IHost? _server;
    protected Uri? ServiceUri { get; private set; }

    [OneTimeSetUp]
    public void SetupStockServiceFixture()
    {
        ServiceUri = new Uri("https://localhost:7194");
        _server = Host
            .CreateDefaultBuilder()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseUrls(ServiceUri.ToString());
                webBuilder.UseStartup<Startup>();
            })
            .Build();
        
        _server.Start();
    }
    
    public void Dispose()
    {
        _server?.StopAsync().GetAwaiter().GetResult();
        _server?.Dispose();
    }
}