using Microsoft.Extensions.Configuration;

namespace CommonCSharp;

public class ConfigReader
{
    private static IConfiguration? _configuration;
    public static T GetConfiguration<T>() where T : new()
    {
        var configuration = GetConfiguration();
        var configModel = new T();
        configuration.Bind(configModel);
        return configModel;
    }

    public static T GetConfigurationSection<T>(string sectionName) where T : new()
    {
        var configuration = GetConfiguration();
        var configModel = new T();
        configuration.GetSection(sectionName).Bind(configModel);
        return configModel;
    }
    
    private static IConfiguration GetConfiguration()
    {
        var env = Environment.GetEnvironmentVariable("ENVIRONMENTINTEST") ?? "development";

        return _configuration ??= new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .AddJsonFile("appsettings-broker.json", optional: true, reloadOnChange: false)
            .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: false)
            .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables()
            .Build();
    }
}