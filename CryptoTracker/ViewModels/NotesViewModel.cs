using CommunityToolkit.Mvvm.Input;

namespace CryptoTracker.ViewModels;

public partial class NotesViewModel : BaseViewModel
{
    [ObservableProperty]
    private List<Note> _notes;
    
    NotesService notesService;
    
    public NotesViewModel(NotesService notesService)
    {
        Title = "Notes";
        this.notesService = notesService;
    }

    [RelayCommand]
    private async Task OpenDetailPageAsync(int id)
    {
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Shell.Current.GoToAsync($"{nameof(NoteDetailPage)}?id={id}");
        });
    }
    
    [RelayCommand]
    private async Task OpenNewNotePageAsync()
    {
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Shell.Current.GoToAsync($"{nameof(NoteAddPage)}");
        });
    }

    
    public async Task GetNotesList()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var notes = await notesService.GetNotes();
            
            Notes = notes;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get notes: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}