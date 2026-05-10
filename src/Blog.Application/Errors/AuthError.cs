using Blog.Application.Common.Results;

namespace Blog.Application.Errors;

public static class AuthError
{
    public static Error InvalidCredentials => new(ErrorTypeConstatnt.ValidationError, "The provided credentials are invalid.");
    public static Error UserAlreadyExists => new(ErrorTypeConstatnt.Conflict, "A user with the given email already exists.");
    public static Error UserNotFound => new(ErrorTypeConstatnt.NotFound, "No user found with the provided email.");
   public static Error InvalidPassword => new(ErrorTypeConstatnt.ValidationError, "The provided password is invalid.");
}