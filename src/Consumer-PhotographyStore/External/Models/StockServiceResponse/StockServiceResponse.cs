using System.Net;
using Consumer_PhotographyStore.External.Models.FilmResponse;

namespace Consumer_PhotographyStore.External.Models.StockServiceResponse;

public class StockServiceResponse
{
    public HttpStatusCode HttpStatusCode { get; set; }
    public Film? Film { get; set; } = default;
}