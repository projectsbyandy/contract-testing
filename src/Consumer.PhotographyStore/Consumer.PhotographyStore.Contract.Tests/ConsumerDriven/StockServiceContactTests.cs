using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Consumer.PhotographyStore.Contract.Tests.Models;
using Consumer.PhotographyStore.Contract.Tests.PactHelper;
using Consumer.PhotographyStore.ThirdParty.Services.Internal;
using FluentAssertions;
using NUnit.Framework;
using PactNet;
using PactNet.Matchers;
using HttpMethod = System.Net.Http.HttpMethod;

namespace Consumer.PhotographyStore.Contract.Tests.ConsumerDriven;

public class StockServiceContractTests
{
    private IPactBuilderV4? _pactBuilder;

    [SetUp]
    public void Setup()
    {
        var pact = Pact.V4("PhotographyShop", "EmulsiveFactory StockApi", new PactConfig()
        {
            PactDir = PactUtils.ContractsLocation(ContractStrategy.Consumer)
        });
        _pactBuilder = pact.WithHttpInteractions();
    }

    [Test(Description= "Generates a Pact contract with Type Check")]
    public async Task StockService_Verify_Response_With_Type_Check()
    {
        // Given
        const string filmName = "Portra400";
        
        _pactBuilder?
            .UponReceiving("An opinion service request")
                .Given("an Stock request is made with a film name")
                .WithRequest(HttpMethod.Get, $"/Stock/{filmName}")
            .WillRespond()
                .WithStatus(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json; charset=utf-8")
                .WithJsonBody(new
                {
                    httpStatusCode = Match.Type(200)
                });
        
        await _pactBuilder?.VerifyAsync(async ctx =>
        {
            // When
            var client = new StockService(new HttpClient()
            {
                BaseAddress = ctx.MockServerUri
            });
            
            var response = await client.GetStockForAsync(filmName);

            // Then (NOTE we are verifying the mock data, these checks have no bearing on the data inside the generated Pact
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        })!;
    }
}