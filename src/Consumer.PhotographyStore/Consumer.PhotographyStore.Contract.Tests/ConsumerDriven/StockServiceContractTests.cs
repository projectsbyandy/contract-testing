using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using CommonCSharp;
using CommonCSharp.Models;
using Consumer.PhotographyStore.Contract.Tests.PactHelper;
using Consumer.PhotographyStore.ThirdParty.Models.EmulsiveFactory;
using Consumer.PhotographyStore.ThirdParty.Services.Internal;
using FluentAssertions;
using NUnit.Framework;
using PactNet;
using PactNet.Matchers;
using HttpMethod = System.Net.Http.HttpMethod;

namespace Consumer.PhotographyStore.Contract.Tests.ConsumerDriven;

public class StockServiceContractTests
{
    private IPactBuilderV4 _pactBuilder;
    private bool _isBrokerEnabled;
    private const string FilmName = "Portra400";
    
    [SetUp]
    public void Setup()
    {
        _isBrokerEnabled = ConfigReader.GetConfigurationSection<BrokerConfiguration>("BrokerConfiguration").IsEnabled;
        
        Environment.SetEnvironmentVariable("PACT_DO_NOT_TRACK", "true");
        var pact = Pact.V4("PhotographyShop-CSharp", "EmulsiveFactory-StockApi", new PactConfig()
        {
            PactDir = PactUtils.ContractsLocation(ContractStrategy.ConsumerDriven)
        });
        _pactBuilder = pact.WithHttpInteractions();
    }

    [Test(Description= "Generates a Pact contract with Type Check")]
    public async Task StockService_Verify_Response_With_Type_Check()
    {
        // Given
        _pactBuilder?
            .UponReceiving("A request for a film is received")
                .Given("an Stock request is made with a film name")
                .WithRequest(HttpMethod.Get, $"/Stock/{FilmName}")
            .WillRespond()
                .WithStatus(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json; charset=utf-8")
                .WithJsonBody(new
                {
                    httpStatusCode = Match.Type(200),
                    result = new
                    {
                        film = new 
                        {
                            id = Match.Type(Guid.Parse("2dfe8135-8835-4107-b0b1-cf110c3b13b9")),
                            name = Match.Type(FilmName),
                            filmType = Match.Type(FilmType.ThirtyFive),
                            iso = Match.Number(400),
                            isActive = Match.Type(true),
                            manufacturer = new {
                                name = Match.Type("Kodak"),
                                location = Match.Type("USA"),
                                date = Match.Type(DateOnly.FromDateTime(DateTime.Today)),
                            }
                        },
                        stock = new
                        {
                            inStock = Match.Number(100),
                            onOrder = Match.Number(200)
                        }
                    }
                });

        Guard.Against.Null(_pactBuilder);
        await _pactBuilder.VerifyAsync(async ctx =>
        {
            // When
            var client = new StockService(new HttpClient()
            {
                BaseAddress = ctx.MockServerUri
            });
            
            var response = await client.GetStockForAsync(FilmName);

            // Then (NOTE we are verifying the mock data, these checks have no bearing on the data inside the generated Pact
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            
            response.Result.Should().NotBeNull();
            
            Assert.Multiple(() =>
            {
                response.Result?.Film?.Id.Should().Be(Guid.Parse("2dfe8135-8835-4107-b0b1-cf110c3b13b9"));
                response.Result?.Film?.Name.Should().Be(FilmName);
                response.Result?.Film?.Iso.Should().Be(400);
                response.Result?.Film?.isActive.Should().BeTrue();
                response.Result?.Film?.Manufacturer.Should().Be(new Manufacturer()
                {
                    Name = "Kodak",
                    Location = "USA",
                    Date = DateOnly.FromDateTime(DateTime.Today)
                });
                response.Result?.Stock?.InStock.Should().BeGreaterThan(1);
                response.Result?.Stock?.OnOrder.Should().Be(200);
            });
        });
    }

    [Test]
    public void TestViaBroker()
    {
        if (!_isBrokerEnabled)
        {
            _pactBuilder?
                .UponReceiving("A request for a film is received")
                .Given("an Stock request is made with a film name")
                .WithRequest(HttpMethod.Get, $"/Stock/{FilmName}")
                .WillRespond()
                .WithStatus(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json; charset=utf-8")
                .WithJsonBody(new
                {
                    httpStatusCode = Match.Type(200),
                    result = new
                    {
                        film = new 
                        {
                            id = Match.Type(Guid.Parse("2dfe8135-8835-4107-b0b1-cf110c3b13b9")),
                            name = Match.Type(FilmName),
                            filmType = Match.Type(FilmType.ThirtyFive),
                            iso = Match.Number(400),
                            isActive = Match.Type(true),
                            manufacturer = new {
                                name = Match.Type("Kodak"),
                                location = Match.Type("USA"),
                                date = Match.Type(DateOnly.FromDateTime(DateTime.Today)),
                            }
                        },
                        stock = new
                        {
                            inStock = Match.Number(100),
                            onOrder = Match.Number(200)
                        }
                    }
                });
            
            Assert.Ignore("Broker is not enabled. Test Ignored");
        }
        
        // TODO add test via broker
    }
}