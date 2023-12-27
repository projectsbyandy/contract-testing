using System.Text.Json.Serialization;

namespace Consumer.PhotographyStore.ThirdParty.Models.Stock;

public class Stock
{
    [JsonPropertyName("inStock")]
    public int InStock { get; set; }
    
    [JsonPropertyName("onOrder")]
    public int OnOrder { get; set; }
}