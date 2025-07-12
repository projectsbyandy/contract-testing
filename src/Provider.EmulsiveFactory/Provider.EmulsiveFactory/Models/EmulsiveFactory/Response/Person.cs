using System.Text.Json.Serialization;

namespace Provider.EmulsiveFactory.Models.EmulsiveFactory.Response;

public record Person
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("email")]
    public string? Email { get; init; }
    
    [JsonPropertyName("location")]
    public string? Location { get; init; }
}