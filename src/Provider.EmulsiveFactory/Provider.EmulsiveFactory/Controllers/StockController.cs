using Microsoft.AspNetCore.Mvc;
using Provider.EmulsiveFactory.Repository;

namespace Provider.EmulsiveFactory.Controllers;

[ApiController]
[Route("[controller]")]
public class StockController : ControllerBase
{
    private readonly IFilmStockRepo _filmStockRepo;

    public StockController(IFilmStockRepo filmStockRepo)
    {
        _filmStockRepo = filmStockRepo;
    }

    [HttpGet( "{filmName}")]
    public IActionResult GetStockFor(string filmName)
    {
        var locatedItem = _filmStockRepo.GetStockFor(filmName);
        
        ArgumentNullException.ThrowIfNull(locatedItem);
        
        // Breaking contract change 3 - additional validation in service
        // if (locatedItem.Result.Film.Manufacturer.Name.Equals(locatedItem.Result.Film.Name) is false)
        //     throw new DataException("Expect manufacturer name to equal film name");
        
        return locatedItem is null 
            ? NotFound($"Stock for film name: {filmName} not found") 
            : Ok(locatedItem);
    }
    
    [HttpGet]
    public IActionResult GetAllFilmStock()
    {
        var locatedItem = _filmStockRepo.GetAll();
        
        return locatedItem is null 
            ? NotFound($"Stock not found") 
            : Ok(locatedItem);
    }
}