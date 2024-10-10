using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using LogicLayer.Enums;
using LogicLayer.EntityClasses;
using System.Data;
using static System.Reflection.Metadata.BlobBuilder;
using DataAccessLayer.Interfaces;

namespace LogicLayer.Managers
{
    public class UserManager
    {
        private IUserDb _dbuser;
        private List<User> users;

        public UserManager(IUserDb dbuser)
        {
            _dbuser = dbuser;
            users = GetEmployees();
        }

        public void AddUser(string firstName, string lastName, string email, string password, UserType userType)
        {
            string userTypeString = userType.ToString();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            _dbuser.AddUser(firstName, lastName, email, hashedPassword, userTypeString);
        }

        public User GetUserByEmail(string email)
        {
            DataTable dt = _dbuser.GetUserByEmail(email);
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

        public User GetUserById(int id)
        {
            DataTable dt = _dbuser.GetUserById(id);
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



        public List<User> GetPendingEmployees()
        {
            DataTable table = _dbuser.GetUsers(UserType.PENDING_EMPLOYEE.ToString());
            List<User> pendingUsers = new List<User>();

            foreach (DataRow row in table.Rows)
            {
                pendingUsers.Add(new User(
                    Convert.ToInt32(row["Id"]),
                    row["FirstName"].ToString(),
                    row["LastName"].ToString(),
                    row["Email"].ToString(),
                    UserType.PENDING_EMPLOYEE,
                    Convert.ToDateTime(row["CreatedDate"])
                ));
            }
            return pendingUsers;
        }

        public void UpdateToEmployee(int id, string loggedIn)
        {
            // Get the user to be promoted by ID
            User updateToEmp = GetUserById(id);
            if (updateToEmp == null)
            {
                throw new Exception("User not found");
            }

            // Get the logged-in user by email to check permissions
            User loggedInUser = GetUserByEmail(loggedIn);
            if (loggedInUser.UserType != UserType.ADMIN)
            {
                throw new Exception("You do not have permission to do this");
            }

            // Update the user type to EMPLOYEE
            _dbuser.UpdateUserType(id, UserType.EMPLOYEE.ToString());
        }
        public bool EmailExists(string email)
        {
            return _dbuser.EmailExists(email);
        }
        public bool UserAuth(string email, string password)
        {
            User user = GetUserByEmail(email);
            if (user != null)
            {
                BCrypt.Net.BCrypt.Verify(password, user.Password);
            }
            return false;
        }

        public List<User> GetEmployees()
        {
            DataTable dt = _dbuser.GetUsersTable();
            List<User> employees = new List<User>();

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    User user = new User(
                        Convert.ToInt32(row["Id"]),
                        row["FirstName"].ToString(),
                        row["LastName"].ToString(),
                        row["Email"].ToString(),
                        row["Password"].ToString(),
                        (UserType)Enum.Parse(typeof(UserType), row["UserType"].ToString()),
                        Convert.ToDateTime(row["CreatedDate"])
                    );

                    if (user.UserType == UserType.EMPLOYEE)
                    {
                        employees.Add(user);
                    }
                }
            }

            return employees;
        }

        public List<User> GetCustomers()
        {
            DataTable dt = _dbuser.GetUsersTable();
            List<User> customers = new List<User>();

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    User user = new User(
                        Convert.ToInt32(row["Id"]),
                        row["FirstName"].ToString(),
                        row["LastName"].ToString(),
                        row["Email"].ToString(),
                        row["Password"].ToString(),
                        (UserType)Enum.Parse(typeof(UserType), row["UserType"].ToString()),
                        Convert.ToDateTime(row["CreatedDate"])
                    );

                    if (user.UserType == UserType.CUSTOMER)
                    {
                        customers.Add(user);
                    }
                }
            }

            return customers;
        }

        public List<User> SearchEmployee(string firstName, string lastName, string email)
        {
            List<User> searchResults = new List<User>();

            foreach (User user in users)
            {
                bool matchesFirstName = string.IsNullOrEmpty(firstName) || user.FirstName.ToLower().Contains(firstName.ToLower());
                bool matchesLastName = string.IsNullOrEmpty(lastName) || user.LastName.ToLower().Contains(lastName.ToLower());
                bool matchesEmail = string.IsNullOrEmpty(email) || user.Email.ToLower().Contains(email.ToLower());

                if (matchesFirstName && matchesLastName && matchesEmail)
                {
                    searchResults.Add(user);
                }
            }

            return searchResults;
        }


        public List<User> SortUsers(UserCombobox usersort, List<User> usersToSort)
        {
            List<User> sortedUsers = new List<User>(usersToSort);

            switch (usersort)
            {
                case UserCombobox.NAME_ASCENDING:
                    sortedUsers.Sort((x, y) => string.Compare(x.FirstName, y.FirstName, StringComparison.OrdinalIgnoreCase));
                    break;
                case UserCombobox.START_DATE_ASCENDING:
                    sortedUsers.Sort((x, y) => DateTime.Compare(x.DateCreated, y.DateCreated));
                    break;
                case UserCombobox.START_DATE_DESCENDING:
                    sortedUsers.Sort((x, y) => DateTime.Compare(y.DateCreated, x.DateCreated));
                    break;
            }

            return sortedUsers;
        }


        public void DeleteEmployee(string email)
        {
            _dbuser.DeleteUser(email);
        }
        public void DenyEmpAccess()
        {

        }
        public string UpdatePassword(string email, string oldPassword, string newPassword, string retypeNewPassword)
        {
            User user = GetUserByEmail(email);

            // Check for missing fields
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(retypeNewPassword))
            {
                return "Please fill in all fields.";
            }

            // Verify the old password matches the stored hashed password
            if (!BCrypt.Net.BCrypt.Verify(oldPassword, user.Password))
            {
                return "The old password is incorrect.";
            }

            // Check if the new password matches the retyped password
            if (!newPassword.Equals(retypeNewPassword))
            {
                return "The new passwords do not match.";
            }

            // Hash the new password before storing it
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

            // Update the user's password in the database
            _dbuser.UpdatePassword(email, hashedPassword);

            return "Password updated successfully.";
        }
        public void UpdateCustomerInfo(string email, string newFirstName, string newLastName)
        {
            _dbuser.UpdateCustomerInfo(email, newFirstName, newLastName);
        }
    }
    
}
