using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Consumer.PhotographyStore.ThirdParty.Models.EmulsiveFactory;

public class Film
{
    [Required]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("filmType")]
    public FilmType FilmType { get; set; }
    
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("manufacturer")]
    public Manufacturer? Manufacturer { get; set; }
    
    [JsonPropertyName("contacts")]
    public IList<Person>? Contacts { get; set; }
    
    [JsonPropertyName("tags")]
    public IList<Tag>? Tags { get; set; }
}