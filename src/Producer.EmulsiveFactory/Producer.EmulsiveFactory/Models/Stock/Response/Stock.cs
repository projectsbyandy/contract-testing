using System.Text.Json.Serialization;

namespace Producer.EmulsiveFactory.Models.Stock.Response;

public class Stock
{
    [JsonPropertyName("inStock")]
    public int InStock { get; set; }
    
    [JsonPropertyName("onOrder")]
    public int OnOrder { get; set; }
}