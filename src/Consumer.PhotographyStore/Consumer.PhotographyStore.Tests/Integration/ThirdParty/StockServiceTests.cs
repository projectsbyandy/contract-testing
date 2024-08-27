using System.Net;
using Consumer.PhotographyStore.ThirdParty.Services.Internal;
using FluentAssertions;

namespace Consumer.PhotographyStore.Tests.Integration.ThirdParty;

// NOTE - Requires Producer to be running
public class StockServiceTests
{
    [Test]
    public async Task Verify_A_Valid_External_Stock_Service_Returns_0_or_more_stock()
    {
        // Given
        var stockService = new StockService(new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7194")
        });
        
        // When
        var filmStockDetails = await stockService.GetStockForAsync("CT800");
        
        // Then
        filmStockDetails.FilmStock?.Stock?.InStock.Should().BeGreaterOrEqualTo(0);
        filmStockDetails.FilmStock?.Stock?.OnOrder.Should().BeGreaterOrEqualTo(0);
        filmStockDetails.FilmStock?.Film?.Name.Should().Be("CT800");
        filmStockDetails.FilmStock?.Film?.Manufacturer?.Name.Should().Be("Cinestill");
    }
    
    [Test]
    public async Task Verify_A_Invalid_Film_External_Stock_Service_Returns_404()
    {
        // Given
        var stockService = new StockService(new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7194")
        });
        
        // When
        var response =  await stockService.GetStockForAsync("InvalidFilm");
        
        // Then
        response.HttpStatusCode.Should()
            .Be(HttpStatusCode.NotFound);
    }
}