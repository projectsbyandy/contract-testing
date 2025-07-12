using System.Text.Json.Serialization;

namespace Consumer.PhotographyStore.ThirdParty.Models.EmulsiveFactory;

public record Tag
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}