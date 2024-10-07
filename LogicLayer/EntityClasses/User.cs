using LogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.EntityClasses
{
    public class User
    {
        //data fields
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private UserType userType;
        private DateTime dateCreated;

        //constructors
        public User(int id, string firstName, string lastName, string email, string password, UserType userType, DateTime dateCreated)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.userType = userType;
            this.dateCreated = dateCreated;
        }

        public User(int id, string firstName, string lastName, string email, UserType userType, DateTime dateCreated)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.userType = userType;
            this.dateCreated = dateCreated;
        }


        //properties
        public int Id { get { return id; } set { id = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }
        public UserType UserType { get { return userType; } set { userType = value; } }
        public DateTime DateCreated { get { return dateCreated; } set { dateCreated = value; } }

        public override string ToString() //override the ToString method to return the full name of the user
        {
            return $"{FirstName} {LastName}";                  
        }
    }


}
