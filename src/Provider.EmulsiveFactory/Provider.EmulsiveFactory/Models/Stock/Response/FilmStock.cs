using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Provider.EmulsiveFactory.Models.EmulsiveFactory.Response;

namespace Provider.EmulsiveFactory.Models.Stock.Response;

public class FilmStock
{
    [Required]
    [JsonPropertyName("film")]
    public Film? Film { get; set; }
    
    [Required]
    [JsonPropertyName("stock")]
    public Stock? Stock { get; set; }
}