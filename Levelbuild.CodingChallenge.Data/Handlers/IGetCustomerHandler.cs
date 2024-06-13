using Levelbuild.CodingChallenge.Domain.Abstractions.Models;
using System.Threading.Tasks;
using System;

namespace Levelbuild.CodingChallenge.Domain.Abstractions.Handlers;

public interface IGetCustomerHandler
{
    Task<CustomerModel> GetAsync(Guid id);
}