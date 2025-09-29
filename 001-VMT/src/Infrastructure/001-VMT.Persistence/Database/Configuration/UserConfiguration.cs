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
        .HasMaxLength(50)
        .IsRequired();

        builder
        .Property(x => x.Email)
        .HasMaxLength(50)
        .IsRequired();

        builder
        .Property(x => x.Password)
        .HasMaxLength(50)
        .IsRequired();
        
        builder
        .HasOne(x => x.Company)
        .WithMany(x => x.Users)
        .HasForeignKey(x => x.CompanyId);
    }
}