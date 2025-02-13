using LMS.Models;
using LMS.Models.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data
{
    internal class BorrowRepository : IBorrowRepository
    {
        private readonly BookDbContext _dbContext;

        public BorrowRepository(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 获取所有借阅记录
        /// </summary>
        /// <returns></returns>
        public List<BorrowRecord> GetAll()
        {
            return _dbContext.BorrowRecords
                .Include(x => x.Book)
                .Include(x => x.Reader)
                .ToList();
        }

        /// <summary>
        /// 根据用户Id查询借阅记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<BorrowRecord> GetByUserId(int userId)
        {
            return _dbContext.BorrowRecords
                .Where(x => x.ReaderId == userId)
                .Include(x => x.Book)
                .Include(x => x.Reader)
                .ToList();
        }

        /// <summary>
        /// 添加借阅记录
        /// </summary>
        /// <param name="record"></param>
        public void Add(BorrowRecord record)
        {
            _dbContext.BorrowRecords.Add(record);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 归还书籍
        /// </summary>
        /// <param name="recordId"></param>
        public void ReturnBook(int recordId)
        {
            var borrowRecord = _dbContext.BorrowRecords
                .FirstOrDefault(x => x.Id == recordId);
            if (borrowRecord != null && !borrowRecord.IsReturn)
            {
                borrowRecord.ReturnDate = DateTime.Now;
                _dbContext.SaveChanges();
            }
        }

    }
}
