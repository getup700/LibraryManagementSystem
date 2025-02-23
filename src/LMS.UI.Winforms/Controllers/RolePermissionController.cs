using LMS.Bll;
using LMS.Dal;
using LMS.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.UI.Winforms.Controllers
{
    public class RolePermissionController
    {
        RoleBll _roleBll;
        PermissionBll _permissionBll;

        public RolePermissionController(PermissionBll permissionBll, RoleBll roleBll)
        {
            _permissionBll = permissionBll;
            _roleBll = roleBll;
        }

        public void Create(string roleName, string? description, ICollection<Permission> permissions)
        {
            _roleBll.Create(roleName, description, permissions);
        }

        public void Delete(Role role)
        {
            _roleBll.Delete(role);
        }

        public IEnumerable<Role> GetAll()
        {
            return _roleBll.GetAll();
        }


        public void Update(Role role)
        {
            _roleBll.UpdateDescription(role.Name, role.Description);
            _roleBll.UpdateRolePermissions(role.Name, role.Permissions);
        }
    }
}
