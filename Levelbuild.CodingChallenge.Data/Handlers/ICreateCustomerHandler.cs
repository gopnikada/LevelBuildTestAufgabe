using System.Threading.Tasks;
using Levelbuild.CodingChallenge.Domain.Abstractions.Models;

namespace Levelbuild.CodingChallenge.Domain.Abstractions.Handlers;

public interface ICreateCustomerHandler
{
    Task Create(CreateCustomerRequestModel request);
}