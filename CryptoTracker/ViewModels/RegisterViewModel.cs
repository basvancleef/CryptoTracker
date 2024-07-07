using System.Text;
using System.Windows.Input;

namespace CryptoTracker.ViewModels;

public class RegisterViewModel : BaseViewModel
{
    private string _name;
    private string _email;
    private string _password;
    private string _errorMessage;

    public ICommand RegisterCommand { get; }
    public event EventHandler RegisterSuccess;
    private readonly HttpClient _httpClient;

    public RegisterViewModel(HttpClient httpClient)
    {
        Title = "Register";
        _httpClient = httpClient;
        RegisterCommand = new Command(async () => await RegisterAsync());
    }
    
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public async Task RegisterAsync()
    {
        var registerModel = new { Name, Email, Password };
        
        var json = JsonSerializer.Serialize(registerModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        Uri uri = new(string.Format(Constants.RegisterUrl, string.Empty));
        var response = await _httpClient.PostAsync(uri, content);

        if (response.IsSuccessStatusCode)
        {
            RegisterSuccess?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            ErrorMessage = "Registration failed.";
        }
    }
}