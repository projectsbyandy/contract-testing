using System.Text.Json.Serialization;

namespace Consumer.PhotographyStore.Models;

public class PhotographyStoreConfig
{
    [JsonPropertyName("FilmManufacturers")]
    public IList<string> FilmManufacturers { get; set; } = new List<string>();
}