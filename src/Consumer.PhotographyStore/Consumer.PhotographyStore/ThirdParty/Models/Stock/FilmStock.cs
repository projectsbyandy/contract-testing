using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Consumer.PhotographyStore.ThirdParty.Models.EmulsiveFactory;

namespace Consumer.PhotographyStore.ThirdParty.Models.Stock;

public class FilmStock
{
    [Required]
    [JsonPropertyName("film")]
    public Film? Film { get; set; }
    
    [Required]
    [JsonPropertyName("stock")]
    public Stock? Stock { get; set; }
}