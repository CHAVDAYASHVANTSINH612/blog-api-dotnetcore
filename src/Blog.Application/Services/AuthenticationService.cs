using Blog.Application.Interface;
using Blog.Application.Models.Request;
using Blog.Domain.Entities;
using Blog.Domain.Interface;

namespace Blog.Application.Service;

public class AuthenticationService(IUnitOfWork unitOfWork, IUserRepository userRepository) : IAuthenticationService
{
    public Task<string> LoginAsync(LoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<string> RegisterAsync(RegisterRequest registerRequest)
    {
        if(registerRequest == null)
        {
            throw new ArgumentNullException(nameof(registerRequest));
        }
        var userExist = await userRepository.GetUserByEmailAsync(registerRequest.Email);

        if(userExist is not null)
        {
            throw new Exception("User already exists");
        }

        var user = new User
        {
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Username = registerRequest.Username
        };

        await userRepository.AddAsync(user);
        await unitOfWork.CommitAsync();

        return "Register Success";
    }


}