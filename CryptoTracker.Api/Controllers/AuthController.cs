using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<User?> Login(string email, string password)
    {
        return await authService.Login(email, password);
    }

    [HttpPost("register")]
    public async Task Register([FromBody] User user)
    {
        await authService.Register(user);
    }
    
    [HttpGet("test")]
    public Task Test()
    {
        return null;
    }
}