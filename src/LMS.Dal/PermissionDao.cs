using LMS.Dal.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Dal.Entities
{
    public class PermissionDao : IEntityDao<Permission>
    {
        SqlConnection conn;

        public PermissionDao(SqlConnection conn)
        {
            this.conn = conn;
        }

        public int Create(Permission entity)
        {
            var cmdTxt =
                @"INSERT INTO T_Permissions (Id,Name,Description)
                VALUES(@Id,@Name,@Description)";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Description", entity.Description);
            conn.OpenIfClosed();
            var result = command.ExecuteNonQuery();
            conn.CloseIfOpen();
            return result;
        }

        public int Delete(Guid id)
        {
            var cmdTxt = @"DELETE FROM T_Permissions WHERE Id = @Id";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", id);
            conn.OpenIfClosed();
            var result = command.ExecuteNonQuery();
            conn.CloseIfOpen();
            return result;
        }

        public List<Permission> GetAll()
        {
            var cmdTxt = @"SELECT * FROM T_Permissions";
            using var command = new SqlCommand(cmdTxt, conn);
            conn.OpenIfClosed();
            var reader = command.ExecuteReader();
            var result = new List<Permission>();
            while (reader.Read())
            {
                var item = InitialEnity(reader);
                result.Add(item);
            }
            conn.CloseIfOpen();
            return result;
        }

        public Permission GetById(Guid id)
        {
            var cmdTxt = @"SELECT * FROM T_Permissions WHERE Id = @Id";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", id);
            conn.OpenIfClosed();
            var reader = command.ExecuteReader();
            if (!reader.Read())
            {
                throw new Exception("未读取到数据");
            }
            var item = InitialEnity(reader);
            conn.CloseIfOpen();
            return item;
        }

        public List<Permission> GetByName(string name)
        {
            var cmdTxt = @"SELECT * FROM T_Permissions WHERE Name = @Name";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Name", name);
            conn.OpenIfClosed();
            var reader = command.ExecuteReader();
            var result = new List<Permission>();
            while (reader.Read())
            {
                var item = InitialEnity(reader);
                result.Add(item);
            }
            conn.CloseIfOpen();
            return result;
        }

        public int Update(Permission entity)
        {
            var cmdTxt =
                @"UPDATE T_Permissions
                SET Name = @Name,Description = @Description
                WHERE Id = @Id";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Description", entity.Description);
            conn.OpenIfClosed();
            var result = command.ExecuteNonQuery();
            conn.CloseIfOpen();
            return result;
        }

        private Permission InitialEnity(SqlDataReader reader)
        {
            var item = new Permission();
            item.Id = reader.GetGuid(reader.GetOrdinal("Id"));
            item.Name = reader.GetString(reader.GetOrdinal("Name"));
            item.Description = reader.GetString(reader.GetOrdinal("Description"));
            return item;


        }
    }
}
