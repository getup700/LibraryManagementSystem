using System;
using System.Collections.Generic;

namespace ReverseEngineer;

public partial class TUserAccessFail
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public DateTime? LockoutEnd { get; set; }

    public int AccessFailedCount { get; set; }

    public bool IsLockout { get; set; }

    public virtual TUser User { get; set; } = null!;
}
