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


namespace BookHavenDesktop.Forms.MainPages
{
    public partial class AccessForm : Form
    {
        private readonly UserManager userManager;
        public AccessForm()
        {
            InitializeComponent();
            userManager = new UserManager();
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
                MainForm mainForm = new MainForm(user.Email);
                mainForm.Show();
                this.Hide();
            }else if (user.UserType == LogicLayer.Enums.UserType.PENDING_EMPLOYEE)
            {
                MessageBox.Show("An admin needs to approve you first to login");
            }
        }

        private void UserTypeSignUp(string firstName, string lastName, string email, string password, string repeatPassword)
        {
            if (password == repeatPassword)
            {
                userManager.AddUser(firstName, lastName, email, password, UserType.PENDING_EMPLOYEE);
                MessageBox.Show("You have successfully signed up. An admin needs to approve you first to login");
            }
            else
            {
                MessageBox.Show("Passwords do not match");
            }
        }
    }
}
