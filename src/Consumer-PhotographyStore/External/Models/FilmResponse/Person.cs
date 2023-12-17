using System.Text.Json.Serialization;

namespace Consumer_PhotographyStore.External.Models.FilmResponse;

public class Person
{
    [JsonPropertyName("Name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("Email")]
    public string? Email { get; set; }
    
    [JsonPropertyName("Location")]
    public string? Location { get; set; }
}