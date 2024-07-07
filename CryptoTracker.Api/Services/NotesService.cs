using Api.Data;
using Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Api.Services;

public class NotesService(IDbContextFactory<CryptoTrackerContext> dbFactory) : INotesService
{
    public async Task<List<Note>> GetAllNotesAsync()
    {
        var dbContext = await dbFactory.CreateDbContextAsync();

        dbContext.EnsureSeedData();

        return await dbContext.Notes.ToListAsync();
    }
    
    public async Task AddNoteAsync(Note note)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();

        dbContext.Notes.Add(note);
        await dbContext.SaveChangesAsync();
    }
    
    public async Task DeleteNoteAsync(int id)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();

        var note = await dbContext.Notes.FindAsync(id);
        dbContext.Notes.Remove(note);
        await dbContext.SaveChangesAsync();
    }
}