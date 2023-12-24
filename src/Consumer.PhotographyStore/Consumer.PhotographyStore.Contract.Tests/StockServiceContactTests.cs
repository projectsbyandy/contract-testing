using Consumer.PhotographyStore.Contract.Tests.Models;
using Consumer.PhotographyStore.Contract.Tests.PactHelper;
using NUnit.Framework;
using PactNet;

namespace Consumer.PhotographyStore.Contract.Tests;

public class Tests
{
    private IPactBuilder? _pactBuilder;
    private readonly IPactBuilderV4 pactBuilder;

    [SetUp]
    public void Setup()
    {
        var pact = Pact.V4("PhotographyShop", "StockApi", new PactConfig()
        {
            PactDir = PactUtils.ContractsLocation(ContractStrategy.Consumer)
        });
        _pactBuilder = pact.WithHttpInteractions();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}