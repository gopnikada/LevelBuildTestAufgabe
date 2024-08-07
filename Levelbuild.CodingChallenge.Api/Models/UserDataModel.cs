﻿using System;

namespace Levelbuild.CodingChallenge.Api.Models;

public class UserDataModel
{
    public string DisplayName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string DateOfBirth { get; set; }

    public Guid CustomerRefId { get; set; }
}