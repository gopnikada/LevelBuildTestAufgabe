using Levelbuild.CodingChallenge.Persistence.Abstractions.Builder;

namespace Levelbuild.CodingChallenge.Api.Configuration;

public class DataBaseSettings : ICodingChallengeDatabaseContextOptionsBuilder
{
    public string ConnectionString { get; set; }
}