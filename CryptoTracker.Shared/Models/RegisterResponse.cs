﻿namespace Shared.Models;

public class RegisterResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string UserName { get; set; }
}