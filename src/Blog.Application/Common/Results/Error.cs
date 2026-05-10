using System;

namespace Blog.Application.Common.Results;

public sealed record Error(string code, string message)
{
    internal static Error None => new(ErrorTypeConstatnt.None, string.Empty);
}
