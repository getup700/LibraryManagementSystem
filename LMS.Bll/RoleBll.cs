using LMS.Dal;
using LMS.Dal.Entities;

namespace LMS.Bll
{
    public class RoleBll
    {
        private readonly RoleDao _roleDao;
        private readonly PermissionDao _permissionDao;
        private readonly RolePermissionDao _rolePermissionDao;
        private readonly PermissionBll _permissionBll;

        public RoleBll(RolePermissionDao rolePermissionDao, PermissionDao permissionDao, RoleDao roleDao, PermissionBll permissionBll)
        {
            _rolePermissionDao = rolePermissionDao;
            _permissionDao = permissionDao;
            _roleDao = roleDao;
            _permissionBll = permissionBll;
        }

        //public void UpdateRolePermissions(string roleName,ICollection<Permission> permissions)
        //{
        //    var role = _roleDao.GetByName(roleName).First();
        //    if (role == null)
        //    {
        //        throw new Exception($"不存在角色{roleName}");
        //    }
        //    foreach (Permission permission in permissions)
        //    {
        //        var rolePermission = new RolePermission();
        //        rolePermission.Id = Guid.NewGuid();
        //        rolePermission.RoleId = role.Id;
        //        rolePermission.PermissionId = permission.Id;
        //        _rolePermissionDao.Create(rolePermission);
        //    }
        //}

        /// <summary>
        /// 新增一个角色
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="description"></param>
        /// <param name="permissions"></param>
        public void Create(string roleName, string? description, ICollection<Permission> permissions)
        {
            var role = new Role()
            {
                Id = Guid.NewGuid(),
                Name = roleName,
                Description = description
            };
            _roleDao.Create(role);
            foreach (var item in role.Permissions)
            {
                var rolePermission = new RolePermission()
                {
                    Id = Guid.NewGuid(),
                    RoleId = role.Id,
                    PermissionId = item.Id
                };
                _rolePermissionDao.Create(rolePermission);
            }
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="role"></param>
        public void Delete(Role role)
        {
            _roleDao.Delete(role.Id);
            foreach (var item in role.Permissions)
            {
                _rolePermissionDao.Delete(item.Id);
            }
        }

        /// <summary>
        /// 通过角色Id查询角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public Role GetById(Guid roleId)
        {
            var role = _roleDao.GetById(roleId);
            var permissions = _rolePermissionDao.GetPermissionsByRoleId(roleId);
            role.Permissions = permissions;
            return role;
        }

        /// <summary>
        /// 通过名称查询角色
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Role? GetByName(string roleName)
        {
            var role = _roleDao.GetByName(roleName)?.First();
            if (role == null)
            {
                return role;
            }
            var permissions = _rolePermissionDao.GetPermissionsByRoleId(role.Id);
            role.Permissions = permissions;
            return role;
        }

        /// <summary>
        /// 获取所有角色及其权限
        /// </summary>
        /// <returns></returns>
        public List<Role> GetAll()
        {
            var result = new List<Role>();
            var roles = _roleDao.GetAll();
            foreach (var role in roles)
            {
                var permissions = _rolePermissionDao.GetPermissionsByRoleId(role.Id);
                role.Permissions = permissions;
                result.Add(role);
            }
            return result;
        }

        /// <summary>
        /// 更新角色的描述信息
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="description"></param>
        /// <exception cref="Exception"></exception>
        public void UpdateDescription(string roleName, string? description)
        {
            var role = GetByName(roleName)
                ?? throw new Exception($"不存在{roleName}");
            role.Description = description;
            _roleDao.Update(role);
        }

        /// <summary>
        /// 更新角色的权限
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="permissions"></param>
        /// <exception cref="Exception"></exception>
        public void UpdateRolePermissions(string roleName, ICollection<Permission> permissions)
        {
            var role = GetByName(roleName)
                ?? throw new Exception($"不存在{roleName}");
            var roleId = role.Id;
            var existedRolePermissions = _rolePermissionDao
                .GetAll()
                .Where(x => x.RoleId == roleId);
            foreach (var item in permissions)
            {
                //如果角色权限表里没有查到当前角色关系，则新增
                if (!existedRolePermissions.Any(x => x.PermissionId == item.Id))
                {
                    var newPermission = new RolePermission()
                    {
                        Id = Guid.NewGuid(),
                        RoleId = roleId,
                        PermissionId = item.Id
                    };

                    _rolePermissionDao.Create(newPermission);
                }

            }

        }


    }
}
