using System.Net;
using Ardalis.GuardClauses;
using Consumer.PhotographyStore.ThirdParty;
using Consumer.PhotographyStore.ThirdParty.Models.EmulsiveFactory;
using Consumer.PhotographyStore.ThirdParty.Models.Stock;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.PhotographyStore.Controllers;

[ApiController]
[Route("[controller]")]
public class StockLevelsController : ControllerBase
{
    private readonly IStockService _stockService;
    private readonly IEmulsiveFactoryService _emulsiveFactoryService;
    
    public readonly string[] FilmManufacturersWeStock = {"Kodak", "Cinestill","adadadada"};
    
    public StockLevelsController(IStockService stockService, IEmulsiveFactoryService emulsiveFactoryService)
    {
        _stockService = stockService;
        _emulsiveFactoryService = emulsiveFactoryService;
    }

    [HttpGet]
    public async Task<IActionResult> AllFilm()
    {
        var filmStocks = new List<FilmStock?>();

        var allFilm = await GetFilmFromFactoryAsync();

        var supportedFilms = allFilm.Where(film => FilmManufacturersWeStock.Contains(film.Manufacturer?.Name));
        
        supportedFilms.ToList().ForEach(supportedFilm =>
        {
            Guard.Against.Null(supportedFilm.Name);
            var stockResponse =  _stockService.GetStockForAsync(supportedFilm.Name).Result;
            if (stockResponse.HttpStatusCode is HttpStatusCode.OK)
                filmStocks.Add(stockResponse.FilmStock);
        });

        return filmStocks.Count == 0 
            ? NotFound()
            : Ok(filmStocks);
    }

    private async Task<IEnumerable<Film>> GetFilmFromFactoryAsync()
    {
        return await _emulsiveFactoryService.GetAllFilmAsync();
    }
}