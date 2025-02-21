using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Dal.Utils
{
    internal class ConnUtil
    {
        public static string GetUserDbStrings()
        {
            return Environment.GetEnvironmentVariable("UserIdentityDB");
        }

        public static string GetLibraryManagermentDbStrings()
        {
            return Environment.GetEnvironmentVariable("LibraryManagementDBadmin");
        }


    }
}
