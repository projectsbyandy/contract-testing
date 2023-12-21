using Consumer.PhotographyStore.ThirdParty.Models.Stock;

namespace Consumer.PhotographyStore.ThirdParty;

public interface IStockService
{
    Task<StockServiceResponse> GetStockForAsync(string filmName);
}