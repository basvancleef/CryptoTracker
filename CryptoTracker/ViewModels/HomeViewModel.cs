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
}