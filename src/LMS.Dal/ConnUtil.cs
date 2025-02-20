using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Dal
{
    internal class ConnUtil
    {
        public static string GetUserDbStrings()
        {
            return Environment.GetEnvironmentVariable("UserIdentityDB");
        }


    }
}
