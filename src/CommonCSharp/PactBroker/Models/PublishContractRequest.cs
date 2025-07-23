using System.Text.Json.Serialization;

namespace CommonCSharp.PactBroker.Models;

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
    /// The version number of the application. Required.
    /// </summary>
    /// <remarks>It is recommended that this should be or include the git SHA.</remarks>
    /// <example></example>
    [JsonPropertyName("pacticipantVersionNumber")]
    public required string PacticipantVersion { get; init; }

    /// <summary>
    /// The git branch name. Optional.
    /// </summary>
    /// <example>main</example>
    [JsonPropertyName("branch")]
    public string? Branch { get; init; }
    
    /// <summary>
    /// The consumer version tags. Use of the branch parameter is preferred now. Optional.
    /// </summary>
    /// <example>["main"]</example>
    [JsonPropertyName("tags")]
    public string[]? Tags { get; init; }
    
    /// <summary>
    /// The CI/CD build URL. Optional.
    /// </summary>
    /// <example>https://ci/builds/1234</example>
    [JsonPropertyName("buildUrl")]
    public string? BuildUrl { get; init; }
    
    /// <summary>
    /// Contracts. Required.
    /// </summary>
    /// <example>Add your contract to the list</example>
    [JsonPropertyName("contracts")]
    public required ContractDetails[] Contracts { get; init; }
}