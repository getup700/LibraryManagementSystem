using LMS.Dal.Entities;
using LMS.Dal.Extensions;
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
                @"INSERT INTO T_BookInstances (Id,CategoryId,Status)
                VALUES (@Id,@CategoryId,@Status)";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
            command.Parameters.AddWithValue("@Status", entity.Status);
            conn.OpenIfClosed();
            var result = command.ExecuteNonQuery();
            conn.CloseIfOpen();
            return result;
        }

        public int Delete(Guid id)
        {
            var cmdTxt = @"DELETE FROM T_BookInstances WHERE Id = @Id";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", id);
            conn.OpenIfClosed();
            var result = command.ExecuteNonQuery();
            conn.CloseIfOpen();
            return result;
        }

        public List<BookInstance> GetAll()
        {
            var cmdTxt = @"SELECT * FROM T_BookInstances";
            using var command = new SqlCommand(cmdTxt, conn);
            conn.OpenIfClosed();
            var reader = command.ExecuteReader();
            var result = new List<BookInstance>();
            while (reader.Read())
            {
                var item = InitialEntity(reader);
                result.Add(item);
            }
            conn.CloseIfOpen();
            return result;
        }

        public BookInstance GetById(Guid id)
        {
            var cmdTxt = @"SELECT * FROM T_BookInstances WHERE Id = @Id";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Id", id);
            conn.OpenIfClosed();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = InitialEntity(reader);
                conn.CloseIfOpen();
                return item;
            }
            conn.CloseIfOpen();
            throw new Exception();
        }

        public List<BookInstance> GetByName(string name)
        {
            var cmdTxt = @"SELECT * FROM T_BookInstances WHERE Name = @Name";
            using var command = new SqlCommand(cmdTxt, conn);
            command.Parameters.AddWithValue("@Name", name);
            conn.OpenIfClosed();
            var reader = command.ExecuteReader();
            var result = new List<BookInstance>();
            while (reader.Read())
            {
                var item = InitialEntity(reader);
                result.Add(item);
            }
            conn.CloseIfOpen();
            return result;
        }

        public int Update(BookInstance entity)
        {
            var cmdTxt =
                @"UPDATE T_BookInstances 
                SET Status = @Status
                WHERE Id = @Id";
            using var command = new SqlCommand( cmdTxt, conn);
            command.Parameters.AddWithValue("@Id",entity.Id);
            command.Parameters.AddWithValue("@Status",entity.Status);
            conn.OpenIfClosed();
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
