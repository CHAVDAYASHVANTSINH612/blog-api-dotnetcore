using System;

namespace Blog.Application.Common.Results;

public class ErrorTypeConstatnt
{
    public const string None = "NoneError";
    public const string ValidationError = "ValidationError";
    public const string Unauthorized = "UnauthorizedError";
    public const string NotFound = "NotFoundError";
    public const string InternalServerError = "InternalServerError";
    public const string Forbidden = "ForbiddenError";
    public const string Conflict = "ConflictError";
}
