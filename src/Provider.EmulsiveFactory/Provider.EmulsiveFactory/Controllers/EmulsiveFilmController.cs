using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using Provider.EmulsiveFactory.Models;
using Provider.EmulsiveFactory.Models.EmulsiveFactory.Response;
using Provider.EmulsiveFactory.Repository;
using ILogger = Serilog.ILogger;

namespace Provider.EmulsiveFactory.Controllers;

[ApiController]
[Route("[controller]")]
public class EmulsiveFilmController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IFilmStore _filmStore;
    
    public EmulsiveFilmController(ILogger logger, IFilmStore filmStore)
    {
        _logger = logger;
        _filmStore = filmStore;
    }

    [HttpGet( "{filmType}")]
    public IEnumerable<Film> GetFilmByType(FilmType filmType)
    {
        var locatedItems =_filmStore.GetAll().Where(f => f.FilmType == filmType);
        _logger.Information("Located film {@Film}", locatedItems);
        
        return locatedItems;
    }
    
    [HttpGet( "{manufacturer}/{filmName}")]
    public IEnumerable<Film> GetByManufacturerAndFilmName(string manufacturer, string filmName)
    {
        var locatedItems =_filmStore.GetAll()
            .Where(film => Guard.Against.Null(film.Manufacturer.Name).Equals(manufacturer)
                                                            && film.Name!.Equals(filmName));
        _logger.Information("Located film {@Film}", locatedItems);
        
        return locatedItems;
    }

    [HttpGet]
    public IEnumerable<Film> GetAllFilm()
    {
        var films = _filmStore.GetAll();
        _logger.Information("Located film {@Film}", films);

        return films;
    }
}