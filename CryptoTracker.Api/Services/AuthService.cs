using Api.Data;
using Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Api.Services;

public class AuthService(IDbContextFactory<CryptoTrackerContext> dbFactory) : IAuthService
{
    public async Task<User?> Login(LoginModel model)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();

        dbContext.EnsureSeedData();

        return await dbContext.Users.SingleOrDefaultAsync(user => (user.Email == model.Email) & (user.Password == model.Password));
    }
    
    public async Task Register(User user)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();

        dbContext.EnsureSeedData();

        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        var dbContext = await dbFactory.CreateDbContextAsync();

        dbContext.EnsureSeedData();

        return await dbContext.Users.ToListAsync();
    }
    
    public async Task<User?> GetUserByIdAsync(int id)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();

        dbContext.EnsureSeedData();

        return await dbContext.Users.SingleOrDefaultAsync(user => user.Id == id);
    }
}