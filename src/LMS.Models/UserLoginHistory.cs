using System;
using System.Collections.Generic;

namespace LMS.Models
{
    public partial class UserLoginHistory
    {
        public long Id { get; set; }
        public Guid? UserId { get; set; }
        public int PhoneNumberRegionNumber { get; set; }
        public string PhoneNumberNumber { get; set; } = null!;
        public DateTime CreatedDateTime { get; set; }
        public string Message { get; set; } = null!;
    }
}
