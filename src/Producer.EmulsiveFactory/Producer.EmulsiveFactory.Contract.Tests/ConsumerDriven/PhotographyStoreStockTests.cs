using PactNet.Verifier;
using Producer.EmulsiveFactory.Contract.Tests.Fixtures;
using Producer.EmulsiveFactory.Contract.Tests.Helpers;
using Producer.EmulsiveFactory.Contract.Tests.Models;

namespace Producer.EmulsiveFactory.Contract.Tests.ConsumerDriven;

public class PhotographyStoreStockTests : StockServiceFixture
{
    [Test(Description = "Consumer Driven Contract Test")]
    public void Verify_Alignment_With_Consumer_Photography_Shop_Contract()
    {
        // Given
        var pactContractsPath = PactUtils.ContractsLocation(ContractStrategy.Consumer);

        var config = new PactVerifierConfig();
        var contractPactPath = $"{pactContractsPath}{Path.DirectorySeparatorChar}PhotographyShop-EmulsiveFactory-StockApi.json";

        // When / Then
        using var pactVerifier = new PactVerifier("StockApi", config);
        
        pactVerifier
            .WithHttpEndpoint(ServiceUri)
            .WithFileSource(new FileInfo(contractPactPath))
            .WithCustomHeader("Content-Type", "application/json; charset=utf-8")
            .Verify();
    }
    
    [Test(Description = "Consumer Driven Contract Test. Generated from Stock Service JS")]
    public void Verify_Alignment_With_Stock_Service_Contract()
    {
        // Given
        var pactContractsPath = PactUtils.ContractsLocation(ContractStrategy.Consumer);

        var config = new PactVerifierConfig();
        var contractPactPath = $"{pactContractsPath}{Path.DirectorySeparatorChar}StockServiceApiJs-EmulsiveFactoryApi.json";

        // When / Then
        using var pactVerifier = new PactVerifier("StockApi", config);
        
        pactVerifier
            .WithHttpEndpoint(ServiceUri)
            .WithFileSource(new FileInfo(contractPactPath))
            .WithCustomHeader("Content-Type", "application/json; charset=utf-8")
            .Verify();
    }
}