using Microsoft.Extensions.Configuration;

namespace OakwoodRpg.Bootstrapping;

public static class ConfigurationExtensions
{
    public static string GetRequiredValue(this IConfiguration configuration, string key) =>
        configuration[key] ?? throw InvalidConfigurationException.GetForMissingValue(key);
}
