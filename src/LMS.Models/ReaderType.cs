using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models
{
    /// <summary>
    /// 读者类别
    /// </summary>
    public class ReaderType
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 读者类型名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 可借书数量
        /// </summary>
        public int CanLendQuantity { get; set; }

        /// <summary>
        /// 可借书天数
        /// </summary>
        public int CanLendDay { get; set; }
    }
}
