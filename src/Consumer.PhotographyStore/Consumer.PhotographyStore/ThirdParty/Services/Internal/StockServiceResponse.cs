using System.Net;
using System.Text.Json.Serialization;

namespace Consumer.PhotographyStore.ThirdParty.Services.Internal;

public record StockServiceResponse<T>(HttpStatusCode HttpStatusCode)
{
    [JsonPropertyName("httpStatusCode")]
    public HttpStatusCode HttpStatusCode { get; } = HttpStatusCode;
    
    [JsonPropertyName("result")]
    public T? Result { get; set; }
}