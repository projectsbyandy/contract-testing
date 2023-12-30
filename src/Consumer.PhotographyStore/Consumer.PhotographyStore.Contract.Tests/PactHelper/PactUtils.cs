using System.IO;
using Consumer.PhotographyStore.Contract.Tests.Models;
using Consumer.PhotographyStore.Helpers;

namespace Consumer.PhotographyStore.Contract.Tests.PactHelper;

public class PactUtils
{
    public static void ClearContractFolder(ContractStrategy pactContractPath)
    {
        var directoryInfo = new DirectoryInfo(ContractsLocation(pactContractPath));

        foreach (var file in directoryInfo.GetFiles())
        {
            file.Delete();
        }
    }
    
    public static string ContractsLocation(ContractStrategy contractStrategy)
    {
        var location =
            $"{Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.Parent}{Path.DirectorySeparatorChar}SharedPactContracts{Path.DirectorySeparatorChar}{contractStrategy.GetDescription()}";
        Directory.CreateDirectory(location);

        return location;
    }
}