
using Blog.Application.Common.Results;
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
        if(response.IsFailure)
        {
            return Results.BadRequest(response);
        }
        return Results.Ok(response);
    }
    
    [HttpPost("login")]
    public async Task<IResult> Login(LoginRequest loginRequest)
    {
        var response = await authenticationService.LoginAsync(loginRequest);
        if(response.IsFailure)
            return Results.BadRequest(response);
            
        return Results.Ok(response);
    }


}
