using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUserDb
    {
        void AddUser(string firstName, string lastName, string email, string password, string userType);
        DataTable GetUsersTable();
        DataTable GetUsers(string userType);
        DataTable GetUserByEmail(string email);
        DataTable GetUserById(int id);
        bool EmailExists(string email);
        void UpdateUserType(int id, string userType);
        void DeleteUser(string email);
        void UpdatePassword(string email, string newPass);
        void UpdateDetails(string email, string firstName, string lastName);
    }
}
