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
        public int Id { get { return id; } }
        public string FirstName { get { return firstName; }  }
        public string LastName { get { return lastName; } }
        public string Email { get { return email; } }
        public string Password { get { return password; } }
        public UserType UserType { get { return userType; } }
        public DateTime DateCreated { get { return dateCreated; } }

        public override string ToString() //override the ToString method to return the full name of the user
        {
            return $"{FirstName} {LastName}";                  
        }
    }


}
