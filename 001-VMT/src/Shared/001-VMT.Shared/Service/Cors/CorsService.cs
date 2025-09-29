using _001_VMT.Shared.Helpers.Message;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _001_VMT.Shared.Service.Cors;

public static class CorsService
{
    public static IServiceCollection AddCorsService
    (
        this IServiceCollection services,
        IConfiguration config
    )
    {
        var policy = SharedMessage.CorsPolicies;
        var url = config[SharedMessage.ClientUrl];

        services.AddCors
        (
            options => options
            .AddPolicy
            (
                policy,
                corsPolicies => corsPolicies
                .WithOrigins(url!)
                .AllowAnyHeader()
                .AllowAnyMethod()
            )
        );

        return services;
    }
}