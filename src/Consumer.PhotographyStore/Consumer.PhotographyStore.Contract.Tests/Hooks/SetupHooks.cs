using System.IO;
using Consumer.PhotographyStore.Contract.Tests.Models;
using Consumer.PhotographyStore.Contract.Tests.PactHelper;
using NUnit.Framework;

namespace Consumer.PhotographyStore.Contract.Tests.Hooks;

[TestFixture]
public class SetupHooks
{
    [OneTimeSetUp]
    public void ClearContractsFolder(ContractStrategy contractStrategy)
    {
        var directoryInfo = new DirectoryInfo(PactUtils.ContractsLocation(contractStrategy));
        foreach (var fileInfo in directoryInfo.GetFiles())
        {
            fileInfo.Delete();
        }
    }
}