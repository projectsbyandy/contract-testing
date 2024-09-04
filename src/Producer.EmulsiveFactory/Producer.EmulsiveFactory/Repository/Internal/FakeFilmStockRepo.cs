using System.Net;
using Producer.EmulsiveFactory.Models.Stock.Response;

namespace Producer.EmulsiveFactory.Repository.Internal;

public class FakeFilmStockRepo : IFilmStockRepo
{
    private readonly IFilmStore _filmStore;
    private readonly Random _random = new();

    public FakeFilmStockRepo(IFilmStore filmStore)
    {
        _filmStore = filmStore;
    }

    public StockServiceResponse<FilmStock>? GetStockFor(string filmName)
    {
        var film = _filmStore.GetAll().FirstOrDefault(film => film.Name!.Equals(filmName, StringComparison.InvariantCultureIgnoreCase));

        if (film is null) return null;
        
        return new StockServiceResponse<FilmStock>(HttpStatusCode.OK)
        {
            Result = new()
            {
                Film = film,
                Stock = new Stock()
                {
                    OnOrder = _random.Next(10),
                    InStock = _random.Next(1000)
                }
            }
        };
    }

    public StockServiceResponse<IList<FilmStock>>? GetAll()
    {
        IList<FilmStock> filmStocks = new List<FilmStock>();

        var films = _filmStore.GetAll();
        films.ForEach(film =>
        {
            filmStocks.Add(new FilmStock()
            {
                Film = film,
                Stock = new Stock()
                {
                    OnOrder = _random.Next(10),
                    InStock = _random.Next(1000)
                }
            });
        });

        return new StockServiceResponse<IList<FilmStock>>(HttpStatusCode.OK)
        {
            Result = filmStocks
        };
    }
}