using Levelbuild.CodingChallenge.Domain.Abstractions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Levelbuild.CodingChallenge.Domain.Abstractions.Handlers;

public interface ICustomerHandler
{
    Task<IEnumerable<CustomerModel>> GetAllAsync();
}