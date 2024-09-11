using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Producer.EmulsiveFactory.Models.EmulsiveFactory.Response;

public class Film
{
    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("filmType")]
    public FilmType FilmType { get; set; } = default!;
    
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("manufacturer")]
    public Manufacturer Manufacturer { get; set; } = default!;
    
    [JsonPropertyName("contacts")]
    public IList<Person> Contacts { get; set; } = default!;
    
    [JsonPropertyName("tags")]
    public IList<Tag> Tags { get; set; } = default!;
}