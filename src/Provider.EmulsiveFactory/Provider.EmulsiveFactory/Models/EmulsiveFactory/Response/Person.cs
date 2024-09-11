using System.Text.Json.Serialization;

namespace Provider.EmulsiveFactory.Models.EmulsiveFactory.Response;

public class Person
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    
    [JsonPropertyName("location")]
    public string? Location { get; set; }
}