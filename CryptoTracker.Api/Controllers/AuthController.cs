using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
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
    
    [HttpGet("jan")]
    public string Test()
    {
        return "yo";
    }

    [HttpGet("yobas")]
    public async Task<ActionResult<string>> Yo()
    {
        await Task.Delay(5);

        var test = Random.Shared.Next(0, 1);

        if (test == 0)
        {

            return "yo";
        }
        else
        {
            return NoContent();
        }
    }
}