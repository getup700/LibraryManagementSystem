using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Dal.Entities
{
    public class BookCategory
    {
        public Guid Id { get; set; }

        public string ISBN { get;set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public DateTime PublishDate { get; set; }

        public string Description { get; set; }



    }
}
