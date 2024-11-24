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
        protected string connectionString = "Server=mssqlstud.fhict.local;Database=dbi531971_bookhaven;User Id=dbi531971_bookhaven;Password=bookhaven;";


        protected void HandleDatabaseException(Exception ex)
        {
            Console.WriteLine($"Database Error: {ex.Message}");

            throw new Exception("There was an issue connecting to the database. Please try again later.");
        }
    }

}
