using System.Text.Json.Serialization;

namespace Producer.EmulsiveFactory.Models.EmulsiveFactory.Response;

public class Tag
{
    [JsonPropertyName("Name")]
    public string? Name { get; set; }
}