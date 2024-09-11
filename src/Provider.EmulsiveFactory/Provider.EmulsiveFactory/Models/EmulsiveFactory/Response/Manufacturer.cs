using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Provider.EmulsiveFactory.Models.EmulsiveFactory.Response;

public class Manufacturer
{
    [Required]
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("location")]
    public string? Location { get; set; }
}