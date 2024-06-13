using System;

namespace Levelbuild.CodingChallenge.Domain.Exceptions;

public class UnexpectedDomainException : Exception
{
    public UnexpectedDomainException(string message) : base(message)
    {
        
    } 
    public UnexpectedDomainException(string message, Exception exception) : base(message, exception)
    {
        
    }
}