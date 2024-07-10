using System.Text.Json.Serialization;

namespace Shared.Models;

public class Currency
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Symbol { get; set; }

    [JsonPropertyName("open")]
    public double OpeningPrice { get; set; }

    [JsonPropertyName("close")]
    public double ClosingPrice { get; set; }

    [JsonPropertyName("low")]
    public double Price24Low { get; set; }

    [JsonPropertyName("high")]
    public double Price24High { get; set; }

    [JsonPropertyName("time")]
    public double UnixTimeStamp { get; set; }
    public DateTime Date => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(this.UnixTimeStamp).ToLocalTime();
    public double ChangeInPriceAmount { get; set; }
    public double ChangeInPricePercentage { get; set; }
}

[JsonSerializable(typeof(List<Currency>))]
internal sealed partial class CurrencyContext : JsonSerializerContext
{
}