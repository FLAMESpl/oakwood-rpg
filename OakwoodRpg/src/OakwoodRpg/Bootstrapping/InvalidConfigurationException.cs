namespace OakwoodRpg.Bootstrapping;

public class InvalidConfigurationException : Exception
{
    public InvalidConfigurationException(string settingPath, string message) : base(message)
    {
        SettingPath = settingPath;
    }

    public InvalidConfigurationException(string settingPath, string message, Exception innerException) : base(
        message, innerException)
    {
        SettingPath = settingPath;
    }

    public string SettingPath { get; }

    public static InvalidConfigurationException GetForInvalidValue(string settingPath, string reason) => 
        new(settingPath, GetInvalidValueMessage(settingPath, reason));

    public static InvalidConfigurationException GetForInvalidValue(string settingPath, string reason, Exception innerException) =>
        new(settingPath, GetInvalidValueMessage(settingPath, reason), innerException);

    public static InvalidConfigurationException GetForMissingValue(string settingPath) =>
        new(settingPath, GetMissingValueMessage(settingPath));

    public static InvalidConfigurationException GetForMissingValue(string settingPath, Exception innerException) =>
        new(settingPath, GetMissingValueMessage(settingPath), innerException);

    private static string GetInvalidValueMessage(string settingPath, string reason) => 
        $"Setting {settingPath} is invalid: {reason}";

    private static string GetMissingValueMessage(string settingPath) =>
        $"Required setting {settingPath} is missing or empty.";
}

