namespace CryptoTracker;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(Loading), typeof(Loading));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        
        // Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        // Routing.RegisterRoute(nameof(NewsPage), typeof(NewsPage));
        // Routing.RegisterRoute(nameof(NoteListPage), typeof(NoteListPage));
        // Routing.RegisterRoute(nameof(NoteDetailPage), typeof(NoteDetailPage));
        // Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
    }
}