namespace PactBroker.Models;

public record BrokerConfiguration
{
    public bool IsEnabled { get; init; }
    public string? Server { get; init; }
}