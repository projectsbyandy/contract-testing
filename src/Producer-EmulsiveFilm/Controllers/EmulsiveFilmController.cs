using Microsoft.AspNetCore.Mvc;
using Producer_EmulsiveFilm.Models;
using Producer_EmulsiveFilm.Models.EmulsiveFilm.Response;
using Producer_EmulsiveFilm.Repository;
using ILogger = Serilog.ILogger;

namespace Producer_EmulsiveFilm.Controllers;

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
    public IEnumerable<Film> GetFilm(FilmType filmType)
    {
        var locatedItems =_filmStore.GetAll().Where(f => f.FilmType == filmType);
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