using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// 通过id查询用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<User?> FindByIdAsync(Guid userId);

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetAllAsync();

        /// <summary>
        /// 获取所有用户（包含已经注销的）
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetAllIncludeLogoffAsync();
    }
}
