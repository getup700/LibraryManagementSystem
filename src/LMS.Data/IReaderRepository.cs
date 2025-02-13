using LMS.Data;
using LMS.Models;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public interface IReaderRepository:IRepository<Reader>
    {
        List<Reader> GetByName(string name);
    }
}