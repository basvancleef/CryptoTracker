using System.Text.Json.Serialization;

namespace Shared.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Token { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
    public string? DateOfBirth { get; set; }
    public string? Language { get; set; }
}

[JsonSerializable(typeof(User))]
internal sealed partial class UserContext : JsonSerializerContext
{
} 