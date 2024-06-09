using Microsoft.Extensions.Logging;

namespace CryptoTracker.Services;

public class HomeService
{
        private const string BaseUrl = "https://min-api.cryptocompare.com/data";
        private const int CoinApiLimit = 100;

        HttpClient httpClient;
    
        public HomeService()
        {
            this.httpClient = new HttpClient();
        }
        
        public async Task<List<Currency>?> GetCurrencies(int coinsCount)
        {
            coinsCount = Math.Min(coinsCount, CoinApiLimit);
            var coins = new List<Currency>();

            var uri = BaseUrl + $"/top/totalvolfull?limit={coinsCount}&tsym=EUR";
            var json = await httpClient.GetStringAsync(uri);
            
            try
            {
                var coinsResponse = JsonDocument.Parse(json).RootElement.GetProperty("Data");
                
                for (int i = 0; i < coinsResponse.GetArrayLength(); i++)
                {
                    var coinInfo = coinsResponse[i].GetProperty("CoinInfo");
                    if (coinsResponse[i].TryGetProperty("RAW", out var rawData) && rawData.TryGetProperty("EUR", out var eurData))
                    {
                        var coinPrices = coinsResponse[i].GetProperty("RAW").GetProperty("EUR");
                        var coin = new Currency()
                        {
                            Symbol = "https://www.cryptocompare.com/" + coinInfo.GetProperty("ImageUrl").GetString(),
                            Name = coinInfo.GetProperty("FullName").GetString(),
                            ShortName = coinInfo.GetProperty("Internal").GetString(),
                            Price24Low = coinPrices.GetProperty("LOWDAY").GetDouble(),
                            Price24High = coinPrices.GetProperty("HIGHDAY").GetDouble(),
                            OpeningPrice = coinPrices.GetProperty("OPENDAY").GetDouble(),
                            ChangeInPriceAmount = coinPrices.GetProperty("CHANGE24HOUR").GetDouble(),
                            ChangeInPricePercentage = coinPrices.GetProperty("CHANGEPCT24HOUR").GetDouble(),
                        };
                        
                        coins.Add(coin);
                    }
                }
            }
            catch
            {
                return coins;
            }

            return coins;
        }
}