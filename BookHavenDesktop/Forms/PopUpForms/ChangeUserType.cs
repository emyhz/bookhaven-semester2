using LogicLayer.EntityClasses;
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
    public partial class ChangeUserType : Form
    {
        private string userEmail;
        private UserManager userManager;
        public ChangeUserType(string userEmail, UserManager userManager)
        {
            this.userEmail = userEmail;
            this.userManager = userManager;
            InitializeComponent();
            PopulateGenreComboBox();


        }

        private void btnChangeDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPosition.SelectedItem == null)
                {
                    MessageBox.Show("Please select a position.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedPosition = cmbPosition.SelectedItem.ToString();

                User currentUser = userManager.GetUserByEmail(userEmail);
                if (currentUser == null)
                {
                    MessageBox.Show("User not found. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                userManager.UpdateUserType(currentUser.Id, selectedPosition, userEmail);

                MessageBox.Show($"Your position has been successfully updated to {selectedPosition}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateGenreComboBox()
        {
            cmbPosition.Items.Clear();

            foreach (UserType userType in Enum.GetValues(typeof(UserType)))
            {
                if(userType == UserType.EMPLOYEE || userType == UserType.ADMIN)
                {
                    cmbPosition.Items.Add(userType.ToString());
                }
            }
        }


    }
}
