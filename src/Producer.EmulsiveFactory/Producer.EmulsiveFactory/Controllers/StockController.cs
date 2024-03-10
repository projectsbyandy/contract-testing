using Microsoft.AspNetCore.Mvc;
using Producer.EmulsiveFactory.Repository;

namespace Producer.EmulsiveFactory.Controllers;

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
        
        return locatedItem is null 
            ? NotFound($"Stock for film name: {filmName} not found") 
            : Ok(locatedItem);
    }
}