namespace Levelbuild.CodingChallenge.Persistence.Abstractions.Builder;

public interface ICodingChallengeDatabaseContextOptionsBuilder
{
    public string ConnectionString { get; set; }
}