using System.Net;
using System.Text.Json.Serialization;

namespace Provider.EmulsiveFactory.Models.Stock.Response;

public record StockServiceResponse<T>(HttpStatusCode HttpStatusCode)
{
    [JsonPropertyName("httpStatusCode")]
    public HttpStatusCode HttpStatusCode { get; } = HttpStatusCode;
    
    [JsonPropertyName("result")]
    public T? Result { get; set; }
}