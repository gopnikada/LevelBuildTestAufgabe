using System;
using System.Collections.Generic;
using System.Reflection;
using Levelbuild.CodingChallenge.Domain.Abstractions.Handlers;
using Levelbuild.CodingChallenge.Domain.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Levelbuild.CodingChallenge.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainComponents(this IServiceCollection services, ICollection<Assembly> mappingAssemblies)
    {
        mappingAssemblies = mappingAssemblies ?? throw new ArgumentNullException(nameof(mappingAssemblies));

        services = services ?? throw new ArgumentNullException(nameof(services));

        mappingAssemblies.Add(typeof(ServiceCollectionExtensions).Assembly);

        services.AddScoped<IGetAllCustomersHandler, GetAllGetAllCustomersesHandler>();
        services.AddScoped<IGetCustomerHandler, GetCustomerHandler>();
        services.AddScoped<ICreateCustomerHandler, CreateCustomerHandler>();

        return services;
    }
}