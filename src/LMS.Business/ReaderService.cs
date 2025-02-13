using LibraryManagementSystem;
using System;
using System.Data;

namespace LMS.Business
{
    public class ReaderService
    {
        public DataTable GetReaders()
        {
            var dal = new ReaderRepository();
            var dt = dal.GetReaders();
            return dt;
        }
    }
}
