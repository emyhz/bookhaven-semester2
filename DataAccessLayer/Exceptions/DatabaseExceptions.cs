using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Exceptions
{
    public class DatabaseExceptions
    {
        public class DatabaseConnectionException : Exception
        {
            public DatabaseConnectionException(string message) : base(message)
            {
            }

            public DatabaseConnectionException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }

        
    }
}
