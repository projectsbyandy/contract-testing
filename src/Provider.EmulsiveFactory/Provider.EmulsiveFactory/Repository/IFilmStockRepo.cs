using Provider.EmulsiveFactory.Models.Stock.Response;

namespace Provider.EmulsiveFactory.Repository;

public interface IFilmStockRepo
{
    StockServiceResponse<FilmStock>? GetStockFor(string filmName);
    StockServiceResponse<IList<FilmStock>>? GetAll();

}