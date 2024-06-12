using System.Text.Json.Serialization;

namespace Shared.Models;

public class Note
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string? Image { get; set; }
}

[JsonSerializable(typeof(List<Note>))]
public sealed partial class NoteContext : JsonSerializerContext
{
}