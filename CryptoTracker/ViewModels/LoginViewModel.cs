using System.Text;
using System.Windows.Input;

namespace CryptoTracker.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private string _email;
    private string _password;
    private string _errorMessage;

    public ICommand SignInCommand { get; }
    public event EventHandler LoginSuccess;
    private readonly HttpClient _httpClient;

    public LoginViewModel(HttpClient httpClient)
    {
        Title = "Login";
        _httpClient = httpClient;
        SignInCommand = new Command(async () => await SignInAsync());
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

    public async Task SignInAsync()
    {
        var loginModel = new { Email, Password };
        
        var json = JsonSerializer.Serialize(loginModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        Uri uri = new(string.Format(Constants.LoginUrl, string.Empty));
        var response = await _httpClient.PostAsync(uri, content);

        if (response.IsSuccessStatusCode)
        {
            Debug.WriteLine("Login successful.");

            // var responseContent = await response.Content.ReadAsStringAsync();
            // var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseContent);

            // await SecureStorage.SetAsync("auth_token", loginResponse.AccessToken);
            // string authToken = await SecureStorage.GetAsync("auth_token");
            //
            // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            //
            // var userInfoResponse = await _httpClient.GetAsync(uri + "Auth/me");
            // if (userInfoResponse.IsSuccessStatusCode)
            // {
            // 	var userInfoContent = await userInfoResponse.Content.ReadAsStringAsync();
            // 	var userInfo = JsonSerializer.Deserialize<UserId>(userInfoContent);
            //
            // 	await SecureStorage.SetAsync("user_id", userInfo.id);
            // }

            LoginSuccess?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            ErrorMessage = "Error. Please try again later.";
        }
    }
}