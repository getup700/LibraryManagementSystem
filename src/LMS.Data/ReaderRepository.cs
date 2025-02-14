using LMS.Models;
using LMS.Models.DbContexts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibraryManagementSystem
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly UserIdentityContext _dbContext;

        public ReaderRepository(UserIdentityContext bookDbContext)
        {
            _dbContext = bookDbContext;
        }

        public DataTable GetReaders()
        {
            using var conn = new SqlConnection();
            var sql = "SELECT * FROM Reader";
            using var dataAdapter = new SqlDataAdapter(sql, conn);
            var dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return _dbContext.Users
                .SingleOrDefault(x => x.Id == id);
        }

        public List<User> GetByName(string name)
        {
            return _dbContext.Users
                .Where(x => x.Name.Contains(name))
                .ToList();
        }

        public void Add(User reader)
        {
            if (IsExist(reader.Id))
            {
                throw new Exception("用户已存在，无法重复添加");
            }
            _dbContext.Add(reader);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            if (IsExist(id))
            {
                var reader = GetById(id);
                _dbContext.Users.Remove(reader);
                _dbContext.SaveChanges();
            }
        }

        public void Update(User reader)
        {
            if (!IsExist(reader.Id))
            {
                throw new Exception("用户不存在，无法修改");
            }

            _dbContext.Update(reader);
            _dbContext.SaveChanges();
        }

        private bool IsExist(Guid id)
        {
            var reader = _dbContext.Users.SingleOrDefault(x => x.Id == id); ;
            return reader == null;
        }
    }
}
