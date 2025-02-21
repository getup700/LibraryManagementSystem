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
                @"INSERT INTO T_Permissions (Id,Name)
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
            var cmdTxt = @"DELETE FROM T_Permissions WHERE Id = @Id";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", id);
            conn.Open();
            var result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public List<Permission> GetAll()
        {
            var cmdTxt = @"SELECT * FROM T_Permissions";
            using var command = new SqlCommand(cmdTxt, conn);
            conn.Open();
            var reader = command.ExecuteReader();
            var result = new List<Permission>();
            while (reader.Read())
            {
                var item = InitialEnity(reader);
                result.Add(item);
            }
            conn.Close();
            return result;
        }

        public Permission GetById(Guid id)
        {
            var cmdTxt = @"SELECT * FROM T_Permissions WHERE Id = @Id";
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

        public List<Permission> GetByName(string name)
        {
            var cmdTxt = @"SELECT * FROM T_Permissions WHERE Name = @Name";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Name", name);
            conn.Open();
            var reader = command.ExecuteReader();
            var result = new List<Permission>();
            while (reader.Read())
            {
                var item = InitialEnity(reader);
                result.Add(item);
            }
            conn.Close();
            return result;
        }

        public int Update(Permission entity)
        {
            var cmdTxt =
                @"UPDATE INTO T_Permissions (Name)
                VALUES(@Name)";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Name", entity.Name);
            conn.Open();
            var result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        private Permission InitialEnity(SqlDataReader reader)
        {
            var item = new Permission();
            item.Id = reader.GetGuid(reader.GetOrdinal("Id"));
            item.Name = reader.GetString(reader.GetOrdinal("Name"));
            return item;


        }
    }
}
