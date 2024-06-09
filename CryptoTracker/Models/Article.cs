using System.Text.Json.Serialization;

namespace CryptoTracker.Models;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }
}

[JsonSerializable(typeof(List<Article>))]
internal sealed partial class ArticleContext : JsonSerializerContext
{
}