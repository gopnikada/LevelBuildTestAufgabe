using System;

namespace Levelbuild.CodingChallenge.Persistence.Abstractions.Models;

public class UserTableRecord : BaseTableRecord
{
    public string DisplayName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string DateOfBirth { get; set; }

    public Guid CustomerRefId { get; set; }

    public CustomerTableRecord Customer { get; }
}