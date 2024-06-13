using Levelbuild.CodingChallenge.Persistence.Abstractions.Builder;

namespace Levelbuild.CodingChallenge.Persistence.Builder;

public class CodingChallengeDatabaseContextOptionsBuilder : ICodingChallengeDatabaseContextOptionsBuilder
{
    public string ConnectionString { get; set; }
}