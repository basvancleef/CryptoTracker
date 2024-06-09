using System.Net.Http.Json;

namespace CryptoTracker.Services;

public class ArticleService
{
    HttpClient httpClient;
    
    public ArticleService()
    {
        this.httpClient = new HttpClient();
    }
    
    List<Article>? newsList;
    public async Task<List<Article>?> GetArticles()
    {
        if (newsList?.Count > 0)
        {
            return newsList;
        }
        
        await using var stream = await FileSystem.OpenAppPackageFileAsync("Articles.json");
        using var reader = new StreamReader(stream);
        
        var contents = await reader.ReadToEndAsync();
        newsList = JsonSerializer.Deserialize(contents, ArticleContext.Default.ListArticle);

        return newsList;
    }
}