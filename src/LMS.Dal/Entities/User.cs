using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Dal.Entities
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
            RegistrationTime = DateTime.Now;
        }

        public User(Guid userId)
        {
            Id = userId;
        }

        public Guid Id { get; private set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Age
        {
            get
            {
                var time = DateTime.Now - BirthDay;
                if(time.HasValue)
                {
                    return (int)(time.Value.TotalDays / 365);
                }
                else
                {
                    return 0;
                }
            }
        }

        public string PhoneNumber { get; set; }

        public DateTime? RegistrationTime { get; set; }

        public DateTime? BirthDay { get; set; }

        public Role Role { get; set; }

    }
}
