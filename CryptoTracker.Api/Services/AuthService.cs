﻿using Api.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Api.Services;

public class AuthService(IDbContextFactory<CryptoTrackerContext> dbFactory)
{
    public async Task<User?> Login(string Email, string Password)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();

        dbContext.EnsureSeedData();

        return await dbContext.Users.SingleOrDefaultAsync(m => (m.Email == Email) & (m.Password == Password));
    }


    public async Task Register(User user)
    {
        var dbContext = await dbFactory.CreateDbContextAsync();

        dbContext.EnsureSeedData();

        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }
}