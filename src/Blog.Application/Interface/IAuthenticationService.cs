using Blog.Application.Models.Request;

namespace Blog.Application.Interface;

public interface IAuthenticationService
{
    Task<string> RegisterAsync(RegisterRequest registerRequest);
    Task<string> LoginAsync(LoginRequest loginRequest);
}

