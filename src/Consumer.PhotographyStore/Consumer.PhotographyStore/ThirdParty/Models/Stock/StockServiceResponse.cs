using System.Net;

namespace Consumer.PhotographyStore.ThirdParty.Models.Stock;

public record StockServiceResponse(HttpStatusCode HttpStatusCode)
{
    public HttpStatusCode HttpStatusCode { get; } = HttpStatusCode;
    public FilmStock? FilmStock { get; set; }
}