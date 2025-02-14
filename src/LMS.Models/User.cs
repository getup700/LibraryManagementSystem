using System;
using System.Collections.Generic;

namespace LMS.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public int State { get; set; }
        public int PhoneNumberRegionNumber { get; set; }
        public string PhoneNumberNumber { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime RegistrationTime { get; set; }
        public string? PasswordHash { get; set; }
        public string Name { get; set; } = null!;

        public virtual UserAccessFail? UserAccessFail { get; set; }

        public Guid RoleId { get; set; }
        
        public Role Role { get; set; }
    }
}
