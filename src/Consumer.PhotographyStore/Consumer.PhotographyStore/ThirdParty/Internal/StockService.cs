using System.Text.Json;
using Ardalis.GuardClauses;
using Consumer.PhotographyStore.ThirdParty.Models.Stock;

namespace Consumer.PhotographyStore.ThirdParty.Internal;

public class StockService : IStockService
{
    private readonly HttpClient _httpClient;

    public StockService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<StockServiceResponse> GetStockForAsync(string filmName)
    {
        var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"Stock/{filmName}"));

        if (response.IsSuccessStatusCode)
        {
            var stockConverted = await response.Content.ReadAsStreamAsync();
            Guard.Against.Null(stockConverted);

            return new StockServiceResponse(response.StatusCode)
            {
                FilmStock = JsonSerializer.Deserialize<FilmStock>(stockConverted)
            };
        }

        return new StockServiceResponse(response.StatusCode);
    }
}