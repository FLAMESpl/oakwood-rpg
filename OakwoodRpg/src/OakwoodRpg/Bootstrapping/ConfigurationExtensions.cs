using Microsoft.Extensions.Configuration;

namespace OakwoodRpg.Bootstrapping;

public static class ConfigurationExtensions
{
    public static string GetRequiredValue(this IConfiguration configuration, string key) =>
        configuration[key] ?? throw InvalidConfigurationException.GetForMissingValue(key);

    public static T GetRequiredSetting<T>(this IConfiguration configuration, string key) =>
        configuration.GetSection(key).Get<T>() ?? throw InvalidConfigurationException.GetForMissingValue(key);
}
