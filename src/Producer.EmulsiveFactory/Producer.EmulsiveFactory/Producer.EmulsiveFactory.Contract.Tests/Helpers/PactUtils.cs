using Producer.EmulsiveFactory.Contract.Tests.Models;
using Producer.EmulsiveFactory.Helpers;

namespace Producer.EmulsiveFactory.Contract.Tests.Helpers;

public class PactUtils
{
    public static string ContractsLocation(ContractStrategy contractStrategy)
    {
        var location =
            $"{Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.Parent?.Parent}{Path.DirectorySeparatorChar}SharedPactContracts{Path.DirectorySeparatorChar}{contractStrategy.GetDescription()}";
        Directory.CreateDirectory(location);

        return location;
    }
}