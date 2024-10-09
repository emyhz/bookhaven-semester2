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


            // Call the UpdatePassword method from your manager class
            string result = userManager.UpdatePassword(userEmail, oldPassword, newPassword, confirmPassword);

            // Handle the result based on the return message from UpdatePassword
            if (result == "Password updated successfully.")
            {
                MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == "Please fill in all fields.")
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == "The old password is incorrect.")
            {
                MessageBox.Show("The old password is incorrect. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (result == "The new passwords do not match.")
            {
                MessageBox.Show("The new passwords do not match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("An unexpected error occurred. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();

        }
    }
}
