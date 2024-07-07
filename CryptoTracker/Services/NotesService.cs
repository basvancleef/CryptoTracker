using System.Text;

namespace CryptoTracker.Services;

public class NotesService
{
    HttpClient _httpClient;
    readonly JsonSerializerOptions? _serializerOptions;
    
    public List<Note>? Notes { get; private set; }
    
    public NotesService()
    {
        _httpClient = new HttpClient();
        
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
    
    public async Task<List<Note>?> GetNotes()
    {
        Notes = [];
        
        Uri uri = new(string.Format(Constants.RestUrl + "Notes/notes"));
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Notes = JsonSerializer.Deserialize<List<Note>>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return Notes;
        
        // if (notesList?.Count > 0)
        // {
            // return notesList;
        // }
        
        // var response = await httpClient.GetAsync("http://localhost:5201/Notes/notes");
        // var content = await response.Content.ReadAsStringAsync();
        // // notesList = JsonSerializer.Deserialize<List<Note>>(content);
        // notesList.ForEach(content);
        //
        // Debug.WriteLine($"NotesList: {notesList}");
        
        // Offline mode
        // await using var stream = await FileSystem.OpenAppPackageFileAsync("Notes.json");
        // using var reader = new StreamReader(stream);
        //
        // var contents = await reader.ReadToEndAsync();
        // notesList = JsonSerializer.Deserialize(contents, NoteContext.Default.ListNote);

        // return notesList;
    }
    
    public async Task<Note> GetNoteById(int id)
    {
        return Notes.FirstOrDefault(note => note.Id == id) ?? new Note();
    }
    
    public async Task AddNote(Note note)
    {
        var json = JsonSerializer.Serialize(note);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await _httpClient.PostAsync(Constants.RestUrl + "Notes/add", content);
        response.EnsureSuccessStatusCode();
    }
}