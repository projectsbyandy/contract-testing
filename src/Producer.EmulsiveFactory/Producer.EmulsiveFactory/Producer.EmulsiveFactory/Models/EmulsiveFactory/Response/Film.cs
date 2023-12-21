using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Producer.EmulsiveFactory.Models.EmulsiveFactory.Response;

public class Film
{
    [Required]
    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    [JsonPropertyName("FilmType")]
    public FilmType FilmType { get; set; }
    
    [JsonPropertyName("Id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("Manufacturer")]
    public Manufacturer? Manufacturer { get; set; }
    
    [JsonPropertyName("Contacts")]
    public IList<Person>? Contacts { get; set; }
    
    [JsonPropertyName("Tags")]
    public IList<Tag>? Tags { get; set; }
}