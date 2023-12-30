using PactNet.Verifier;
using Producer.EmulsiveFactory.Contract.Tests.Fixtures;
using Producer.EmulsiveFactory.Contract.Tests.Helpers;
using Producer.EmulsiveFactory.Contract.Tests.Models;

namespace Producer.EmulsiveFactory.Contract.Tests.ConsumerDriven;

public class PhotographyStoreSockTests : StockServiceFixture
{
    [Test]
    public void Verify_Alignment_With_Consumer_Opinion_Service_Contract()
    {
        // Given
        var pactContractsPath = PactUtils.ContractsLocation(ContractStrategy.Consumer);

        var config = new PactVerifierConfig();
        var opinionContractPath = $"{pactContractsPath}{Path.DirectorySeparatorChar}PhotographyShop-EmulsiveFactory-StockApi.json";

        // When / Then
        using var pactVerifier = new PactVerifier("StockApi", config);
        
        pactVerifier
            .WithHttpEndpoint(ServiceUri)
            .WithFileSource(new FileInfo(opinionContractPath))
            .WithCustomHeader("Content-Type", "application/json; charset=utf-8")
            .Verify();
    }
}