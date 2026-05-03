
using Blog.Application.Interface;
using Blog.Application.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

public class AuthController(IAuthenticationService authenticationService): BaseApiController
{

    [HttpPost("register")]
    public async Task<IResult> Register(RegisterRequest registerRequest)
    {
        var response = await authenticationService.RegisterAsync(registerRequest);
        return Results.Ok(response);
    }
    
    [HttpPost("login")]
    public async Task<IResult> Login(LoginRequest LoginRequest)
    {
        return Results.Ok("Login successful");
    }


}
