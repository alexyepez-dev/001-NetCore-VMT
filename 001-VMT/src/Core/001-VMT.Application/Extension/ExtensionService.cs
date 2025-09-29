using _001_VMT.Application.AutoMapper;
using _001_VMT.Application.Bll;
using _001_VMT.Application.Contracts;
using _001_VMT.Application.Dtos;
using _001_VMT.Application.Validations;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace _001_VMT.Application.Extension;

public static class ExtensionService
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.BllService();
        services.MapperService();
        services.ValidationService();

        return services;
    }

    public static IServiceCollection BllService(this IServiceCollection services)
    {
        services.AddScoped<ILoginBll, LoginBll>();
        services.AddScoped<IRegisterBll, RegisterBll>();

        return services;
    }

    public static IServiceCollection MapperService(this IServiceCollection services)
    {
        var profile = new MapperProfile();

        var mapper = new MapperConfiguration
        (
            expression => expression
            .AddProfile(profile)
        );

        var create = mapper.CreateMapper();

        services.AddSingleton(create);

        return services;
    }

    public static IServiceCollection ValidationService(this IServiceCollection services)
    {
        services.AddTransient<IValidator<LoginDto>, LoginValidation>();
        services.AddTransient<IValidator<RegisterDto>, RegisterValidation>();

        return services;
    }
}