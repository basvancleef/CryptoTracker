using System.Text.Json.Serialization;

namespace Shared.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Token { get; set; }
    public string? Language { get; set; }
}

[JsonSerializable(typeof(User))]
internal sealed partial class UserContext : JsonSerializerContext
{
} 