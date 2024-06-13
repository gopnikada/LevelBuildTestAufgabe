using System;

namespace Levelbuild.CodingChallenge.Domain.Abstractions.Models;

public class BaseModel
{
    public Guid Id { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public string CreatedBy { get; set; }

    public DateTimeOffset? ModifiedAt { get; set; }

    public string ModifiedBy { get; set; }
}