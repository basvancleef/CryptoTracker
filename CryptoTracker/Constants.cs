namespace CryptoTracker;

public static class Constants
{
    // URL of REST service (Android does not use localhost)
    // Use http cleartext for local deployment. Change to https for production
    public static string LocalhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
    public static string Scheme = "http"; // or https
    public static string Port = "5201";
    public static string RestUrl = $"{Scheme}://{LocalhostUrl}:{Port}/";
    public static string RegisterUrl = $"{Scheme}://{LocalhostUrl}:{Port}/Auth/register";
    public static string LoginUrl = $"{Scheme}://{LocalhostUrl}:{Port}/Auth/login";
    public const string SecureStorageAuthenticationKey = "Authentication";
}
