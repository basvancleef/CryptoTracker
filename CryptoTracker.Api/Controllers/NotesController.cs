using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NotesController(INotesService notesService) : ControllerBase
{
    [HttpGet("notes")]
    public async Task<List<Note>> GetNotes()
    {
        return await notesService.GetAllNotesAsync();
    }
    
    [HttpPost("add-note")]
    public async Task AddNote([FromBody] Note note)
    {
        await notesService.AddNoteAsync(note);
    }
    
    [HttpDelete("delete-note/{id}")]
    public async Task DeleteNote([FromRoute] int id)
    {
        await notesService.DeleteNoteAsync(id);
    }
    
    [HttpPut("update-note/{id}")]
    public async Task UpdateNote([FromRoute] int id, [FromBody] Note note)
    {
        await notesService.UpdateNoteAsync(id, note);
    }
}
