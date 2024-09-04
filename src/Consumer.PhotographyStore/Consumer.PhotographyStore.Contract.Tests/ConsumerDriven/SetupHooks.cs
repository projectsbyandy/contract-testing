using Consumer.PhotographyStore.Contract.Tests.Models;
using Consumer.PhotographyStore.Contract.Tests.PactHelper;
using NUnit.Framework;

namespace Consumer.PhotographyStore.Contract.Tests.ConsumerDriven;

[SetUpFixture]
public class SetupHooks
{
    [OneTimeSetUp]
    public void ClearContractsFolder()
    {
        //PactUtils.ClearContractFolder(ContractStrategy.Consumer);
    }
}