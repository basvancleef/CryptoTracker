namespace CryptoTracker.Views;

public partial class NoteAddPage : ContentPage
{
    public NoteAddPage(NoteDetailPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}