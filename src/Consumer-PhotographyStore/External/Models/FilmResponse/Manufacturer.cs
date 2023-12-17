using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Consumer_PhotographyStore.External.Models.FilmResponse;

public class Manufacturer
{
    [Required]
    [JsonPropertyName("Name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("Location")]
    public string? Location { get; set; }
}