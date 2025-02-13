using LMS.Models;
using System.Collections.Generic;

namespace LMS.Data
{
    public interface IBorrowRepository
    {
        /// <summary>
        /// 添加一条借阅记录
        /// </summary>
        /// <param name="record"></param>
        void Add(BorrowRecord record);

        /// <summary>
        /// 查询所有借阅记录
        /// </summary>
        /// <returns></returns>
        List<BorrowRecord> GetAll();

        /// <summary>
        /// 查询指定用户的借阅记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<BorrowRecord> GetByUserId(int userId);

        /// <summary>
        /// 还书
        /// </summary>
        /// <param name="recordId"></param>
        void ReturnBook(int recordId);
    }
}