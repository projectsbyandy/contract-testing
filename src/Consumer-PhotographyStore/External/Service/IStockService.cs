using Consumer_PhotographyStore.External.Models;
using Consumer_PhotographyStore.External.Models.StockServiceResponse;

namespace Consumer_PhotographyStore.External.Service;

public interface IStockService
{
    public StockServiceResponse GetAsync(FilmType filmType);
    public StockServiceResponse GetAllAsync();
}