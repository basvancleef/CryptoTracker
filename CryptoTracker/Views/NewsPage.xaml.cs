namespace CryptoTracker.Views;

public partial class NewsPage : ContentPage
{
    public NewsPage(ArticlesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as ArticlesViewModel)?.GetArticles();
    }
}