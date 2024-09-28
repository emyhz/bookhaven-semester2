using LogicLayer.EntityClasses;
using LogicLayer.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHavenDesktop.Forms.MainPages
{
    public partial class MyAccount : Form
    {
        private UserManager userManager;
        private string _userEmail;
        private MainForm mainForm;
        public MyAccount(string userEmail)
        {
            InitializeComponent();
            userManager = new UserManager();
            _userEmail = userEmail;
            DisplayUserDetails();
        }

        public void DisplayUserDetails()
        {
            User loggedIn = userManager.GetUserByEmail(_userEmail);

            lblUsersNameDisplay.Text = $"{loggedIn.FirstName} {loggedIn.LastName}";
            lblUserType.Text = loggedIn.UserType.ToString();
            lblUserEmail.Text = loggedIn.Email;
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {

        }
    }
}
