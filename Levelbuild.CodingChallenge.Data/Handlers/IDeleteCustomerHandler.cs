using System;
using System.Threading.Tasks;

namespace Levelbuild.CodingChallenge.Domain.Abstractions.Handlers;

public interface IDeleteCustomerHandler
{
    Task DeleteAsync(Guid guid);
}