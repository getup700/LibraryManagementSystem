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
    public class BookCategoryDao : IEntityDao<BookCategory>
    {
        SqlConnection conn;

        public BookCategoryDao(SqlConnection conn)
        {
            this.conn = conn;
        }

        public int Update(BookCategory bookCategory)
        {
            var cmdTxt =
                @"UPDATE T_BookCategories
                SET Name = @Name,
                WHERE Id = @Id";
            var command = new SqlCommand(cmdTxt, conn);
            conn.OpenIfClosed();
            command.Parameters.AddWithValue("@Id", bookCategory.Id);
            command.Parameters.AddWithValue("@ISBN", bookCategory.ISBN);
            command.Parameters.AddWithValue("@Name", bookCategory.Name);
            command.Parameters.AddWithValue("@Author", bookCategory.Author);
            command.Parameters.AddWithValue("@Publisher", bookCategory.Publisher);
            command.Parameters.AddWithValue("@PublishDate", bookCategory.PublishDate);
            command.Parameters.AddWithValue("@Description", bookCategory.Description);
            var result = command.ExecuteNonQuery();
            conn.CloseIfOpen();
            return result;
        }

        public List<BookCategory> GetAll()
        {
            var cmdTxt = @"SELECT * FROM T_BookCategories";
            using var command = new SqlCommand(cmdTxt, conn);
            conn.OpenIfClosed();
            var reader = command.ExecuteReader();
            var result = new List<BookCategory>();
            while (reader.Read())
            {
                var item = InitialEntity(reader);
                result.Add(item);
            }
            return result;
        }

        public List<BookCategory> GetByName(string name)
        {
            var cmdTxt = @"SELECT * FROM T_BookCategories WHERE Name = @Name";
            using var command = new SqlCommand(cmdTxt, conn);
            conn.OpenIfClosed();
            command.Parameters.AddWithValue("@Name", name);
            var reader = command.ExecuteReader();
            var result = new List<BookCategory>();
            while (reader.Read())
            {
                var item = InitialEntity(reader);
                result.Add(item);
            }
            return result;
        }

        public BookCategory GetById(Guid bookCategoryId)
        {
            var cmdTxt = @"SELECT * FROM T_BookCategories WHERE Id = @BookCategoryId";
            using var command = new SqlCommand(cmdTxt, conn);
            conn.OpenIfClosed();
            command.Parameters.AddWithValue("BookCategoryId", bookCategoryId);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = InitialEntity(reader);
                return item;
            }
            return null;
        }

        public int Delete(Guid bookCategoryId)
        {
            var cmdTxt = "DELETE FROM T_BookCategories WHERE CategoryId = @CategoryId";
            using var command = new SqlCommand(cmdTxt, conn);
            conn.OpenIfClosed();
            command.Parameters.AddWithValue("@CategoryId", bookCategoryId);
            var result = command.ExecuteNonQuery();
            return result;

        }

        public int Create(BookCategory bookCategory)
        {
            var cmdTxt =
                @"INSERT INTO T_BookCategories (Id,ISBN,Name,Author,Publisher,PublishDate,Description)
                VALUES (@Id,@ISBN,@Name,@Author,@Publisher,@PublishDate,@Description)";
            using var command = new SqlCommand(cmdTxt, conn);
            conn.OpenIfClosed();
            command.Parameters.AddWithValue("@Id", bookCategory.Id);
            command.Parameters.AddWithValue("@ISBN", bookCategory.ISBN);
            command.Parameters.AddWithValue("@Name", bookCategory.Name);
            command.Parameters.AddWithValue("@Author", bookCategory.Author);
            command.Parameters.AddWithValue("@Publisher", bookCategory.Publisher);
            command.Parameters.AddWithValue("@PublishDate", bookCategory.PublishDate);
            command.Parameters.AddWithValue("@Description", bookCategory.Description);
            var result = command.ExecuteNonQuery();
            return result;

        }

        private BookCategory InitialEntity(SqlDataReader reader)
        {
            var id = reader.GetGuid(reader.GetOrdinal("Id"));
            var item = new BookCategory();
            item.Id = id;
            item.Author = reader.GetString(reader.GetOrdinal("Author"));
            item.ISBN = reader.GetString(reader.GetOrdinal("ISBN"));
            item.Publisher = reader.GetString(reader.GetOrdinal("Publisher"));
            item.PublishDate = reader.GetDateTime(reader.GetOrdinal("PublishDate"));
            item.Description = reader.GetString(reader.GetOrdinal("Description"));
            item.Name = reader.GetString(reader.GetOrdinal("Name"));
            return item;
        }
    }
}
