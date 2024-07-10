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
    
    public async Task<List<Note>?> GetNotesAsync()
    {
        Notes = [];

        Uri uri = new(string.Format(Constants.RestUrl, string.Empty));
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri + "Notes/notes");
            
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Notes = JsonSerializer.Deserialize<List<Note>>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return Notes;
    }

    public async Task SaveNote(Note note, bool isNewItem = false)
    {
        Uri uri = new(string.Format(Constants.RestUrl, string.Empty));

        try
        {
            string json = JsonSerializer.Serialize(note, _serializerOptions);
            StringContent content = new(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            if (isNewItem)
                response = await _httpClient.PostAsync(uri + "Notes/add-note", content);
            else
                response = await _httpClient.PutAsync(uri + $"Notes/update-note/{note.Id}", content);

            if (response.IsSuccessStatusCode)
                Debug.WriteLine(@"\Note successfully saved.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }

    public async Task DeleteNoteAsync(int id)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync(Constants.RestUrl + $"Notes/delete-note/{id}");
        response.EnsureSuccessStatusCode();
    }
}