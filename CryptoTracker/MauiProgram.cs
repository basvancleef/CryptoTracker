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
        builder.Services.AddSingleton<ArticleService>();
        builder.Services.AddTransient<ArticlesViewModel>();
        builder.Services.AddTransient<NewsPage>();
        
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddSingleton<HomeService>();
        builder.Services.AddTransient<HomeViewModel>();
        
        builder.Services.AddSingleton<ProfileService>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<ProfilePage>();

        builder.Services.AddTransient<NotesService>();
        builder.Services.AddTransient<NotesViewModel>();
        builder.Services.AddTransient<NoteListPage>();
        
        return builder.Build();
    }
}