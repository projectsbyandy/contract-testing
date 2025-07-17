using System.Text.Json.Serialization;

namespace PactBroker.Models;

/// <summary>
///  Represents a request to publish a consumer contract to Pact Broker
/// </summary>
/// <remarks>
///  The model is aligned to the current schema defined for the contracts/publish endpoint in API Browser
/// </remarks>
public record PublishContractRequest
{
    /// <summary>
    /// The name of the application. Required.
    /// </summary>
    /// <example>ConsumerA</example>
    [JsonPropertyName("pacticipantName")]
    public required string PacticipantName { get; init; }
    
    /// <summary>
    /// The version number of the application. Required. It is recommended that this should be or include the git SHA.
    /// </summary>
    /// <example></example>
    [JsonPropertyName("pacticipantVersionNumber")]
    public required string PacticipantVersion { get; init; }

    [JsonPropertyName("branch")]
    public string? Branch { get; init; }
    
    [JsonPropertyName("tags")]
    public string[]? Tags { get; init; }
    
    [JsonPropertyName("buildUrl")]
    public string? BuildUrl { get; init; }
    
    [JsonPropertyName("contracts")]
    public required ContractDetails[] Contracts { get; init; }
}