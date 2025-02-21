using LMS.Dal.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Dal
{
    public class BookInstanceDao : IEntityDao<BookInstance>
    {
        SqlConnection conn;

        public BookInstanceDao(SqlConnection conn)
        {
            this.conn = conn;
        }

        public int Create(BookInstance entity)
        {
            var cmdTxt =
                @"CREATE INTO T_BookInstances (Id,CategoryId,Status)
                VALUES (@Id,@CategoryId,@Status)";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
            command.Parameters.AddWithValue("@Status", entity.Status);
            conn.Open();
            var result = command.ExecuteNonQuery();
            return result;
        }

        public int Delete(Guid id)
        {
            var cmdTxt = @"DELETE FROM T_BookInstances WHERE Id = @Id";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", id);
            conn.Open();
            var result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public List<BookInstance> GetAll()
        {
            var cmdTxt = @"SELECT * FROM T_BookInstances";
            using var command = new SqlCommand(cmdTxt, conn);
            conn.Open();
            var reader = command.ExecuteReader();
            var result = new List<BookInstance>();
            while (reader.Read())
            {
                var item = InitialEntity(reader);
                result.Add(item);
            }
            conn.Close();
            return result;
        }

        public BookInstance GetById(Guid id)
        {
            var cmdTxt = @"SELECT * FROM T_BookInstances WHERE Id = @Id";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", id);
            conn.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = InitialEntity(reader);
                conn.Close();
                return item;
            }
            conn.Close();
            return null;
        }

        public List<BookInstance> GetByName(string name)
        {
            var cmdTxt = @"SELECT * FROM T_BookInstances WHERE Name = @Name";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Name", name);
            conn.Open();
            var reader = command.ExecuteReader();
            var result = new List<BookInstance>();
            while (reader.Read())
            {
                var item = InitialEntity(reader);
                result.Add(item);
            }
            conn.Close();
            return result;
        }

        public int Update(BookInstance entity)
        {
            var cmdTxt =
                @"UPDATE T_BookInstances SET Status = @Status";
            using var command = new SqlCommand( cmdTxt, conn);
            command.Parameters.AddWithValue("@Status",entity.Status);
            conn.Open();
            var result = command.ExecuteNonQuery();
            return result;
        }

        private BookInstance InitialEntity(SqlDataReader reader)
        {
            var item = new BookInstance();
            item.Id = reader.GetGuid(reader.GetOrdinal("Id"));
            item.CategoryId = reader.GetGuid(reader.GetOrdinal("CategoryId"));
            item.Status = reader.GetString(reader.GetOrdinal("Status"));
            return item;
        }
    }
}
