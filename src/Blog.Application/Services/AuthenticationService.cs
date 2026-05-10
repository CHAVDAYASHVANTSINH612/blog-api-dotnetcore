using Blog.Application.Common.Results;
using Blog.Application.Errors;
using Blog.Application.Interface;
using Blog.Application.Models.Request;
using Blog.Domain.Entities;
using Blog.Domain.Interface;

namespace Blog.Application.Service;

public class AuthenticationService(IUnitOfWork unitOfWork, IUserRepository userRepository) : IAuthenticationService
{
    public async Task<Result> LoginAsync(LoginRequest loginRequest)
    {
        if(loginRequest is null)
        {
            return Result.Failure(AuthError.InvalidCredentials);
        }
        var (email, password) = loginRequest; // Deconstruct the LoginRequest record

        User? user = await userRepository.GetUserByEmailAsync(email);

        if(user is null)
            return Result.Failure(AuthError.UserNotFound);
        if(user.Password != password)
            return Result.Failure(AuthError.InvalidPassword);

        var token = new
        {
            token = "token",
            username = user.Username
        };
        return Result.Success(token);

    }

    public async Task<Result> RegisterAsync(RegisterRequest registerRequest)
    {
        if(registerRequest == null)
        {
            return Result.Failure(AuthError.InvalidCredentials);
        }
        var userExist = await userRepository.GetUserByEmailAsync(registerRequest.Email);

        if(userExist is not null)
        {
            return Result.Failure(AuthError.UserAlreadyExists);
        }

        var user = new User
        {
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Username = registerRequest.Username
        };

        await userRepository.AddAsync(user);
        await unitOfWork.CommitAsync();

        return Result.Success("User registered successfully.");
    }


}