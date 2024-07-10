namespace CryptoTracker.Views;

[QueryProperty(nameof(CoinId), "id")]
public partial class CoinDetailPage : ContentPage
{
    public required string CoinId;
    
    public CoinDetailPage(CoinDetailPageViewModel viewModel)
    {
        InitializeComponent();
        
        BindingContext = viewModel;
    }
    
    // protected override void OnAppearing()
    // {
    //     base.OnAppearing();
    //     (BindingContext as HomeViewModel)?.GetCoinById(CoinId);
    // }
}