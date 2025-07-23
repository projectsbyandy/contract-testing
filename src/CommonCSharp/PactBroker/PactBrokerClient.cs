using System.Text;
using System.Text.Json;
using CommonCSharp.Models;
using CommonCSharp.PactBroker.Models;

namespace CommonCSharp.PactBroker;

public class PactBrokerClient
{
    public static string Endpoint
    {
        get
        {
            var server = ConfigReader
                .GetConfigurationSection<BrokerConfiguration>("BrokerConfiguration").Server;
            ArgumentException.ThrowIfNullOrEmpty(server);
            return server;
        }
    }

    public static async Task PublicContractsAsync(PublishContractRequest publishContractRequest)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(Endpoint);
        
        var response = await client.PostAsync("contracts/publish", new StringContent(
            JsonSerializer.Serialize(publishContractRequest), Encoding.UTF8, "application/json"));
        
        Console.WriteLine(await response.Content.ReadAsStringAsync());
        response.EnsureSuccessStatusCode();
    }
}