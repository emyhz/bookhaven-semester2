using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using LogicLayer.Enums;
using LogicLayer.EntityClasses;
using System.Data;

namespace LogicLayer.Managers
{
    public class UserManager
    {
        private DBUser dbuser;

        public UserManager()
        {
            dbuser = new DBUser();
        }

        public void AddUser(string firstName,  string lastName, string email, string password, UserType userType)
        {
            string userTypeString = userType.ToString();
            dbuser.AddUser(firstName, lastName, email, password, userTypeString);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public User GetUserByEmail(string email)
        {
            DataTable dt = dbuser.GetUserByEmail(email);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Parse the UserType from the database string value directly to the UserType enum
                UserType userType;
                if (Enum.TryParse(row["UserType"].ToString(), out userType))
                {
                    // Create and return the User object
                    return new User(
                        Convert.ToInt32(row["Id"]),
                        row["FirstName"].ToString(),
                        row["LastName"].ToString(),
                        row["Email"].ToString(),
                        row["Password"].ToString(),
                        userType,  // Directly using the enum
                        Convert.ToDateTime(row["CreatedDate"])
                    );
                }
            }
            return null; // Return null if no user is found or if UserType parsing fails
        }

        public bool AuthenticateUser(string email, string password)
        {
            User user = GetUserByEmail(email);
            if (user != null)
            {
                return BCrypt.Net.BCrypt.Verify(password, user.Password);
            }
            return false;
        }

        //public void DeleteUser()
    }
}
