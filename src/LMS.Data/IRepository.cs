using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data
{
    /// <summary>
    /// 仓储层的增删查改
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 添加一个<see cref="T"/>
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// 删除一个<see cref="T"/>
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);

        /// <summary>
        /// 获取所有的<see cref="T"/>
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// 根据<paramref name="id"/>查询<see cref="T"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(long id);

        /// <summary>
        /// 更新<see cref="T"/>
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
    }
}
