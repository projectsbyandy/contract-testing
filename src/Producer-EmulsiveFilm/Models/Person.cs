using System.Text.Json.Serialization;

namespace Producer_EmulsiveFilm.Models;

public class Person
{
    [JsonPropertyName("Name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("Email")]
    public string? Email { get; set; }
    
    [JsonPropertyName("Location")]
    public string? Location { get; set; }
}