using _001_VMT.Persistence.Database.Connection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _001_VMT.Persistence.Extension;

public static class ExtensionService
{
    public static IServiceCollection AddPersistence
    (
        this IServiceCollection services,
        IConfiguration config
    )
    {
        var connectionString = config["ConnectionStrings:SqlServer"];
        services.AddDbContext<AppDbConnection>
        (
            options => options
            .UseSqlServer(connectionString)
        );

        return services;
    }
}