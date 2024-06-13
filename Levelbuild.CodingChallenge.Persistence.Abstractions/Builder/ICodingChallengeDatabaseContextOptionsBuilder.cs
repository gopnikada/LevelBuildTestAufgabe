namespace Levelbuild.CodingChallenge.Persistence.Abstractions.Builder;

public interface ICodingChallengeDatabaseContextOptionsBuilder
{
    string ConnectionString { get; set; }
}