using Shared.Models;

namespace Api.Services.Interfaces;

public interface IAuthService
{
    Task Register(User user);
    // Task<User?> Login(string email, string password);
    Task<User?> Login(LoginModel model);
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
}