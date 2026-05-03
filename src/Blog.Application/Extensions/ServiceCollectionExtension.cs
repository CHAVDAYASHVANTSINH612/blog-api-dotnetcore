
namespace Blog.Application.Extensions;

using Blog.Application.Interface;
using Blog.Application.Service;
using Microsoft.Extensions.DependencyInjection;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
