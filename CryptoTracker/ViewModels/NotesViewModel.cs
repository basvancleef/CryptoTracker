using System.Windows.Input;

namespace CryptoTracker.ViewModels;

public partial class NotesViewModel : BaseViewModel
{
    private readonly NotesService _notesService;

    public ObservableCollection<Note> Notes { get; set; } = [];
    public ICommand NewCommand { get; set; }
    public ICommand SelectNoteCommand { get; set; }

    public NotesViewModel(NotesService service)
    {
        _notesService = service;

        Title = "Notes";
        NewCommand = new Command(async () => await AddItem());
        SelectNoteCommand = new Command<Note>(async (note) => await SelectionChanged(note));
        _ = RefreshNotes();
        
        OnPropertyChanged(nameof(Notes));
    }

    public async Task RefreshNotes()
    {
        Notes.Clear();
        var notes = await _notesService.GetNotesAsync();
        notes.ForEach(Notes.Add);
        
        OnPropertyChanged(nameof(Notes));
    }

    private async Task AddItem()
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(Note), new Note { Id = 4, Date = DateTime.Now.ToShortDateString(), UserId = 1} }
        };
        await Shell.Current.GoToAsync(nameof(NoteDetailPage), navigationParameter);
    }

    private async Task SelectionChanged(Note note)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(Note), note }
        };
        await Shell.Current.GoToAsync(nameof(NoteDetailPage), navigationParameter);
    }
}