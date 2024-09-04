using System.Net;
using System.Text.Json.Serialization;
using Consumer.PhotographyStore.ThirdParty.Models.Stock;

namespace Consumer.PhotographyStore.ThirdParty.Services.Internal;

public record StockServiceResponse<T>(HttpStatusCode HttpStatusCode)
{
    [JsonPropertyName("httpStatusCode")]
    public HttpStatusCode HttpStatusCode { get; } = HttpStatusCode;
    
    [JsonPropertyName("filmStock")]
    public T? Result { get; set; }
}