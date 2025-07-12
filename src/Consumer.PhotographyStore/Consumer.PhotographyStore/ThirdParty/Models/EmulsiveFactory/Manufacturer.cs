using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Consumer.PhotographyStore.ThirdParty.Models.EmulsiveFactory;

public record Manufacturer
{
    [Required]
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("location")]
    public string? Location { get; init; }
    
    [JsonPropertyName("date")]
    public DateOnly Date { get; init; }
}