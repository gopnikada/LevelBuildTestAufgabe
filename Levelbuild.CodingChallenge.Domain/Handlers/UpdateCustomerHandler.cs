using System;
using System.Linq;
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

public class UpdateCustomerHandler : IUpdateCustomerHandler
{
    private readonly CodingChallengeDataBaseContext dbContext;
    private readonly IMapper mapper;
    private readonly ILogger<UpdateCustomerHandler> logger;

    public UpdateCustomerHandler(CodingChallengeDataBaseContext dbContext, IMapper mapper, ILogger<UpdateCustomerHandler> logger)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Update(Guid guid, CreateCustomerRequestModel request)
    {
        this.logger.LogTrace($"Enter {nameof(this.Update)}");

        try
        {
            try
            {
                await this.UpdateInternallyAsync(guid, request).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new UnexpectedDomainException("Error while updating customer", e);
            }
        }
        finally
        {
            this.logger.LogTrace($"Leave {nameof(this.Update)}");
        }
    }

    private async Task UpdateInternallyAsync(Guid guid, CreateCustomerRequestModel request)
    {

        CustomerTableRecord customer = await this.dbContext.Customers.FindAsync(guid);

        if (customer == null)
        {
            throw new UnexpectedDomainException($"Customer not found by id {guid}");
        }

        customer.Name = request.Name;

        customer.WebSite = request.WebSite;

        this.dbContext.Entry(customer).State = EntityState.Modified;

        await this.dbContext.SaveChangesAsync().ConfigureAwait(false);
    }
}