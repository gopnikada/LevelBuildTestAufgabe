using Levelbuild.CodingChallenge.Persistence.Abstractions.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Levelbuild.CodingChallenge.Persistence.EntityConfiguration;

public class UserTableRecordConfiguration
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        EntityTypeBuilder<UserTableRecord> entity = modelBuilder.Entity<UserTableRecord>();

        entity.ToTable("User");
        BaseTableRecordConfiguration.Configure(entity);

        entity.
            HasIndex(e => e.DisplayName).
            IsUnique();

        entity.
            HasIndex(e => e.Email).
            IsUnique();

        _ = entity.
            Property(p => p.DisplayName).
            IsRequired();
        
        _ = entity.
            Property(p => p.FirstName).
            IsRequired();

        _ = entity.
            Property(p => p.LastName).
            IsRequired();

        _ = entity.
            Property(p => p.Email).
            IsRequired();

        _ = entity.
            Property(p => p.DateOfBirth).
            IsRequired();

    }
}