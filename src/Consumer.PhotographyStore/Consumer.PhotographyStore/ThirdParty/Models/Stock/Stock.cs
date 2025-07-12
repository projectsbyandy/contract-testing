using System.Text.Json.Serialization;

namespace Consumer.PhotographyStore.ThirdParty.Models.Stock;

public record Stock
{
    [JsonPropertyName("inStock")]
    public int InStock { get; init; }
    
    [JsonPropertyName("onOrder")]
    public int OnOrder { get; init; }
}