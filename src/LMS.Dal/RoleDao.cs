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
    public class RoleDao : IEntityDao<Role>
    {
        SqlConnection conn;

        public RoleDao()
        {
            conn = ConnUtil.GetBookConnection();
        }

        public RoleDao(SqlConnection conn)
        {
            this.conn = conn;
        }

        public int Create(Role entity)
        {
            var cmdTxt =
                @"INSERT INTO T_Roles (Id,Name,Description)
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
            var cmdTxt = @"DELETE FROM T_Roles WHERE Id = @Id";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", id);
            conn.OpenIfClosed();
            var result = command.ExecuteNonQuery();
            conn.CloseIfOpen();
            return result;
        }

        public List<Role> GetAll()
        {
            var cmdTxt = @"SELECT * FROM T_Roles";
            using var command = new SqlCommand(cmdTxt, conn);
            conn.OpenIfClosed();
            var reader = command.ExecuteReader();
            var result = new List<Role>();
            while (reader.Read())
            {
                var item = InitialEnity(reader);

                result.Add(item);
            }
            conn.CloseIfOpen();
            return result;
        }

        public Role GetById(Guid id)
        {
            var cmdTxt = @"SELECT * FROM T_Roles WHERE Id = @Id";
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

        public List<Role> GetByName(string name)
        {
            var cmdTxt = @"SELECT * FROM T_Roles WHERE Name = @Name";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Name", name);
            conn.OpenIfClosed();
            var reader = command.ExecuteReader();
            var result = new List<Role>();
            while (reader.Read())
            {
                var item = InitialEnity(reader);
                result.Add(item);
            }
            conn.CloseIfOpen();
            return result;
        }

        public int Update(Role entity)
        {
            var cmdTxt =
                @"UPDATE T_Roles (Name,Description)
                VALUES(@Name,@Description)
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

        private Role InitialEnity(SqlDataReader reader)
        {
            var item = new Role();
            item.Id = reader.GetGuid(reader.GetOrdinal("Id"));
            item.Name = reader.GetString(reader.GetOrdinal("Name"));
            item.Description = reader.GetString(reader.GetOrdinal("Description"));
            return item;
        }

    }
}
