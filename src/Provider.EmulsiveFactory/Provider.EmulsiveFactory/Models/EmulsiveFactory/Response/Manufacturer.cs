using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Provider.EmulsiveFactory.Models.EmulsiveFactory.Response;

public record Manufacturer
{
    [Required]
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("location")]
    public string? Location { get; init; }
    
    [JsonPropertyName("date")]
    public required DateOnly Date { get; init; }
}