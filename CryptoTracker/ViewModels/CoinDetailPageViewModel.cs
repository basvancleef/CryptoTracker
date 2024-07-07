using System.Web;

namespace CryptoTracker.ViewModels;

public partial class CoinDetailPageViewModel(HomeService homeService) : BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    private Currency _coin;
    
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        await homeService.GetCurrencies(10);
        
        var coinId = HttpUtility.UrlDecode(query["id"].ToString());
        
        // _coin = await homeService.GetCoinById(int.Parse(coinId));
        Coin = await homeService.GetCoinById(coinId);
    }
}