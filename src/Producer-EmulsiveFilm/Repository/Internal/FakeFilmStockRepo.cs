using Producer_EmulsiveFilm.Models.Stock.Response;

namespace Producer_EmulsiveFilm.Repository.Internal;

public class FakeFilmStockRepo : IFilmStockRepo
{
    private readonly IFilmStore _filmStore;

    public FakeFilmStockRepo(IFilmStore filmStore)
    {
        _filmStore = filmStore;
    }

    public FilmStock? GetStockFor(string filmName)
    {
        var random = new Random();
        var film = _filmStore.GetAll().FirstOrDefault(film => film.Name!.Equals(filmName, StringComparison.InvariantCultureIgnoreCase));

        if (film is null) return null;
        
        return new FilmStock()
        {
            Film = film,
            Stock = new Stock()
            {
                OnOrder = random.Next(10),
                InStock = random.Next(1000)
            }
        };
    }
}