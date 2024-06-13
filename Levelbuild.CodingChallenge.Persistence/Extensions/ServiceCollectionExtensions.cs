using System;
using Levelbuild.CodingChallenge.Persistence.Abstractions.Builder;
using Levelbuild.CodingChallenge.Persistence.Builder;
using Levelbuild.CodingChallenge.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Levelbuild.CodingChallenge.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCodingChallengeDatabase(this IServiceCollection services,
        Action<ICodingChallengeDatabaseContextOptionsBuilder> optionsBuilderAction)
    {
        ICodingChallengeDatabaseContextOptionsBuilder optionsBuilder = new CodingChallengeDatabaseContextOptionsBuilder();
        optionsBuilderAction.Invoke(optionsBuilder);

        _ = services.AddSingleton<ICodingChallengeDatabaseContextOptionsBuilder>(optionsBuilder);

        _ = services.AddDbContext<CodingChallengeDataBaseContext>(options =>
        {
            options.UseSqlite(optionsBuilder.ConnectionString);
        });

        return services;
    }
}