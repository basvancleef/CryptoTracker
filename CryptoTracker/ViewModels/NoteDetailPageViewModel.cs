using System.Web;

namespace CryptoTracker.ViewModels;

public partial class NoteDetailPageViewModel(NotesService notesService) : BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    private Note _note;
    
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        await notesService.GetNotes();
        
        var noteId = HttpUtility.UrlDecode(query["id"].ToString());
        
        Note = await notesService.GetNoteById(int.Parse(noteId));
    }
}