using System;
using System.Collections.Generic;
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

public class GetAllGetAllCustomersesHandler : IGetAllCustomersHandler
{
    private readonly CodingChallengeDataBaseContext dbContext;
    private readonly IMapper mapper;
    private readonly ILogger<GetAllGetAllCustomersesHandler> logger;

    public GetAllGetAllCustomersesHandler(CodingChallengeDataBaseContext dbContext, IMapper mapper, ILogger<GetAllGetAllCustomersesHandler> logger)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<IEnumerable<CustomerModel>> GetAllAsync()
    {
        this.logger.LogTrace($"Enter {nameof(this.GetAllAsync)}");

        try
        {
            try
            {
                IEnumerable<CustomerModel> customers = await this.GetAllInternallyAsync();
                return customers;
            }
            catch (Exception e)
            {
                throw new UnexpectedDomainException("Error while getting all customers", e);
            }
        }
        finally
        {
            this.logger.LogTrace($"Leave {nameof(this.GetAllAsync)}");
        }
    }

    private async Task<IEnumerable<CustomerModel>> GetAllInternallyAsync()
    {
        IEnumerable<CustomerTableRecord> customerTableRecords = await this.dbContext.Customers.AsNoTracking().ToListAsync().ConfigureAwait(false);

        IEnumerable<CustomerModel> customers = this.mapper.Map<IEnumerable<CustomerModel>>(customerTableRecords);

        return customers;
    }
}