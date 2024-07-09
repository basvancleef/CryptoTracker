namespace CryptoTracker.Views;

[QueryProperty(nameof(Note), "Note")]
public partial class NoteDetailPage : ContentPage
{
    public NoteDetailPage(NoteDetailPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}