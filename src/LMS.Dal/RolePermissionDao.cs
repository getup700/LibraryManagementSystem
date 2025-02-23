using LMS.Dal.Entities;
using LMS.Dal.Extensions;
using LMS.Dal.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Dal
{
    public class RolePermissionDao
    {
        SqlConnection conn;

        public RolePermissionDao()
        {
            conn = ConnUtil.GetBookConnection();
        }


        public int Create(RolePermission entity)
        {
            var cmdTxt =
                @"INSERT INTO T_Role_Permission (Id,RoleId,PermissionId)
                VALUES(@Id,@RoleId,@PermissionId)";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.Parameters.AddWithValue("@Name", entity.RoleId);
            command.Parameters.AddWithValue("@Description", entity.PermissionId);
            conn.OpenIfClosed();
            var result = command.ExecuteNonQuery();
            conn.CloseIfOpen();
            return result;
        }

        public int Delete(Guid id)
        {
            var cmdTxt = @"DELETE FROM T_Role_Permission WHERE Id = @Id";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", id);
            conn.OpenIfClosed();
            var result = command.ExecuteNonQuery();
            conn.CloseIfOpen();
            return result;
        }

        public List<RolePermission> GetAll()
        {
            var cmdTxt = @"SELECT * FROM T_Role_Permission";
            using var command = new SqlCommand(cmdTxt, conn);
            conn.OpenIfClosed();
            var reader = command.ExecuteReader();
            var result = new List<RolePermission>();
            while (reader.Read())
            {
                var item = InitialEnity(reader);
                result.Add(item);
            }
            conn.CloseIfOpen();
            return result;
        }

        public List<Guid> GetRoleIdsByPermissionId(Guid permissionId)
        {
            var cmdTxt =
                @"SELECT RoleId
                FROM T_Role_Permission
                WHERE PermissionId = @Permissionid";
            using var command = new SqlCommand( cmdTxt, conn);
            command.Parameters.AddWithValue("@PermissionId", permissionId);
            conn.OpenIfClosed();
            var reader = command.ExecuteReader();
            var result = new List<Guid>();
            while (reader.Read())
            {
                var item = reader.GetGuid(reader.GetOrdinal("RoleId"));
                result.Add(item);
            }
            conn.CloseIfOpen();
            return result;
        }

        public List<Permission> GetPermissionsByRoleId(Guid roleId)
        {
            var cmdTxt =
                @"SELECT * 
                FROM T_Role_Permission 
                WHERE RoleId = @RoleId";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@RoleId", roleId);
            conn.OpenIfClosed();
            var reader = command.ExecuteReader();
            var result = new List<Permission>();
            while (reader.Read())
            {
                var permission = new Permission();
                permission.Id = reader.GetGuid(reader.GetOrdinal("Id"));
                permission.Name = reader.GetString(reader.GetOrdinal("Name"));
                permission.Description = reader.GetString(reader.GetOrdinal("Description"));
                result.Add(permission);
            }
            conn.CloseIfOpen();
            return result;
        }


        public int Update(RolePermission entity)
        {
            var cmdTxt =
                @"UPDATE T_Role_Permission (RoleId,PermissionId)
                VALUES(@RoleId,@PermissionId)
                WHERE Id = @Id";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.Parameters.AddWithValue("@RoleId", entity.RoleId);
            command.Parameters.AddWithValue("@PermissionId", entity.PermissionId);
            conn.OpenIfClosed();
            var result = command.ExecuteNonQuery();
            conn.CloseIfOpen();
            return result;
        }

        private RolePermission InitialEnity(SqlDataReader reader)
        {
            var item = new RolePermission();
            item.Id = reader.GetGuid(reader.GetOrdinal("Id"));
            item.RoleId = reader.GetGuid(reader.GetOrdinal("RoleId"));
            item.PermissionId = reader.GetGuid(reader.GetOrdinal("PermissionId"));
            return item;
        }

    }
}
