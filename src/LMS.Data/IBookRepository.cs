using LMS.Models;
using System.Collections.Generic;

namespace LMS.Data
{
    public interface IBookRepository : IRepository<Book>
    {
        /// <summary>
        /// 通过名称查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<Book> GetByName(string name);
    }
}