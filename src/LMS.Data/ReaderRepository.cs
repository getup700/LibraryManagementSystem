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
        private readonly BookDbContext _dbContext;

        public ReaderRepository(BookDbContext bookDbContext)
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

        public List<Reader> GetAll()
        {
            return _dbContext.Readers.ToList();
        }

        public Reader GetById(long id)
        {
            return _dbContext.Readers
                .SingleOrDefault(x => x.Id == id);
        }

        public List<Reader> GetByName(string name)
        {
            return _dbContext.Readers
                .Where(x => x.Name.Contains(name))
                .ToList();
        }

        public void Add(Reader reader)
        {
            if (IsExist(reader.Id))
            {
                throw new Exception("用户已存在，无法重复添加");
            }
            _dbContext.Add(reader);
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            if (IsExist(id))
            {
                var reader = GetById(id);
                _dbContext.Readers.Remove(reader);
                _dbContext.SaveChanges();
            }
        }

        public void Update(Reader reader)
        {
            if (!IsExist(reader.Id))
            {
                throw new Exception("用户不存在，无法修改");
            }

            _dbContext.Update(reader);
            _dbContext.SaveChanges();
        }

        private bool IsExist(long id)
        {
            var reader = _dbContext.Readers.SingleOrDefault(x => x.Id == id); ;
            return reader == null;
        }
    }
}
