using LMS.Dal.Entities;
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

        public RoleDao(SqlConnection conn)
        {
            this.conn = conn;
        }

        public int Create(Role entity)
        {
            var cmdTxt =
                @"INSERT INTO T_Roles (Id,Name)
                VALUES(Id=@Id,Name=@Name)";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.Parameters.AddWithValue("@Name", entity.Name);
            conn.Open();
            var result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public int Delete(Guid id)
        {
            var cmdTxt = @"DELETE FROM T_Roles WHERE Id = @Id";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", id);
            conn.Open();
            var result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public List<Role> GetAll()
        {
            var cmdTxt = @"SELECT * FROM T_Roles";
            using var command = new SqlCommand(cmdTxt, conn);
            conn.Open();
            var reader = command.ExecuteReader();
            var result = new List<Role>();
            while (reader.Read())
            {
                var item = InitialEnity(reader);
                result.Add(item);
            }
            conn.Close();
            return result;
        }

        public Role GetById(Guid id)
        {
            var cmdTxt = @"SELECT * FROM T_Roles WHERE Id = @Id";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", id);
            conn.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = InitialEnity(reader);
                conn.Close();
                return item;
            }
            conn.Close();
            return null;
        }

        public List<Role> GetByName(string name)
        {
            var cmdTxt = @"SELECT * FROM T_Roles WHERE Name = @Name";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Name", name);
            conn.Open();
            var reader = command.ExecuteReader();
            var result = new List<Role>();
            while (reader.Read())
            {
                var item = InitialEnity(reader);
                result.Add(item);
            }
            conn.Close();
            return result;
        }

        public int Update(Role entity)
        {
            var cmdTxt =
                @"UPDATE INTO T_Roles (Name)
                VALUES(@Name)";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Name", entity.Name);
            conn.Open();
            var result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        private Role InitialEnity(SqlDataReader reader)
        {
            var item = new Role();
            item.Id = reader.GetGuid(reader.GetOrdinal("Id"));
            item.Name = reader.GetString(reader.GetOrdinal("Name"));
            return item;
        }

    }
}
