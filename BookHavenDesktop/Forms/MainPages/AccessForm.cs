using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer.Managers;
using LogicLayer.EntityClasses;
using LogicLayer.Enums;
using BookHavenDesktop.Properties;


namespace BookHavenDesktop.Forms.MainPages
{
    public partial class AccessForm : Form
    {
        private readonly UserManager userManager;
        public AccessForm(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmailLogin.Text;
            string password = txtPassLogin.Text;
            User user = userManager.GetUserByEmail(email);
            if (userManager.AuthenticateUser(email, password))
            {
                UserTypeLogin(user);
            }
            else
            {
                MessageBox.Show("Invalid email or password");
            }

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmailSignUp.Text;
            string password = txtPasswordSignUp.Text;
            string repeatPassword = txtPasswordSignUp2.Text;

            UserTypeSignUp(firstName, lastName, email, password, repeatPassword);

        }
        private void UserTypeLogin(User user)
        {
            if (user.UserType == LogicLayer.Enums.UserType.EMPLOYEE || user.UserType == LogicLayer.Enums.UserType.ADMIN)
            {
                MainForm mainForm = new MainForm(user.Email, userManager);
                mainForm.Show();
                this.Hide();
            }
            else if (user.UserType == LogicLayer.Enums.UserType.PENDING_EMPLOYEE)
            {
                MessageBox.Show("An admin needs to approve you first to login");
            }
        }

        private void UserTypeSignUp(string firstName, string lastName, string email, string password, string repeatPassword)
        {
            UserCreation userCreation = User.ValidateUser(userManager, firstName, lastName, email, password, repeatPassword);
            switch (userCreation)
            {
                case UserCreation.SUCCESS:
                    userManager.AddUser(firstName, lastName, email, password, UserType.PENDING_EMPLOYEE);
                    MessageBox.Show("You have successfully signed up. An admin needs to approve you first to login");
                    break;
                case UserCreation.PASSWORDS_DONT_MATCH:
                    MessageBox.Show("Passwords do not match", "Invalid Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case UserCreation.INVALID_EMAIL:
                    MessageBox.Show("Invalid email", "Invalid Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case UserCreation.EMPTY_FIELDS:
                    MessageBox.Show("Please fill in all fields and try again." , "Missing Fields Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case UserCreation.EMAIL_ALREADY_EXISTS:
                    MessageBox.Show("This email is already in use.", "Email is Taken", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show("An error occurred while signing up");
                    break;
            }
        }

        private void pbPasswordShow_Click(object sender, EventArgs e)
        {
            if (txtPassLogin.UseSystemPasswordChar)
            {
                txtPassLogin.UseSystemPasswordChar = false; // Show the password text
                return;
            }
            else
            {
                txtPassLogin.UseSystemPasswordChar = true; // Hide the password with dots
            }
        }

        
    }
}
