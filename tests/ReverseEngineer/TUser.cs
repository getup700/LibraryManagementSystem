using System;
using System.Collections.Generic;

namespace ReverseEngineer;

public partial class TUser
{
    public Guid Id { get; set; }

    public int State { get; set; }

    public int PhoneNumberRegionNumber { get; set; }

    public string PhoneNumberNumber { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime RegistrationTime { get; set; }

    public string? PasswordHash { get; set; }

    public string Name { get; set; } = null!;

    public virtual TUserAccessFail? TUserAccessFail { get; set; }
}
