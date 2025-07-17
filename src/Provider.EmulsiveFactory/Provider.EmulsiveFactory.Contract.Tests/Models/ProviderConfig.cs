using System.Text.Json.Serialization;

namespace Provider.EmulsiveFactory.Contract.Tests.Models;

internal record ProviderConfig
{ 
    [JsonPropertyName("serviceUrl")]
    public string? ServiceUrl { get; init; }
}