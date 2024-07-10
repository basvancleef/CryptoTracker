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

        var note = dbContext.Notes.Find(id);
        
        dbContext.Notes.Remove(note);
        await dbContext.SaveChangesAsync();
    }
    
    public async Task UpdateNoteAsync(int id ,Note note)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();
        
        var currentNote = dbContext.Notes.FindAsync(id).Result;
        
        currentNote.Title = note.Title;
        currentNote.Description = note.Description;
        currentNote.Image = note.Image;
        
        await dbContext.SaveChangesAsync();
    }
}