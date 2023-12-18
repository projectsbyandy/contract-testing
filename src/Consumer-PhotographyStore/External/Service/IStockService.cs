using Consumer_PhotographyStore.External.Models.Stock;

namespace Consumer_PhotographyStore.External.Service;

public interface IStockService
{
    public Task<FilmStock> GetStockForAsync(string filmName);
}