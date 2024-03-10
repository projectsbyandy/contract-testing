using System.Net;
using System.Text.Json.Serialization;

namespace Producer.EmulsiveFactory.Models.Stock.Response;

public record StockServiceResponse(HttpStatusCode HttpStatusCode)
{
    [JsonPropertyName("httpStatusCode")]
    public HttpStatusCode HttpStatusCode { get; } = HttpStatusCode;
    
    [JsonPropertyName("filmStock")]
    public FilmStock? FilmStock { get; set; }
}