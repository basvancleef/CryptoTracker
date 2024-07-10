namespace CryptoTracker.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        RegisterViewModel viewModel = new RegisterViewModel(new HttpClient());
        
        InitializeComponent();
        BindingContext = viewModel;
        
        viewModel.RegisterSuccess += OnRegistrationSuccess;
    }

    private async void OnRegistrationSuccess(object sender, EventArgs e)
    {
        await DisplayAlert("Success", "You've successfully registered", "OK");
        await Shell.Current.Navigation.PushAsync(new LoginPage());
    }
    
    private async void BackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopAsync();
    }
}