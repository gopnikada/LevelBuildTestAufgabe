using AutoMapper;
using Levelbuild.CodingChallenge.Domain.Abstractions.Models;
using Levelbuild.CodingChallenge.Domain.Exceptions;
using Levelbuild.CodingChallenge.Persistence.Abstractions.Models;
using Levelbuild.CodingChallenge.Persistence.Context;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Levelbuild.CodingChallenge.Domain.Abstractions.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Levelbuild.CodingChallenge.Domain.Handlers;

public class DeleteCustomerHandler : IDeleteCustomerHandler
{
    private readonly CodingChallengeDataBaseContext dbContext;
    private readonly IMapper mapper;
    private readonly ILogger<DeleteCustomerHandler> logger;

    public DeleteCustomerHandler(CodingChallengeDataBaseContext dbContext, IMapper mapper, ILogger<DeleteCustomerHandler> logger)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task DeleteAsync(Guid id)
    {
        this.logger.LogTrace($"Enter {nameof(this.DeleteAsync)}");

        try
        {
            try
            {
                await this.DeleteInternallyAsync(id).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new UnexpectedDomainException("Error while deleting customer", e);
            }
        }
        finally
        {
            this.logger.LogTrace($"Leave {nameof(this.DeleteAsync)}");
        }
    }

    private async Task DeleteInternallyAsync(Guid id)
    {
        CustomerTableRecord entity = await this.dbContext.Customers.FindAsync(id);

        if (entity == null)
        {
            throw new UnexpectedDomainException("Entity not found");
        }

        this.dbContext.Customers.Remove(entity);

        await this.dbContext.SaveChangesAsync();
    }
}