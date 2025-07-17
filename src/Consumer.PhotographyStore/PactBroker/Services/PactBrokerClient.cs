using System.Text;
using System.Text.Json;
using Ardalis.GuardClauses;
using Consumer.Support;
using PactBroker.Models;

namespace PactBroker.Services;

public class PactBrokerClient
{ 
    public static async Task PublicContractsAsync(PublishContractRequest publishContractRequest)
    {
        var brokerServer = Guard.Against.Null(ConfigReader.GetConfigurationSection<BrokerConfiguration>("BrokerConfiguration").Server);

        using var client = new HttpClient() { BaseAddress = new Uri(brokerServer) };
        var response = await client.PostAsync("contracts/publish", new StringContent(
            JsonSerializer.Serialize(publishContractRequest), Encoding.UTF8, "application/json"));
        
        Console.WriteLine(await response.Content.ReadAsStringAsync());
        response.EnsureSuccessStatusCode();
    }
}