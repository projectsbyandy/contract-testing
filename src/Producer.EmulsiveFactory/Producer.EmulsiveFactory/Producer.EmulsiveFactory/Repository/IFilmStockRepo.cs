using Producer.EmulsiveFactory.Models.Stock.Response;

namespace Producer.EmulsiveFactory.Repository;

public interface IFilmStockRepo
{
    FilmStock? GetStockFor(string filmName);
}