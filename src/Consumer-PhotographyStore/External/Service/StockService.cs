using Consumer_PhotographyStore.External.Models;
using Consumer_PhotographyStore.External.Models.StockServiceResponse;

namespace Consumer_PhotographyStore.External.Service;

public class StockService : IStockService
{
    private readonly HttpClient _httpClient;

    public StockService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public StockServiceResponse GetAsync(FilmType filmType)
    {
        throw new NotImplementedException();
    }

    public StockServiceResponse GetAllAsync()
    {
        throw new NotImplementedException();
    }
}