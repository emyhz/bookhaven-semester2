using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MockDAL
{
    public class UserMock : IUserDb
    {
        public Dictionary<string, (int id, string firstName, string lastName, string email, string password, string userType, DateTime createdDate)> Users { get; } = new Dictionary<string, (int, string, string, string, string, string, DateTime)>();

        // Add a user to the in-memory storage
        public void AddUser(string firstName, string lastName, string email, string password, string userType)
        {
            int id = Users.Count + 1; // Generate a new user ID
            var createdDate = DateTime.Now; // Set the creation date to now
            Users[email] = (id, firstName, lastName, email, password, userType, createdDate);
        }

        // Returns all users as a DataTable
        public DataTable GetUsersTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("UserType", typeof(string));
            dt.Columns.Add("CreatedDate", typeof(DateTime));

            foreach (var user in Users.Values)
            {
                DataRow row = dt.NewRow();
                row["Id"] = user.id;
                row["FirstName"] = user.firstName;
                row["LastName"] = user.lastName;
                row["Email"] = user.email;
                row["Password"] = user.password;
                row["UserType"] = user.userType;
                row["CreatedDate"] = user.createdDate;
                dt.Rows.Add(row);
            }

            return dt;
        }

        // Returns users filtered by userType as a DataTable
        public DataTable GetUsers(string userType)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("UserType", typeof(string));
            dt.Columns.Add("CreatedDate", typeof(DateTime));

            foreach (var user in Users.Values)
            {
                if (user.userType == userType)
                {
                    DataRow row = dt.NewRow();
                    row["Id"] = user.id;
                    row["FirstName"] = user.firstName;
                    row["LastName"] = user.lastName;
                    row["Email"] = user.email;
                    row["Password"] = user.password;
                    row["UserType"] = user.userType;
                    row["CreatedDate"] = user.createdDate;
                    dt.Rows.Add(row);
                }
            }

            return dt;
        }

        // Get a user by email
        public DataTable GetUserByEmail(string email)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("UserType", typeof(string));
            dt.Columns.Add("CreatedDate", typeof(DateTime));

            if (Users.TryGetValue(email, out var user))
            {
                DataRow row = dt.NewRow();
                row["Id"] = user.id;
                row["FirstName"] = user.firstName;
                row["LastName"] = user.lastName;
                row["Email"] = user.email;
                row["Password"] = user.password;
                row["UserType"] = user.userType;
                row["CreatedDate"] = user.createdDate;
                dt.Rows.Add(row);
            }

            return dt;
        }

        // Get a user by ID
        public DataTable GetUserById(int id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("UserType", typeof(string));
            dt.Columns.Add("CreatedDate", typeof(DateTime));

            foreach (var user in Users.Values)
            {
                if (user.id == id)
                {
                    DataRow row = dt.NewRow();
                    row["Id"] = user.id;
                    row["FirstName"] = user.firstName;
                    row["LastName"] = user.lastName;
                    row["Email"] = user.email;
                    row["Password"] = user.password;
                    row["UserType"] = user.userType;
                    row["CreatedDate"] = user.createdDate;
                    dt.Rows.Add(row);
                    break;
                }
            }

            return dt;
        }

        // Check if an email exists
        public bool EmailExists(string email)
        {
            return Users.ContainsKey(email);
        }

        // Update a user's type
        public void UpdateUserType(int id, string userType)
        {
            foreach (var email in Users.Keys)
            {
                if (Users[email].id == id)
                {
                    var user = Users[email];
                    Users[email] = (user.id, user.firstName, user.lastName, user.email, user.password, userType, user.createdDate);
                    break;
                }
            }
        }

        // Delete a user by email
        public void DeleteUser(string email)
        {
            Users.Remove(email);
        }

        // Update a user's password
        public void UpdatePassword(string email, string newPass)
        {
            if (Users.TryGetValue(email, out var user))
            {
                Users[email] = (user.id, user.firstName, user.lastName, user.email, newPass, user.userType, user.createdDate);
            }
        }

        // Update customer info
        public void UpdateDetails(string email, string firstName, string lastName)
        {
            if (Users.TryGetValue(email, out var user))
            {
                Users[email] = (user.id, firstName, lastName, user.email, user.password, user.userType, user.createdDate);
            }
        }
    }
}
