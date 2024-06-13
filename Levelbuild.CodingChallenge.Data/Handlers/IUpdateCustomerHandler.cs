using System;
using Levelbuild.CodingChallenge.Domain.Abstractions.Models;
using System.Threading.Tasks;

namespace Levelbuild.CodingChallenge.Domain.Abstractions.Handlers;

public interface IUpdateCustomerHandler
{
    Task Update(Guid id, CreateCustomerRequestModel request);
}