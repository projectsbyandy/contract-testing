using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Consumer.PhotographyStore.ThirdParty.Models.EmulsiveFactory;

public class Manufacturer
{
    [Required]
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("location")]
    public string? Location { get; set; }
    
    [JsonPropertyName("date")]
    public DateOnly Date { get; set; }
}