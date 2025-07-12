using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Provider.EmulsiveFactory.Models.EmulsiveFactory.Response;

public class Film
{
    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("filmType")]
    public FilmType FilmType { get; set; }

    [JsonPropertyName("processingType")]
    public string ProcessingType { get; set; } = default!;
    
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("iso")]
    public int Iso { get; set; }
    
    [JsonPropertyName("isActive")]
    public Boolean isActive { get; set; }
    
    [JsonPropertyName("manufacturer")]
    public Manufacturer Manufacturer { get; set; } = default!;
    
    [JsonPropertyName("contacts")]
    public IList<Person> Contacts { get; set; } = default!;
    
    [JsonPropertyName("tags")]
    public IList<Tag> Tags { get; set; } = default!;
}