using System.Text;
using _001_VMT.Shared.Contracts.Security.Access;
using _001_VMT.Shared.Contracts.Security.Configuration;
using _001_VMT.Shared.Helpers.Message;
using _001_VMT.Shared.Helpers.Models;
using _001_VMT.Shared.Service.Security.Access;
using _001_VMT.Shared.Service.Security.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace _001_VMT.Shared.Extension;

public static class ExtensionService
{
    public static IServiceCollection AddShared
    (
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.AddTokenService(config);
        services.AddAuthenticationService(config);

        return services;
    }

    public static IServiceCollection AddTokenService
    (
        this IServiceCollection services,
        IConfiguration config
    )
    {
        var sectionJwt = config.GetSection(SharedMessage.JwtSettings);
        services.Configure<JwtSettings>(sectionJwt);

        services.AddScoped<ITokenConfiguration, TokenConfiguration>();
        services.AddScoped<IAccessToken, AccessToken>();

        return services;
    }

    public static IServiceCollection AddAuthenticationService
    (
        this IServiceCollection services,
        IConfiguration config
    )
    {
        var jwtSettings = config
        .GetSection(SharedMessage.JwtSettings)
        .Get<JwtSettings>();

        var jwtBearer = JwtBearerDefaults.AuthenticationScheme;

        services
        .AddAuthentication(jwtBearer)
        .AddJwtBearer
        (
            options =>
            {
                var validateIssuerKey = true;

                var key = config[SharedMessage.JwtKey];
                var encoding = Encoding.UTF8.GetBytes(key!);
                var issuerSigningKey = new SymmetricSecurityKey(encoding);

                var validateIssuer = true;
                var issuer = config[SharedMessage.JwtIssuer];

                var validateAudience = true;
                var audience = config[SharedMessage.JwtAudience];

                var lifeTime = true;
                var clock = TimeSpan.Zero;

                var parameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = validateIssuerKey,
                    IssuerSigningKey = issuerSigningKey,

                    ValidateIssuer = validateIssuer,
                    ValidIssuer = issuer,

                    ValidateAudience = validateAudience,
                    ValidAudience = audience,

                    ValidateLifetime = lifeTime,
                    ClockSkew = clock
                };

                options.TokenValidationParameters = parameters;
            }
        );

        return services;
    }
}