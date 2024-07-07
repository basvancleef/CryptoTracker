namespace CryptoTracker.ViewModels;

public partial class NoteAddPageViewModel(NotesService notesService) : BaseViewModel, IQueryAttributable
{
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        throw new NotImplementedException();
    }
}