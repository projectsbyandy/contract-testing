using System.Text.Json.Serialization;

namespace Provider.EmulsiveFactory.Models.EmulsiveFactory.Response;

public record Tag
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}