using PactNet.Verifier;
using Provider.EmulsiveFactory.Contract.Tests.Fixtures;
using Provider.EmulsiveFactory.Contract.Tests.Helpers;
using Provider.EmulsiveFactory.Contract.Tests.Models;

namespace Provider.EmulsiveFactory.Contract.Tests.ConsumerDriven;

public class PhotographyStoreStockTests : StockServiceFixture
{
    private PactVerifierConfig _config;
    private readonly string _pactContractsFolder = PactUtils.ContractsLocation(ContractStrategy.ConsumerDriven);

    [SetUp]
    public void Setup()
    {
        Environment.SetEnvironmentVariable("PACT_DO_NOT_TRACK", "true");
        _config = new PactVerifierConfig();
    }
    
    [Test(Description = "Consumer Driven Contract Test. Generated from Photography Store")]
    public void Verify_Alignment_With_Consumer_Photography_Shop_CSharp_Contract()
    {
        // Given
        var contractPactPath = $"{_pactContractsFolder}{Path.DirectorySeparatorChar}PhotographyShop-CSharp-EmulsiveFactory-StockApi.json";

        // When / Then
        using var pactVerifier = new PactVerifier("StockApi", _config);
        
        pactVerifier
            .WithHttpEndpoint(ServiceUri)
            .WithFileSource(new FileInfo(contractPactPath))
            .WithCustomHeader("Content-Type", "application/json; charset=utf-8")
            .Verify();
    }
    
    [Test(Description = "Consumer Driven Contract Test. Generated from FilmMuseum JS")]
    public void Verify_Alignment_With_Consumer_FilmMuseum_JS_Contract()
    {
        // Given
        var contractPactPath = $"{_pactContractsFolder}{Path.DirectorySeparatorChar}FilmMuseum-StockServiceApi-Js-EmulsiveFactory-StockApi.json";

        // When / Then
        using var pactVerifier = new PactVerifier("EmulsiveFactory-StockApi", _config);
        
        pactVerifier
            .WithHttpEndpoint(ServiceUri)
            .WithFileSource(new FileInfo(contractPactPath))
            .WithCustomHeader("Content-Type", "application/json; charset=utf-8")
            .Verify();
    }
    
    [Test(Description = "Consumer Driven Contract Test. Generated from Film Developer Service Python")]
    public void Verify_Alignment_With_Film_Developer_Python_Contract()
    {
        // Given
        var contractPactPath = $"{_pactContractsFolder}{Path.DirectorySeparatorChar}developerservice-python-emulsivefactory-stockapi.json";

        // When / Then
        using var pactVerifier = new PactVerifier("StockApi", _config);
        
        pactVerifier
            .WithHttpEndpoint(ServiceUri)
            .WithFileSource(new FileInfo(contractPactPath))
            .WithCustomHeader("Content-Type", "application/json; charset=utf-8")
            .Verify();
    }
}