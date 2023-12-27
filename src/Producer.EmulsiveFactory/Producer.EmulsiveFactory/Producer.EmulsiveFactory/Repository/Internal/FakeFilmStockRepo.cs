using System.Net;
using Producer.EmulsiveFactory.Models.Stock.Response;

namespace Producer.EmulsiveFactory.Repository.Internal;

public class FakeFilmStockRepo : IFilmStockRepo
{
    private readonly IFilmStore _filmStore;

    public FakeFilmStockRepo(IFilmStore filmStore)
    {
        _filmStore = filmStore;
    }

    public StockServiceResponse? GetStockFor(string filmName)
    {
        var random = new Random();
        var film = _filmStore.GetAll().FirstOrDefault(film => film.Name!.Equals(filmName, StringComparison.InvariantCultureIgnoreCase));

        if (film is null) return null;
        
        return new StockServiceResponse(HttpStatusCode.OK)
        {
            FilmStock = new()
            {
                Film = film,
                Stock = new Stock()
                {
                    OnOrder = random.Next(10),
                    InStock = random.Next(1000)
                }
            }
        };
    }
}