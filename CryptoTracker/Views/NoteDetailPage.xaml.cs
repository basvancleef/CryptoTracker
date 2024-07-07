namespace CryptoTracker.Views;

[QueryProperty(nameof(NoteId), "id")]
public partial class NoteDetailPage : ContentPage
{
    public required string NoteId;

    public NoteDetailPage(NoteDetailPageViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}