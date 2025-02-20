using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Dal.Entities
{
    internal class Book
    {
        public Guid Id { get; set; }

        public string ISBM { get;set; }

        public string Name { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        = DateTime.Now;

        public int Count { get; set; }

    }
}
