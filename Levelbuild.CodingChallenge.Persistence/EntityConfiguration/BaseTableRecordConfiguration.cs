using System;
using System.Linq.Expressions;
using Levelbuild.CodingChallenge.Persistence.Abstractions.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Levelbuild.CodingChallenge.Persistence.EntityConfiguration;

public class BaseTableRecordConfiguration
{
    public static void Configure<T>(EntityTypeBuilder<T> entity) where T : BaseTableRecord
    {
        entity.HasKey(x => x.Id);
        entity.Property(x => x.Id).ValueGeneratedOnAdd().HasValueGenerator<SequentialGuidValueGenerator>();
        entity.Property(x => x.ModifiedBy).HasMaxLength(450);
        entity.Property(x => x.CreatedBy).HasMaxLength(450);
    }
}