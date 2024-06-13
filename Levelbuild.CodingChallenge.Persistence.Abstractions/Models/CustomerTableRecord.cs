using System.Collections.Generic;

namespace Levelbuild.CodingChallenge.Persistence.Abstractions.Models;

public class CustomerTableRecord : BaseTableRecord
{
    public string Name { get; set; }
    public string? WebSite { get; set; }

    public ICollection<UserTableRecord> Users { get; set; }
}