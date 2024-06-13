using System;

namespace Levelbuild.CodingChallenge.Persistence.Abstractions.Models;

public class BaseTableRecord
{
    public Guid Id { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public string CreatedBy { get; set; }
    
    public DateTimeOffset? ModifiedAt { get; set; }

    public string ModifiedBy { get; set; }
}