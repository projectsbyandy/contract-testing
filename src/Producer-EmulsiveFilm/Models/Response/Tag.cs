using System.Text.Json.Serialization;

namespace Producer_EmulsiveFilm.Models.Response;

public class Tag
{
    [JsonPropertyName("Name")]
    public string? Name { get; set; }
}