using _001_VMT.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _001_VMT.Persistence.Database.Configuration;

public class CompanyConfiguration
{
    public CompanyConfiguration(EntityTypeBuilder<Company> builder)
    {
        builder
        .HasKey(x => x.CompanyId);

        builder
        .Property(x => x.CompanyName)
        .HasMaxLength(50)
        .IsRequired();

        builder
        .HasMany(x => x.Users)
        .WithOne(x => x.Company)
        .HasForeignKey(x => x.CompanyId);
    }
}