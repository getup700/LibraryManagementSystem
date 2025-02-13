using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Reader
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 读者类型编号
        /// </summary>
        public long ReaderType { get; set; }

        /// <summary>
        /// 读者名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        public int QQ { get; set; }

        /// <summary>
        /// 已借书数量
        /// </summary>
        public int BorrowQuantity { get; set; }
    }
}
