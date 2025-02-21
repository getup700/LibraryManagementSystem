using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Dal.Entities
{
    public class BookInstance
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public string Status { get; set; }
    }
}
