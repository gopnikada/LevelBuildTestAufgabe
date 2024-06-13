using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Levelbuild.CodingChallenge.Persistence.Abstractions.Models;
using Levelbuild.CodingChallenge.Persistence.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Levelbuild.CodingChallenge.Persistence.Context;

public class CodingChallengeDataBaseContext : DbContext
{
    public CodingChallengeDataBaseContext(DbContextOptions<CodingChallengeDataBaseContext> options) : base(options)
    {
    }

    public DbSet<CustomerTableRecord> Customers { get; set; }

    public DbSet<UserTableRecord> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        CodingChallengeDataBaseContext.ConfigureRecords(modelBuilder);
    }

    private static void ConfigureRecords(ModelBuilder modelBuilder)
    {
        CustomerTableRecordConfiguration.Configure(modelBuilder);
        UserTableRecordConfiguration.Configure(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        this.SetDefaultValuesOfTrackedEntities();
        return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public override int SaveChanges()
    {
        this.SetDefaultValuesOfTrackedEntities();
        return base.SaveChanges();
    }

    private void SetDefaultValuesOfTrackedEntities()
    {
        IEnumerable<EntityEntry> entries =
            this.ChangeTracker.Entries().Where(e => e.Entity is BaseTableRecord &&
                                                    e.State is EntityState.Added or EntityState.Modified
                                                        or EntityState.Deleted);

        foreach (EntityEntry entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                ((BaseTableRecord)entry.Entity).CreatedAt = DateTimeOffset.UtcNow;
                ((BaseTableRecord)entry.Entity).CreatedBy = Thread.CurrentPrincipal?.Identity?.Name ?? "unknown";
                ((BaseTableRecord)entry.Entity).ModifiedAt = null;
                ((BaseTableRecord)entry.Entity).ModifiedBy = null;
            }

            if (entry.State == EntityState.Modified)
            {
                ((BaseTableRecord)entry.Entity).ModifiedAt = DateTimeOffset.UtcNow;
                ((BaseTableRecord)entry.Entity).ModifiedBy = Thread.CurrentPrincipal?.Identity?.Name ?? "unknown";
            }
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("DataSource=:memory:");
        }
    }
}