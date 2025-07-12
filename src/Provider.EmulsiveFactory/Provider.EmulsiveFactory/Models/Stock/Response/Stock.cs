using System.Text.Json.Serialization;

namespace Provider.EmulsiveFactory.Models.Stock.Response;

public record Stock
{
    // Breaking contract change 1 - Delete a property
    [JsonPropertyName("inStock")]
    public int InStock { get; init; }
    
    [JsonPropertyName("onOrder")]
    public int OnOrder { get; init; }
    
    // Breaking contract change 2 - change in property type
    // [JsonPropertyName("onOrder")]
    // public string OnOrder { get; init; }
}