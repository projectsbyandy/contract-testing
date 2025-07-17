using System.Text;
using System.Text.Json;
using CommonCSharp.Models;
using PactBroker.Models;

namespace CommonCSharp.PactBroker;

public class PactBrokerClient
{ 
    public static async Task PublicContractsAsync(PublishContractRequest publishContractRequest)
    {
        var brokerServer = ConfigReader.GetConfigurationSection<BrokerConfiguration>("BrokerConfiguration").Server;
        
        ArgumentException.ThrowIfNullOrEmpty(brokerServer);

        using var client = new HttpClient() { BaseAddress = new Uri(brokerServer) };
        var response = await client.PostAsync("contracts/publish", new StringContent(
            JsonSerializer.Serialize(publishContractRequest), Encoding.UTF8, "application/json"));
        
        Console.WriteLine(await response.Content.ReadAsStringAsync());
        response.EnsureSuccessStatusCode();
    }
}