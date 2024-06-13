using System;
using System.Collections.Generic;
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

public class GetCustomerHandler : IGetCustomerHandler
{
    private readonly CodingChallengeDataBaseContext dbContext;
    private readonly IMapper mapper;
    private readonly ILogger<GetCustomerHandler> logger;

    public GetCustomerHandler(CodingChallengeDataBaseContext dbContext, IMapper mapper, ILogger<GetCustomerHandler> logger)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<CustomerModel> GetAsync(Guid id)
    {
        this.logger.LogTrace($"Enter {nameof(this.GetAsync)}");

        try
        {
            try
            {
                CustomerModel customer = await this.GetInternallyAsync(id);
                return customer;
            }
            catch (Exception e)
            {
                throw new UnexpectedDomainException("Error while getting customer", e);
            }
        }
        finally
        {
            this.logger.LogTrace($"Leave {nameof(this.GetAsync)}");
        }
    }

    private async Task<CustomerModel> GetInternallyAsync(Guid id)
    {
        CustomerTableRecord customerTableRecord = await this.dbContext.Customers.AsNoTracking().SingleOrDefaultAsync(x=>x.Id == id).ConfigureAwait(false);

        CustomerModel customer = this.mapper.Map<CustomerModel>(customerTableRecord);

        return customer;
    }
}