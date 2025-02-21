using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Dal.Entities
{
    public class BorrowRecord
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }

        public Guid UserId { get; set; }

        public DateTime BorrowTime { get; set; }

        public DateTime PlannedReturnTime { get; set; }

        public DateTime ActualReturnTime { get; set; }
    }
}
