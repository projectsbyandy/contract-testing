using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Producer.EmulsiveFactory.Models.EmulsiveFactory.Response;

public class Manufacturer
{
    [Required]
    [JsonPropertyName("Name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("Location")]
    public string? Location { get; set; }
}