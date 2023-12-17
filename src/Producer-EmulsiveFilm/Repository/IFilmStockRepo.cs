using Producer_EmulsiveFilm.Models.Stock.Response;

namespace Producer_EmulsiveFilm.Repository;

public interface IFilmStockRepo
{
    FilmStock? GetStockFor(string filmName);
}