using Shared.Models;

namespace Api.Services.Interfaces;

public interface INotesService
{
    Task<List<Note>> GetAllNotesAsync();
    Task AddNoteAsync(Note note);
    Task DeleteNoteAsync(int id);
    Task UpdateNoteAsync(int id, Note note);
}