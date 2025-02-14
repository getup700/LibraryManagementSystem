using LMS.Models;
using System;
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
        BorrowRecord GetById(Guid id);

        /// <summary>
        /// 查询指定用户的借阅记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<BorrowRecord> GetByUserId(Guid userId);

        /// <summary>
        /// 还书
        /// </summary>
        /// <param name="recordId"></param>
        void ReturnBook(Guid recordId);
    }
}