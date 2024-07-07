namespace CryptoTracker.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        HomeViewModel viewModel = new HomeViewModel(new HomeService());
        
        InitializeComponent();
        BindingContext = viewModel;
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as HomeViewModel)?.GetCurrencies();
    }
}