using System.Text.Json;
using Ardalis.GuardClauses;
using Consumer_PhotographyStore.External.Models.Stock;

namespace Consumer_PhotographyStore.External.Service;

public class StockService : IStockService
{
    private readonly HttpClient _httpClient;

    public StockService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<FilmStock> GetStockForAsync(string filmName)
    {
        var response = await _httpClient.GetAsync("stock");

        response.EnsureSuccessStatusCode();
        
        var stockConverted = await response.Content.ReadAsStreamAsync();
        Guard.Against.Null(stockConverted);
        
        return JsonSerializer.Deserialize<FilmStock>(stockConverted);
    }
}