namespace CryptoTracker.Views;

public partial class NoteListPage : ContentPage
{
    public NoteListPage(NotesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as NotesViewModel)?.GetNotesList();
    }
}