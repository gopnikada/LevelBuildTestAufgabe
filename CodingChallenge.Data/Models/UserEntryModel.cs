namespace Levelbuild.CodingChallenge.Data.Models;

public class UserEntryModel : BaseEntity
{
    public Guid CustomerId { get; set; }
    
    public CustomerEntryModel Customer { get; set; }
    
    public string DisplayName { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public DateTime DateOfBirth { get; set; }
}