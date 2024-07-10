using CommunityToolkit.Mvvm.Input;

namespace CryptoTracker.ViewModels;

public partial class HomeViewModel : BaseViewModel
{
    public ObservableCollection<Currency> Currencies { get; } = new();
    private HomeService homeService;

    public HomeViewModel(HomeService homeService)
    {
        Title = "Overview";
        this.homeService = homeService;
    }
    
    [RelayCommand]
    private async Task OpenDetailPageAsync(string id)
    {
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Shell.Current.GoToAsync($"{nameof(CoinDetailPage)}?id={id}");
        });
    }

    public async Task GetCurrencies()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var currencies = await homeService.GetCurrencies(10);
            
            if (Currencies.Count != 0)
                Currencies.Clear();
            
            foreach (var currency in currencies)
                Currencies.Add(currency);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get currencies: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    public async Task GetCoinById(string id)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var coin = await homeService.GetCoinById(id);
            
            // Do something with the coin
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get coin: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}