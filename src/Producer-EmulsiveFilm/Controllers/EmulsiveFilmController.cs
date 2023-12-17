using Microsoft.AspNetCore.Mvc;
using Producer_EmulsiveFilm.Models;
using Producer_EmulsiveFilm.Models.Response;
using Producer_EmulsiveFilm.Repository;

namespace Producer_EmulsiveFilm.Controllers;

[ApiController]
[Route("[controller]")]
public class EmulsiveFilmController : ControllerBase
{
    private readonly ILogger<EmulsiveFilmController> _logger;
    private readonly IFilmStore _filmStore;
    
    public EmulsiveFilmController(ILogger<EmulsiveFilmController> logger, IFilmStore filmStore)
    {
        _logger = logger;
        _filmStore = filmStore;
    }

    [HttpGet( "{filmType}")]
    public IEnumerable<Film> GetFilm(FilmType filmType)
    {
        var locatedItems =_filmStore.GetAll().Where(f => f.FilmType == filmType);
        _logger.LogInformation("Located film {@Film}", locatedItems);
        
        return locatedItems;
    }

    [HttpGet]
    public IEnumerable<Film> GetAllFilm()
    {
        var films = _filmStore.GetAll();
        _logger.LogInformation("Located film {@Film}", films);

        return films;
    }
}