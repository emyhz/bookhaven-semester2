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
using LogicLayer.StringManipulation;
using LogicLayer.Exceptions;

namespace LogicLayer.Managers
{
    public class UserManager
    {
        private IUserDb _dbuser;
        private List<User> users;
        private List<User> searchClient;

        public UserManager(IUserDb dbuser)
        {
            _dbuser = dbuser;
            users = GetEmployees();
            searchClient = GetCustomers();
        }

        public void AddUser(string firstName, string lastName, string email, string password, UserType userType)
        {
            string userTypeString = userType.ToString();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            _dbuser.AddUser(UserFormatter.CapitalizeFirstLetter(firstName), UserFormatter.CapitalizeFirstLetter(lastName), email.ToLower(), hashedPassword, userTypeString);
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
        public void UpdateUserType(int userId, string newUserType, string loggedInEmail)
        {
            User userToUpdate = GetUserById(userId);
            if (userToUpdate == null)
            {
                throw new Exception("User not found");
            }

            if (!Enum.TryParse(typeof(UserType), newUserType, true, out var parsedUserType))
            {
                throw new Exception("Invalid user type specified");
            }

            _dbuser.UpdateUserType(userId, newUserType);
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

        public List<User> SearchCustomer(string firstName, string lastName, string email)
        {
            List<User> searchCustomer = new List<User>();
            foreach (User user in searchClient)
            {
                bool matchesFirstName = string.IsNullOrEmpty(firstName) || user.FirstName.ToLower().Contains(firstName.ToLower());
                bool matchesLastName = string.IsNullOrEmpty(lastName) || user.LastName.ToLower().Contains(lastName.ToLower());
                bool matchesEmail = string.IsNullOrEmpty(email) || user.Email.ToLower().Contains(email.ToLower());

                if (matchesFirstName && matchesLastName && matchesEmail)
                {
                    searchCustomer.Add(user);
                }
            }
            return searchCustomer;
        }

        public void DeleteUser(string email)
        {
            _dbuser.DeleteUser(email);
        }

        public void DenyEmpAccessAsAdmin(string email, string loggedInEmail)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    throw new ArgumentException("Email cannot be null or empty.");
                }

                User currentlyLoggedInUser = GetUserByEmail(loggedInEmail);

                if (currentlyLoggedInUser.UserType != UserType.ADMIN)
                {
                    throw new UnauthorizedAccessException("Only administrators can delete users.");
                }

                User userToDelete = GetUserByEmail(email);
                if (userToDelete == null)
                {
                    throw new UserNotFoundException($"No user found with the email: {email}");
                }

                _dbuser.DeleteUser(email);
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException("An error occurred while accessing the database.", ex);
            }
        }
        public UpdatePasswordResults UpdatePassword(string email, string oldPassword, string newPassword, string retypeNewPassword)
        {
            User user = GetUserByEmail(email);

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(retypeNewPassword))
            {
                return UpdatePasswordResults.MISSING_FIELDS;
            }

            if (!BCrypt.Net.BCrypt.Verify(oldPassword, user.Password))
            {
                return UpdatePasswordResults.INVALID_OLD_PASSWORD;
            }

            if (!newPassword.Equals(retypeNewPassword))
            {
                return UpdatePasswordResults.PASSWORDS_DONT_MATCH;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
            _dbuser.UpdatePassword(email, hashedPassword);

            return UpdatePasswordResults.PASSWORD_UPDATED;
        }
        public void UpdateDetails(string email, string newFirstName, string newLastName)
        {
            _dbuser.UpdateDetails(email, newFirstName, newLastName);
        }

        public void UpdateEmpDetails(string firstName, string lastName, string loggedIn)
        {
            
        }
    }
    
}
