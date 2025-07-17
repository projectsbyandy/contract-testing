using System.Text.Json.Serialization;

namespace PactBroker.Models;

public record ContractDetails
{
    [JsonPropertyName("consumerName")]
    public required string ConsumerName { get; init; }
    
    [JsonPropertyName("providerName")]
    public required string ProviderName { get; init; }
    
    [JsonPropertyName("specification")]
    public required string Specification { get; init; }
    
    [JsonPropertyName("contentType")]
    public required string ContentType { get; init; } = "application/json";
    
    [JsonPropertyName("content")]
    public required string Content { get; init; }
}