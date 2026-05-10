using Blog.Application.Common.Results;
using Blog.Application.Models.Request;

namespace Blog.Application.Interface;

public interface IAuthenticationService
{
    Task<Result> RegisterAsync(RegisterRequest registerRequest);
    Task<Result> LoginAsync(LoginRequest loginRequest);
}

