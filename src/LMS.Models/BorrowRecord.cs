using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models
{
    /// <summary>
    /// 借阅记录
    /// </summary>
    public class BorrowRecord
    {
        /// <summary>
        /// 借阅记录Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 图书编号
        /// </summary>
        public Guid BookId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid? ReaderId { get; set; }

        /// <summary>
        /// 借书日期
        /// </summary>
        public DateTime BorrowDate { get; set; }

        /// <summary>
        /// 还书日期
        /// </summary>
        public DateTime? ReturnDate { get; set; }

        /// <summary>
        /// 是否归还
        /// </summary>
        public bool IsReturn => ReturnDate.HasValue;

        /// <summary>
        /// 导航属性（efcore)
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// 导航属性（efcore）
        /// </summary>
        public User User { get; set; }
    }
}
