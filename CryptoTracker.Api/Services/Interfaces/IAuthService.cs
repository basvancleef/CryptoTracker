using Shared.Models;

namespace Api.Services.Interfaces;

public interface IAuthService
{
    Task<User?> Login(string email, string password);
    Task Register(User user);
}