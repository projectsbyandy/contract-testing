using System.Text.Json.Serialization;

namespace Producer.EmulsiveFactory.Models.EmulsiveFactory.Response;

public class Person
{
    [JsonPropertyName("Name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("Email")]
    public string? Email { get; set; }
    
    [JsonPropertyName("Location")]
    public string? Location { get; set; }
}