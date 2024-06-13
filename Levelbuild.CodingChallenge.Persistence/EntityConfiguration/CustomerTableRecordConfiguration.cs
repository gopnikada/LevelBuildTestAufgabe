using Levelbuild.CodingChallenge.Persistence.Abstractions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Levelbuild.CodingChallenge.Persistence.EntityConfiguration;

public class CustomerTableRecordConfiguration
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        EntityTypeBuilder<CustomerTableRecord> entity = modelBuilder.Entity<CustomerTableRecord>();

        entity.ToTable("Customer");
        BaseTableRecordConfiguration.Configure(entity);

        entity.
            HasIndex(e => e.Name).
            IsUnique();

        _ = entity.
            Property(p => p.Name).
            IsRequired().
            HasMaxLength(50);

        _ = entity.
            Property(p => p.Website).
            HasMaxLength(450);

        _ = entity.
            HasMany(p => p.Users).
            WithOne(p => p.Customer).
            HasForeignKey(e=>e.CustomerRefId).
            HasPrincipalKey(e=>e.Id).
            OnDelete(DeleteBehavior.ClientCascade);
    }
}