using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DatabaseConnection
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi531971_bookhaven;User Id=dbi531971_bookhaven;Password=bookhaven;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
       
    }
}
