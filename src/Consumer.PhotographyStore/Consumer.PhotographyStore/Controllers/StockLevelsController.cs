using System.Net;
using Ardalis.GuardClauses;
using Consumer.PhotographyStore.Models;
using Consumer.PhotographyStore.ThirdParty.Models.EmulsiveFactory;
using Consumer.PhotographyStore.ThirdParty.Models.Stock;
using Consumer.PhotographyStore.ThirdParty.Services;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.PhotographyStore.Controllers;

[ApiController]
[Route("[controller]")]
public class StockLevelsController : ControllerBase
{
    private readonly IStockService _stockService;
    private readonly IEmulsiveFactoryService _emulsiveFactoryService;
    private readonly PhotographyStoreConfig _photographyStoreConfig;
    
    public StockLevelsController(IStockService stockService, IEmulsiveFactoryService emulsiveFactoryService, PhotographyStoreConfig photographyStoreConfig)
    {
        _stockService = stockService;
        _emulsiveFactoryService = emulsiveFactoryService;
        _photographyStoreConfig = photographyStoreConfig;
    }

    [HttpGet]
    public async Task<IActionResult> AllFilmAsync()
    {
        var filmStocks = new List<FilmStock?>();

        var allFilm = await GetFilmFromFactoryAsync();

        var supportedFilms = allFilm.Where(film => Guard.Against.Null(_photographyStoreConfig.FilmManufacturers).Contains(Guard.Against.Null(film.Manufacturer?.Name)));
        
        supportedFilms.ToList().ForEach(supportedFilm =>
        {
            Guard.Against.Null(supportedFilm.Name);
            var stockResponse =  _stockService.GetStockForAsync(supportedFilm.Name).Result;
            if (stockResponse.HttpStatusCode is HttpStatusCode.OK)
                filmStocks.Add(stockResponse.Result);
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