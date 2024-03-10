using Producer.EmulsiveFactory.Models.Stock.Response;

namespace Producer.EmulsiveFactory.Repository;

public interface IFilmStockRepo
{
    StockServiceResponse? GetStockFor(string filmName);
}