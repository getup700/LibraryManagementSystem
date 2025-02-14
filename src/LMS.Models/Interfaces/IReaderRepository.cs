using LMS.Data;
using LMS.Models;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public interface IReaderRepository:IRepository<User>
    {
        List<User> GetByName(string name);
    }
}