using System.Windows.Input;

namespace CryptoTracker.ViewModels;

[QueryProperty(nameof(Note), "Note")]
public partial class NoteDetailPageViewModel : BaseViewModel
{
    public ICommand SaveNoteCommand { get; set; }
    public ICommand DeleteNoteCommand { get; set; }
    public ICommand CancelNoteCommand { get; set; }

    private readonly NotesService _notesService;
    private readonly NotesViewModel _notesViewModel;

    public NoteDetailPageViewModel(NotesService notesService, NotesViewModel notesViewModel)
    {
        _notesService = notesService;
        _notesViewModel = notesViewModel;

        SaveNoteCommand = new Command(async () => await SaveNote());
        DeleteNoteCommand = new Command(async () => await DeleteNote());
        CancelNoteCommand = new Command(async () => await CancelNote());
    }

    private bool _isNewItem;
    private bool IsNewItem(Note note)
    {
        if (string.IsNullOrWhiteSpace(note.Title) && string.IsNullOrWhiteSpace(note.Description))
            return true;
        return false;
    }

    private Note _note;

    public Note Note
    {
        get => _note;
        set
        {
            _isNewItem = IsNewItem(value);
            _note = value;
            Title = _isNewItem ? "Add note" : "Edit note";
            OnPropertyChanged();
        }
    }
    
    private async Task SaveNote()
    {
        await _notesService.SaveNote(Note, _isNewItem);
        await _notesViewModel.RefreshNotes();
        await Shell.Current.GoToAsync("..");
    }

    private async Task DeleteNote()
    {
        await _notesService.DeleteNoteAsync(Note.Id);
        await _notesViewModel.RefreshNotes();
        await Shell.Current.GoToAsync("..");
    }

    async Task CancelNote()
    {
        await Shell.Current.GoToAsync("..");
    }
}