namespace CryptoTracker.ViewModels;

public partial class NotesViewModel : BaseViewModel
{
    public ObservableCollection<Note> Notes { get; } = new();
    NotesService notesService;
    
    public NotesViewModel(NotesService notesService)
    {
        Title = "Notes";
        this.notesService = notesService;
    }
    
    public async Task GetNotesList()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var notes = await notesService.GetNotes();

            if(Notes.Count != 0)
                Notes.Clear();
                
            foreach(var note in notes)
                Notes.Add(note);
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