using System.Data;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Provider.EmulsiveFactory.Repository;
using ILogger = Serilog.ILogger;

namespace Provider.EmulsiveFactory.Controllers;

[ApiController]
// Breaking contract change 4 - adding authorisation when it is not expected
// [Authorize]
[Route("[controller]")]
public class StockController : ControllerBase
{
    private readonly IFilmStockRepo _filmStockRepo;
    private readonly ILogger _logger;

    public StockController(IFilmStockRepo filmStockRepo, ILogger logger)
    {
        _filmStockRepo = filmStockRepo;
        _logger = logger;
    }

    [HttpGet( "{filmName}")]
    public IActionResult GetStockFor(string filmName)
    {
        // This is required to make [Required] attributes work
        if (!ModelState.IsValid)
        {
            _logger.Error("[VALIDATION_FAILED] ModelState validation failed");
        
            // Log specific validation errors
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                _logger.Error($"[VALIDATION_ERROR] {error.ErrorMessage}");
            }
        
            return BadRequest(ModelState);
        }
        
        var locatedItem = _filmStockRepo.GetStockFor(filmName);
        
        // Breaking contract change 3 - additional validation in service
        // Guard.Against.Null(locatedItem);
        // if (locatedItem.Result?.Film?.Manufacturer.Name?.Equals(locatedItem.Result.Film.Name) is false) {
        //     _logger.Error("Problem getting stock for {@LocatedItem}", locatedItem);
        //     throw new DataException("Expect manufacturer name to equal film name");
        // }
        
        _logger.Information("Get stock for {@LocatedItem}", locatedItem);
        
        return locatedItem is null 
            ? NotFound($"Stock for film name: {filmName} not found") 
            : Ok(locatedItem);
    }
    
    [HttpGet]
    public IActionResult GetAllFilmStock()
    {
        var filmsStocks = _filmStockRepo.GetAll();
        
        _logger.Information("Retrieved Films {@Films}", filmsStocks);
        
        return filmsStocks is null 
            ? NotFound($"Stock not found") 
            : Ok(filmsStocks);
    }
}