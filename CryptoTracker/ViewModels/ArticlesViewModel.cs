namespace CryptoTracker.ViewModels;

public partial class ArticlesViewModel : BaseViewModel
{
    public ObservableCollection<Article> Articles { get; } = new();
    ArticleService articleService;
    
    public ArticlesViewModel(ArticleService articleService)
    {
        Title = "News";
        this.articleService = articleService;
    }

    public async Task GetArticles()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var articles = await articleService.GetArticles();

            if(Articles.Count != 0)
                Articles.Clear();
                
            foreach(var article in articles)
                Articles.Add(article);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get articles: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}