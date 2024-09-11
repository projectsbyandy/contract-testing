using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Provider.EmulsiveFactory.Contract.Tests.Fixtures;

[TestFixture]
public class StockServiceFixture : IDisposable
{
    private IHost? _server;
    protected Uri? ServiceUri { get; private set; }

    [OneTimeSetUp]
    public void SetupStockServiceFixture()
    {
        ServiceUri = new Uri("https://localhost:7194");

        var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
        {
            ApplicationName = "Provider.EmulsiveFactory"
        });
        
        AppSetup.ConfigureBuilder(builder);
        
        var server = builder.Build();
        
        AppSetup.ConfigureApp(server);
        
        server.Urls.Add(ServiceUri.ToString());
        server.Start();
        
        _server = server;
    }

    [OneTimeTearDown]
    public void TearDownApiFixture()
    {
        Dispose();
    }
    
    public void Dispose()
    {
        _server?.StopAsync().GetAwaiter().GetResult();
        _server?.Dispose();
    }
}