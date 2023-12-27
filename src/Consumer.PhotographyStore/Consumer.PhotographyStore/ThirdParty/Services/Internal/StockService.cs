using System.Text.Json;
using Ardalis.GuardClauses;

namespace Consumer.PhotographyStore.ThirdParty.Services.Internal;

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
            var stockConverted = await response.Content.ReadAsStringAsync();

            return Guard.Against.Null(JsonSerializer.Deserialize<StockServiceResponse>(stockConverted));
        }

        return new StockServiceResponse(response.StatusCode);
    }
}