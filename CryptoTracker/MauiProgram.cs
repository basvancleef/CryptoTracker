using Microsoft.Extensions.Logging;

namespace CryptoTracker;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        // Register services:
        builder.Services.AddSingleton<HomeService>();
        builder.Services.AddSingleton<ArticleService>();
        builder.Services.AddSingleton<NotesService>();
        builder.Services.AddSingleton<ProfileService>();
        // builder.Services.AddSingleton<AuthService>();

        // Register views:
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<NewsPage>();
        builder.Services.AddTransient<NoteListPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<NoteDetailPage>();
        builder.Services.AddTransient<CoinDetailPage>();
        // builder.Services.AddTransient<LoginPage>();
        // builder.Services.AddTransient<RegisterPage>();
        // builder.Services.AddTransient<Loading>();

        // Register ViewModels:
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<ArticlesViewModel>();
        builder.Services.AddTransient<NotesViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<NoteDetailPageViewModel>();
        builder.Services.AddTransient<CoinDetailPageViewModel>();
        // builder.Services.AddTransient<LoginViewModel>();

        return builder.Build();
    }
}