using System.Text.Json.Serialization;

namespace CommonCSharp.PactBroker.Models;

/// <summary>
///  Represents the contract generated for verification
/// </summary>
public record ContractDetails
{
    /// <summary>
    /// Name of the consumer. Required.
    /// </summary>
    /// <remarks>Must match the pacticipant name and the consumer name inside the pact. While this field may seem redundant currently, this endpoint will be extended to support publication of provider generated, non-pact contracts, and the consumerName and providerName fields will be used to indicate which role the pacticipant is taking in the contract.</remarks>
    /// <example>ConsumerA</example>
    [JsonPropertyName("consumerName")]
    public required string ConsumerName { get; init; }
    
    /// <summary>
    /// Name of the provider. Required.
    /// </summary>
    /// <example>ProviderA</example>
    [JsonPropertyName("providerName")]
    public required string ProviderName { get; init; }

    /// <summary>
    /// Currently, only contracts of type "pact" are supported, but this will be extended in the future. Required.
    /// </summary>
    /// <example>pact</example>
    [JsonPropertyName("specification")]
    public required string Specification { get; init; }
    
    /// <summary>
    /// Currently, only contracts with a content type of "application/json" are supported. Required.
    /// </summary>
    /// <example>application/json</example>
    [JsonPropertyName("contentType")]
    public required string ContentType { get; init; }
    
    /// <summary>
    /// the content of the contract. Must be Base64 encoded. Required.
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; init; }
}