using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDBUser
    {
        void AddUser(string firstName, string lastName, string email, string password, int userType);
        DataTable GetUsers();
        DataTable GetUsers(int userType);
        bool EmailExists(string email);
        DataTable GetUserByEmail(string email);
        DataTable GetUserById(int id);
        void UpdateUserName(string email, string newName);
        void UpdateUserType(int id, int userType);
        void UpdateProfilePicture(string email, byte[] profilePicture);
        void UpdateUserPassword(string email, string newPassword);
        void DeleteUser(string email);
    }
}
