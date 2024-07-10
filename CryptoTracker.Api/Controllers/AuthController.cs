using System.Security.Claims;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<User?> Login(LoginModel model)
    {
        return await authService.Login(model);
    }

    [HttpPost("register")]
    public async Task Register([FromBody] User user)
    {
        await authService.Register(user);
    }
    
    [HttpGet("users")]
    public async Task<List<User>> Test()
    {
        return await authService.GetAllUsersAsync();
    }
    
    [HttpGet("user/{id}")]
    public async Task<User?> GetUserById([FromRoute] int id)
    {
        return await authService.GetUserByIdAsync(id);
    }
    
    [HttpGet("me")]
    public async Task<ActionResult<User>> GetCurrentUser()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (string.IsNullOrEmpty(userId))
            return NotFound("User not found");

        var user = await authService.GetUserByIdAsync(int.Parse(userId));
        if (user == null)
            return NotFound("User not found");

        return Ok(user);
    }
}