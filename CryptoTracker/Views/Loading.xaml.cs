namespace CryptoTracker.Views;

public partial class Loading : ContentPage
{
    private readonly AuthService _authService;

    public Loading()
    {
        InitializeComponent();
        _authService = new AuthService();
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (await _authService.IsAuthenticatedAsync())
        {
            await Shell.Current.Navigation.PushAsync(new MainPage());        }
        else
        {
            await Shell.Current.Navigation.PushAsync(new LoginPage());
        }
    }
}