using LogicLayer.Enums;
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

namespace BookHavenDesktop.Forms.PopUpForms
{
    public partial class ChangePassword : Form
    {
        private string userEmail;
        private UserManager userManager;
        public ChangePassword(string userEmail, UserManager userManager)
        {
            this.userEmail = userEmail;
            this.userManager = userManager;
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPass.Text;



            UpdatePasswordResults results = userManager.UpdatePassword(userEmail, oldPassword, newPassword, confirmPassword);
            switch (results)
            {
                case UpdatePasswordResults.PASSWORD_UPDATED:
                    MessageBox.Show("Password successfully changed!", "Password Changed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;
                case UpdatePasswordResults.MISSING_FIELDS:
                    MessageBox.Show("Please fill in all fields.", "Missing Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case UpdatePasswordResults.PASSWORDS_DONT_MATCH:
                    MessageBox.Show("Your new password does not match. Please try again.", "New Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case UpdatePasswordResults.INVALID_OLD_PASSWORD:
                    MessageBox.Show("Password is incorrect. Please try again.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

        }
    }
}
