using Consumer.PhotographyStore.ThirdParty.Models.Stock;
using Consumer.PhotographyStore.ThirdParty.Services.Internal;

namespace Consumer.PhotographyStore.ThirdParty.Services;

public interface IStockService
{
    Task<StockServiceResponse<FilmStock>> GetStockForAsync(string filmName);
}