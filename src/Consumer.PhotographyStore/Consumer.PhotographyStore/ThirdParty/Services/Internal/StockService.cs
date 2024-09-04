using System.Text.Json;
using Ardalis.GuardClauses;
using Consumer.PhotographyStore.ThirdParty.Models.Stock;

namespace Consumer.PhotographyStore.ThirdParty.Services.Internal;

public class StockService : IStockService
{
    private readonly HttpClient _httpClient;

    public StockService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<StockServiceResponse<FilmStock>> GetStockForAsync(string filmName)
    {
        var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"Stock/{filmName}"));

        if (response.IsSuccessStatusCode)
        {
            var stockConverted = await response.Content.ReadAsStringAsync();

            return Guard.Against.Null(JsonSerializer.Deserialize<StockServiceResponse<FilmStock>>(stockConverted));
        }

        return new StockServiceResponse<FilmStock>(response.StatusCode);
    }
}