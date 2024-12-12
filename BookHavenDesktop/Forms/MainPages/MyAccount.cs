using BookHavenDesktop.Forms.PopUpForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BookHavenDesktop.Forms.MainPages
{
    public partial class MyAccount : Form
    {
        private UserManager userManager;
        private string _userEmail;
        private MainForm mainForm;

        // eventhandler to close forms when account is deleted
        public event EventHandler AccountDeleted;

        public MyAccount(string userEmail, UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
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
            try
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want to permanently delete your account? This action cannot be undone.",
                    "Confirm Account Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dialogResult == DialogResult.Yes)
                {
                    userManager.DeleteUser(_userEmail);
                    MessageBox.Show("Account successfully deleted.", "Account Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnAccountDeleted(EventArgs.Empty);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Account deletion canceled.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword changepassword = new ChangePassword(_userEmail, userManager);
            changepassword.ShowDialog();
        }
        protected virtual void OnAccountDeleted(EventArgs e)
        {
            AccountDeleted?.Invoke(this, e); // invoke event
        }

        private void btnEditNameUserType_Click(object sender, EventArgs e)
        {
            ChangeUserType changeUserType = new ChangeUserType(_userEmail, userManager);
            changeUserType.ShowDialog();
        }

        private void btnEditDetails_Click(object sender, EventArgs e)
        {
            EditDetails editDetails = new EditDetails(_userEmail, userManager);
            editDetails.ShowDialog();
        }
    }
}
