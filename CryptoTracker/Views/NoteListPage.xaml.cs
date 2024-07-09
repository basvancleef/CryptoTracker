namespace CryptoTracker.Views;

public partial class NoteListPage : ContentPage
{
    public NoteListPage(NotesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}