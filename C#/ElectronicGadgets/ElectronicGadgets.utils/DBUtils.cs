using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DBUtils
{
    public static class DBUtils
    {
        public static SqlConnection getDBConnection()
        {
            SqlConnection conn;
            string connectionstring = "Server=localhost,1433;Database=TechShop;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;";
            conn = new SqlConnection();
            conn.ConnectionString = connectionstring;
            return conn;
        }
    }
}

