using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Consumer_PhotographyStore.External.Models.EmulsiveFilm;

namespace Consumer_PhotographyStore.External.Models.Stock;

public class FilmStock
{
    [Required]
    [JsonPropertyName("Film")]
    public Film Film { get; set; }
    
    [Required]
    [JsonPropertyName("Stock")]
    public Stock Stock { get; set; }
}