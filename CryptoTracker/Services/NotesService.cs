using System.Net.Http.Json;

namespace CryptoTracker.Services;

public class NotesService
{
    HttpClient httpClient;
    
    public NotesService()
    {
        this.httpClient = new HttpClient();
    }

    List<Note>? notesList;
    public async Task<List<Note>?> GetNotes()
    {
        if (notesList?.Count > 0)
        {
            return notesList;
        }

        await using var stream = await FileSystem.OpenAppPackageFileAsync("Notes.json");
        using var reader = new StreamReader(stream);
        
        var contents = await reader.ReadToEndAsync();
        notesList = JsonSerializer.Deserialize(contents, NoteContext.Default.ListNote);

        return notesList;
    }
}