using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Producer_EmulsiveFilm.Models.EmulsiveFilm.Response;

namespace Producer_EmulsiveFilm.Models.Stock.Response;

public class FilmStock
{
    [Required]
    [JsonPropertyName("Film")]
    public Film Film { get; set; }
    
    [Required]
    [JsonPropertyName("Stock")]
    public Stock Stock { get; set; }
}