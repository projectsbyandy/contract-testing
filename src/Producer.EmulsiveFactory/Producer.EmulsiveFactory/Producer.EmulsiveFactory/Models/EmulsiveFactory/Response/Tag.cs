using System.Text.Json.Serialization;

namespace Producer.EmulsiveFactory.Models.EmulsiveFactory.Response;

public class Tag
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}