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
    public partial class EditDetails : Form
    {
        private string userEmail;
        private UserManager userManager;
        public EditDetails(string userEmail, UserManager userManager)
        {
            InitializeComponent();
            this.userEmail = userEmail;
            this.userManager = userManager;
        }

        private void btnChangeDetails_Click(object sender, EventArgs e)
        {
            try
            {
                string newFirstName = txtFName.Text.Trim();
                string newLastName = txtLName.Text.Trim();

                if (string.IsNullOrEmpty(newFirstName) || string.IsNullOrEmpty(newLastName))
                {
                    MessageBox.Show("Both first name and last name must be provided.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                userManager.UpdateDetails(userEmail, newFirstName, newLastName);

                MessageBox.Show("Your details have been successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating your details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
