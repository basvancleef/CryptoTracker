namespace CryptoTracker.ViewModels;

public partial class ProfileViewModel : BaseViewModel
{
    ProfileService profileService;
    
    public ProfileViewModel(ProfileService profileService)
    {
        Title = "Profile";
        this.profileService = profileService;
    }
    
    public async Task GetUserData()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await profileService.GetProfile();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get profile: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}