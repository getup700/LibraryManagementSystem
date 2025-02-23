using LMS.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Bll
{
    public class PermissionBll
    {
        private readonly PermissionDao _permissionDao;

        public PermissionBll(PermissionDao permissionDao)
        {
            _permissionDao = permissionDao;
        }

        public void CreateOrUpdate(string permissionName, string permissionDescription)
        {
            var existedPermission = GetByName(permissionName);
            if (existedPermission != null)
            {
                Update(permissionName, permissionDescription);
            }
            else
            {
                var newPermission = new Permission()
                {
                    Id = Guid.NewGuid(),
                    Name = permissionName,
                    Description = permissionDescription
                };
                _permissionDao.Create(newPermission);
            }
        }

        public void Delete(string permissionName)
        {
            var existedPermission = GetByName(permissionName);
            if (existedPermission != null)
            {
                _permissionDao.Delete(existedPermission.Id);
            }
        }

        public Permission GetByName(string permissionName)
        {
            return _permissionDao.GetByName(permissionName).First();
        }

        public IEnumerable<Permission> GetAll()
        {
            return _permissionDao.GetAll();
        }

        public void Update(string permissionName, string permissionDescription)
        {
            var existedPermission = GetByName(permissionName);
            if(existedPermission != null)
            {
                existedPermission.Description = permissionDescription;
                _permissionDao.Update(existedPermission);
            }
        }
    }
}
