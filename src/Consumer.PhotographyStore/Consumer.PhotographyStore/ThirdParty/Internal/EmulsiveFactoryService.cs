using System.Text.Json;
using Ardalis.GuardClauses;
using Consumer.PhotographyStore.ThirdParty.Models.EmulsiveFactory;

namespace Consumer.PhotographyStore.ThirdParty.Internal;

public class EmulsiveFactoryService : IEmulsiveFactoryService
{
    private readonly HttpClient _httpClient;

    public EmulsiveFactoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Film>> GetAllFilmAsync()
    {
        var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, "EmulsiveFilm"));
        
        response.EnsureSuccessStatusCode();
        
        var stockConverted = await response.Content.ReadAsStreamAsync();
        Guard.Against.Null(stockConverted);

        return JsonSerializer.Deserialize<IList<Film>>(stockConverted) ?? Enumerable.Empty<Film>();
    }
}