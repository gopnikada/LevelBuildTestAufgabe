using System;
using System.Threading.Tasks;
using AutoMapper;
using Levelbuild.CodingChallenge.Domain.Abstractions.Handlers;
using Levelbuild.CodingChallenge.Domain.Abstractions.Models;
using Levelbuild.CodingChallenge.Domain.Exceptions;
using Levelbuild.CodingChallenge.Persistence.Abstractions.Models;
using Levelbuild.CodingChallenge.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Levelbuild.CodingChallenge.Domain.Handlers;

public class CreateCustomerHandler : ICreateCustomerHandler
{
    private readonly CodingChallengeDataBaseContext dbContext;
    private readonly IMapper mapper;
    private readonly ILogger<CreateCustomerHandler> logger;

    public CreateCustomerHandler(CodingChallengeDataBaseContext dbContext, IMapper mapper, ILogger<CreateCustomerHandler> logger)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Create(CreateCustomerRequestModel request)
    {
        this.logger.LogTrace($"Enter {nameof(this.Create)}");

        try
        {
            try
            {
                await this.CreateInternallyAsync(request).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new UnexpectedDomainException("Error while creating customer", e);
            }
        }
        finally
        {
            this.logger.LogTrace($"Leave {nameof(this.Create)}");
        }
    }

    private async Task CreateInternallyAsync(CreateCustomerRequestModel request)
    {

        this.dbContext.Customers.Add(new CustomerTableRecord
        {
            Name = request.Name,
            WebSite = request.WebSite
        });

        await this.dbContext.SaveChangesAsync().ConfigureAwait(false);
    }
}