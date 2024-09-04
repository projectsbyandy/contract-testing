using Producer.EmulsiveFactory.Models.Stock.Response;

namespace Producer.EmulsiveFactory.Repository;

public interface IFilmStockRepo
{
    StockServiceResponse<FilmStock>? GetStockFor(string filmName);
    StockServiceResponse<IList<FilmStock>>? GetAll();

}