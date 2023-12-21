using System.Text.Json.Serialization;

namespace Producer.EmulsiveFactory.Models.Stock.Response;

public class Stock
{
    [JsonPropertyName("InStock")]
    public int InStock { get; set; }
    
    [JsonPropertyName("OnOrder")]
    public int OnOrder { get; set; }
}