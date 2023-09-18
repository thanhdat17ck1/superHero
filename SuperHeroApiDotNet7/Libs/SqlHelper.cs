using Microsoft.Data.SqlClient;
using System.Data;

namespace SuperHeroApiDotNet7.Libs
{
    public class SqlHelper
    {
        public static readonly string StrConnectionString = "Server=TUONGHAN;Database=Finance_CC;Trusted_Connection=true;TrustServerCertificate=true;";
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(StrConnectionString);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }
    }
}
