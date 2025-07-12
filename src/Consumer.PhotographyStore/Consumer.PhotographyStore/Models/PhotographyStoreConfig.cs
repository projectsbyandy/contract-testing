using System.Text.Json.Serialization;

namespace Consumer.PhotographyStore.Models;

public record PhotographyStoreConfig
{
    [JsonPropertyName("FilmManufacturers")]
    public IList<string>? FilmManufacturers { get; init; } = new List<string>();

    [JsonPropertyName("EmulsiveFactoryServer")]
    public string? EmulsiveFactoryServer { get; init; }
}