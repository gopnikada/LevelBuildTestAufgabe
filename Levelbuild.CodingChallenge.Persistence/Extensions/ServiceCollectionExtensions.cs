using System;
using Levelbuild.CodingChallenge.Persistence.Abstractions.Builder;
using Levelbuild.CodingChallenge.Persistence.Abstractions.Models;
using Levelbuild.CodingChallenge.Persistence.Builder;
using Levelbuild.CodingChallenge.Persistence.Context;
using Microsoft.Data.Sqlite;
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

        var keepAliveConnection = new SqliteConnection(optionsBuilder.ConnectionString);

        keepAliveConnection.Open();

        services.AddDbContext<CodingChallengeDataBaseContext>(options =>
        {
            options.UseSqlite(keepAliveConnection);
        });

        FillWithTestData(services);

        return services;
    }

    private static void FillWithTestData(IServiceCollection services)
    {
        using (CodingChallengeDataBaseContext context = services.BuildServiceProvider().GetRequiredService<CodingChallengeDataBaseContext>())
        {
            context.Database.EnsureCreated();

            // Add a user
            var customerIdOne = Guid.NewGuid();
            var customerIdTwo = Guid.NewGuid();

            context.Customers.Add(new CustomerTableRecord
            {
                Id = customerIdOne,
                Name = "Customer1Name",
                Website = "213"
            }); 
            
            context.Customers.Add(new CustomerTableRecord
            {
                Id = customerIdTwo,
                Name = "Customer2Name",
                Website = "213"
            });

            context.Users.Add(new UserTableRecord
            {
                Id = Guid.NewGuid(),
                DisplayName = "User1DN",
                FirstName = "User1FN",
                LastName = "User1lN",
                DateOfBirth = "User1DN",
                Email = "User1Email",
                CustomerRefId = customerIdOne
            });

            context.Users.Add(new UserTableRecord
            {
                Id = Guid.NewGuid(),
                DisplayName = "User2DN",
                FirstName = "User2FN",
                LastName = "User2lN",
                DateOfBirth = "User2DN",
                Email = "User2Email",
                CustomerRefId = customerIdOne
            });

            context.Users.Add(new UserTableRecord
            {
                Id = Guid.NewGuid(),
                DisplayName = "User3DN",
                FirstName = "User3fN",
                LastName = "User3lN",
                DateOfBirth = "User3DN",
                Email = "User3Email",
                CustomerRefId = customerIdTwo
            });

            context.Users.Add(new UserTableRecord
            {
                Id = Guid.NewGuid(),
                DisplayName = "User4DN",
                FirstName = "User4fN",
                LastName = "User4lN",
                DateOfBirth = "User4DN",
                Email = "User4Email",
                CustomerRefId = customerIdTwo
            });


            context.SaveChanges();

            Console.WriteLine("User added to the database.");
        }
    }
}