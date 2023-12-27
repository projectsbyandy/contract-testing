using Consumer.PhotographyStore.ThirdParty.Services.Internal;

namespace Consumer.PhotographyStore.ThirdParty.Services;

public interface IStockService
{
    Task<StockServiceResponse> GetStockForAsync(string filmName);
}