using System.Text.Json.Serialization;

namespace Consumer_PhotographyStore.External.Models.FilmResponse;

public class Tag
{
    [JsonPropertyName("Name")]
    public string? Name { get; set; }
}