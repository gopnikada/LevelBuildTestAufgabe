
namespace Levelbuild.CodingChallenge.Api.Models;

public class CustomerDataModel
{
    public string Name { get; set; }

    public string? WebSite { get; set; }

    public UserDataModel[] Users { get; set; }
}