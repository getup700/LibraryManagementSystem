using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Dal.Entities
{
    public class Role
    {
        public Guid Id { get; set; } = default!;

        public  string Name { get; set; } = default!;

        public string? Description { get; set; }

        public ICollection<Permission> Permissions { get; set; } = [];
    }
}
