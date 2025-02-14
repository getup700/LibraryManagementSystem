using System;
using System.Collections.Generic;

namespace LMS.Models
{
    public partial class UserAccessFail
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public int AccessFailedCount { get; set; }
        public bool IsLockout { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
