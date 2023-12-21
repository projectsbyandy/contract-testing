using System.Text.Json.Serialization;

namespace Consumer.PhotographyStore.ThirdParty.Models.Stock;

public class Stock
{
    [JsonPropertyName("InStock")]
    public int InStock { get; set; }
    
    [JsonPropertyName("OnOrder")]
    public int OnOrder { get; set; }
}