using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Dal.Entities
{
    public class RolePermission
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public Guid PermissionId { get; set; }
    }
}
