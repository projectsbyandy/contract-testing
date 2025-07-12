using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Consumer.PhotographyStore.ThirdParty.Models.EmulsiveFactory;

public record Film
{
    [Required]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("filmType")]
    public FilmType FilmType { get; init; }
    
    [JsonPropertyName("processingType")]
    public string ProcessingType { get; init; } = default!;
    
    [JsonPropertyName("id")]
    public Guid Id { get; init; }
    
    [JsonPropertyName("iso")]
    public int Iso { get; init; }
    
    [JsonPropertyName("isActive")]
    public Boolean isActive { get; init; }
    
    [JsonPropertyName("manufacturer")]
    public Manufacturer? Manufacturer { get; init; }
    
    [JsonPropertyName("contacts")]
    public IList<Person>? Contacts { get; init; }
    
    [JsonPropertyName("tags")]
    public IList<Tag>? Tags { get; init; }
}