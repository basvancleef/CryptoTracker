namespace CryptoTracker.Services;

public class ProfileService
{
    private HttpClient _httpClient = new();
    
    public async Task<User?> GetProfile()
    {
        await using var stream = await FileSystem.OpenAppPackageFileAsync("Profile.json");

        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();

        return JsonSerializer.Deserialize<User>(contents);
    }
}