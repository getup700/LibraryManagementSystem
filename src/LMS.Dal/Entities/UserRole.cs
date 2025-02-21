using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Dal.Entities
{
    /// <summary>
    /// 由于UserRole不在一个数据库中，多对一关系也需要建立一个中间表
    /// </summary>
    public class UserRole
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        
        public Guid RoleId { get; set; }
    }
}
