using Levelbuild.CodingChallenge.Domain.Abstractions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Levelbuild.CodingChallenge.Domain.Abstractions.Handlers;

public interface IGetAllCustomersHandler
{
    Task<IEnumerable<CustomerModel>> GetAllAsync();
}