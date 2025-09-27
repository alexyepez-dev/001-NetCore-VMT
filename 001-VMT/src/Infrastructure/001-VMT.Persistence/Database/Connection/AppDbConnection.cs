using _001_VMT.Domain.Entities;
using _001_VMT.Persistence.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace _001_VMT.Persistence.Database.Connection;

public class AppDbConnection(DbContextOptions<AppDbConnection> options) : DbContext(options)
{
    public DbSet<User> Usuario { get; set; }
    public DbSet<Company> Empresa { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ConfigurationOfEntities(modelBuilder);
    }

    private static void ConfigurationOfEntities(ModelBuilder modelBuilder)
    {
        var configOfUser = modelBuilder.Entity<User>();

        _ = new UserConfiguration(configOfUser);
    }
}