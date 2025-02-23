using LMS.Dal.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;

namespace LMS.Dal.Utils
{
    internal class ConnUtil
    {
        public static string GetUserDbStrings()
        {
            var str = Environment.GetEnvironmentVariable("UserIdentityDB")
                ?? throw new Exception("未从环境变量读取到UserIdentityDB连接字符串");
            return str;
        }

        public static string GetLibraryManagermentDbStrings()
        {
            var str = Environment.GetEnvironmentVariable("LibraryManagementDBadmin")
                ?? throw new Exception("未从环境变量读取到LibraryManagementDBadmin连接字符串");
            return str;
        }

        public static SqlConnection GetUserConnection()
        {
            SqlConnection conn;
            try
            {
                var connStr = ConnUtil.GetUserDbStrings();
                conn = new SqlConnection(connStr);
                conn.OpenIfClosed();

            }
            catch (Exception e)
            {
                throw new Exception("数据库连接失败", e);
            }
            return conn;
        }

        public static SqlConnection GetBookConnection()
        {
            SqlConnection conn = null;
            try
            {
                var connStr = ConnUtil.GetLibraryManagermentDbStrings();
                conn = new SqlConnection(connStr);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.OpenIfClosed();
                }
            }
            catch (Exception e)
            {
                throw new Exception("数据库连接失败", e);
            }
            return conn;
        }
    }
}
