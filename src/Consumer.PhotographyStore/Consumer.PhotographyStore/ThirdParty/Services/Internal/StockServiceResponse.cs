using System.Net;
using System.Text.Json.Serialization;
using Consumer.PhotographyStore.ThirdParty.Models.Stock;

namespace Consumer.PhotographyStore.ThirdParty.Services.Internal;

public record StockServiceResponse(HttpStatusCode HttpStatusCode)
{
    [JsonPropertyName("httpStatusCode")]
    public HttpStatusCode HttpStatusCode { get; } = HttpStatusCode;
    
    [JsonPropertyName("filmStock")]
    public FilmStock? FilmStock { get; set; }
}