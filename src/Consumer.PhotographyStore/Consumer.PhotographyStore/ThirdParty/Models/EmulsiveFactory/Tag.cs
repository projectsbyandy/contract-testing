using System.Text.Json.Serialization;

namespace Consumer.PhotographyStore.ThirdParty.Models.EmulsiveFactory;

public class Tag
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}