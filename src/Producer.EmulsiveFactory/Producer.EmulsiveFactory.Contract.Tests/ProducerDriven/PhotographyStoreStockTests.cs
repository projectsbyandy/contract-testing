using System.Net;
using PactNet;
using PactNet.Matchers;
using Producer.EmulsiveFactory.Contract.Tests.Helpers;
using Producer.EmulsiveFactory.Contract.Tests.Models;
using Producer.EmulsiveFactory.Models;

namespace Producer.EmulsiveFactory.Contract.Tests.ProducerDriven;

public class PhotographyStoreStockTests
{
    private IPactBuilderV4? _pactBuilder;

    [SetUp]
    public void Setup()
    {
        var pact = Pact.V4("PhotographyShop", "EmulsiveFactory-StockApi", new PactConfig()
        {
            PactDir = PactUtils.ContractsLocation(ContractStrategy.Producer)
        });
        _pactBuilder = pact.WithHttpInteractions();
    }
    
    [Test(Description = "Producer Driven Contract Test")]
    public async Task Create_Contract_For_GetByManufacturerAndFilmName()
    {
        _pactBuilder?
            .UponReceiving("A Get Request to Retrieve the a Film by manufacturer name and film name")
            .Given("the ")
            .WithRequest(HttpMethod.Get, $"/Stock/")
            .WillRespond()
            .WithStatus(HttpStatusCode.OK)
            .WithHeader("Content-Type", "application/json; charset=utf-8")
            .WithJsonBody(new
            {
                httpStatusCode = Match.Type(200),
                filmStock = new
                {
                    film = new 
                    {
                        name = Match.Type("Fuji400H"),
                        filmType = Match.Type(FilmType.ThirtyFive)
                    },
                    stock = new
                    {
                        inStock = Match.Number(100),
                        onOrder = Match.Number(200)
                    }
                }
            });
        
        await _pactBuilder?.VerifyAsync(async ctx =>
        {
            // When
            // var client = new StockService(new HttpClient()
            // {
            //     BaseAddress = ctx.MockServerUri
            // });
            //
            // var response = await client.GetStockForAsync(filmName);
            //
            // // Then (NOTE we are verifying the mock data, these checks have no bearing on the data inside the generated Pact
            // response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            // response.FilmStock?.Film?.Name.Should().Be("Fuji400H");
            // response.FilmStock?.Stock?.InStock.Should().Be(100);
            // response.FilmStock?.Stock?.OnOrder.Should().Be(200);
        })!;
    }

}