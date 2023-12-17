using System.Text.Json.Serialization;

namespace Producer_EmulsiveFilm.Models.EmulsiveFilm.Response;

public class Tag
{
    [JsonPropertyName("Name")]
    public string? Name { get; set; }
}