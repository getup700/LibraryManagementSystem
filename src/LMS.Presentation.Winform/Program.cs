using Microsoft.Data.SqlClient;

namespace LMS.Presentation.Winform
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var conn = "Server=.;Database=UserIdentity;User Id=sa;Password=123456;Trusted_Connection=True;TrustServerCertificate=True;";
            //using var sqlconn = new SqlConnection(conn);
            //sqlconn.Open();
            //Console.WriteLine(sqlconn.State);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new ReaderForm());
        }
    }
}