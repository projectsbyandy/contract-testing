using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Provider.EmulsiveFactory.Models.EmulsiveFactory.Response;

public record Film
{
    [Required]
    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("filmType")]
    public FilmType FilmType { get; init; }

    [JsonPropertyName("processingType")]
    public string ProcessingType { get; init; } = default!;
    
    [JsonPropertyName("id")]
    public Guid Id { get; init; }
    
    [JsonPropertyName("iso")]
    public int Iso { get; init; }
    
    [JsonPropertyName("isActive")]
    public bool isActive { get; init; }
    
    [JsonPropertyName("manufacturer")]
    public Manufacturer Manufacturer { get; init; } = default!;
    
    [JsonPropertyName("contacts")]
    public IList<Person> Contacts { get; init; } = default!;
    
    [JsonPropertyName("tags")]
    public IList<Tag> Tags { get; init; } = default!;
}