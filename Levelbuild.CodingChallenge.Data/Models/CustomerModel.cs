namespace Levelbuild.CodingChallenge.Domain.Abstractions.Models;

public class CustomerModel : BaseModel
{
    public string Name { get; set; }
    
    public string? WebSite { get; set; }
}