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
        builder.Services.AddTransient<NotesService>();
        builder.Services.AddSingleton<ProfileService>();
        
        // Register views:
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<NewsPage>();
        builder.Services.AddTransient<NoteListPage>();
        builder.Services.AddTransient<ProfilePage>();
        
        // Register ViewModels:
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<ArticlesViewModel>();
        builder.Services.AddTransient<NotesViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        
        return builder.Build();
    }
}