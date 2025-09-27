using _001_VMT.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _001_VMT.Persistence.Database.Configuration;

public class UserConfiguration
{
    public UserConfiguration(EntityTypeBuilder<User> builder)
    {
        builder
        .HasKey(x => x.UserId);

        builder
        .Property(x => x.Username)
        .IsRequired();

        builder
        .Property(x => x.Email)
        .IsRequired();

        builder
        .Property(x => x.Password)
        .IsRequired();
        
        builder
        .HasOne(x => x.Company)
        .WithMany(x => x.Users)
        .HasForeignKey(x => x.CompanyId);
    }
}