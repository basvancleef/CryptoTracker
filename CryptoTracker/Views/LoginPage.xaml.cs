namespace CryptoTracker.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        LoginViewModel viewModel = new LoginViewModel(new HttpClient());
        
        InitializeComponent();
        BindingContext = viewModel;
        
        viewModel.LoginSuccess += OnLoginSuccess;
    }
    
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (BindingContext is LoginViewModel viewModel)
        {
            viewModel.LoginSuccess -= OnLoginSuccess;
        }
    }
    
    private async void OnLoginSuccess(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new MainPage());
    }
    
    private async void SignUpTapped(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new RegisterPage());
    }
}