using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHavenDesktop.UserControls;
using LogicLayer.EntityClasses;
using LogicLayer.Enums;
using LogicLayer.Exceptions;
using LogicLayer.Managers;

namespace BookHavenDesktop.Forms.MainPages
{
    public partial class Employees : Form
    {
        private List<User> empUsers;
        private List<User> searchEmps;
        private UserManager userManager;
        private string _userEmail;
        public Employees(string userEmail, UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            _userEmail = userEmail;
            empUsers = userManager.GetEmployees();
            LoadPendingEmployees();
            DisplayEmployees(empUsers);
        }

        

        private void DisplayEmployees(List<User> employees)
        {
            flpEmployees.Controls.Clear();

            foreach (User employee in employees)
            {
                EmployeeList employeeControl = new EmployeeList
                {
                    Name = $"{employee.FirstName} {employee.LastName}",
                    Email = employee.Email
                };

                flpEmployees.Controls.Add(employeeControl);
            }
        }



        private void LoadPendingEmployees()
        {
            List<User> pendingEmployees = userManager.GetPendingEmployees();
            cmbPendingEmployee.Items.Clear();

            foreach (User user in pendingEmployees)
            {
                cmbPendingEmployee.Items.Add(user);
            }


        }

        private void cmbPendingEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPendingEmployee.SelectedIndex >= 0)
            {
                User selectedUser = (User)cmbPendingEmployee.SelectedItem;
                lblEmailPending.Text = selectedUser.Email;
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPendingEmployee.SelectedItem is User userToBePromoted)
                {
                    DialogResult result = MessageBox.Show("Are you sure you would like to approve this request?",
                        "Request Approval Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {


                        // Check if the logged-in email is set
                        if (string.IsNullOrEmpty(_userEmail))
                        {
                            MessageBox.Show("Logged-in user's email is not set. Please check the logged-in user information.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }

                       

                        // Approve the user
                        userManager.UpdateToEmployee(userToBePromoted.Id, _userEmail);

                        // Reload pending employees list
                        LoadPendingEmployees();

                        empUsers = userManager.GetEmployees();
                        DisplayEmployees(empUsers);

                        lblEmailPending.Text = string.Empty;

                        MessageBox.Show($"{userToBePromoted.FirstName} {userToBePromoted.LastName} has been successfully approved!",
                            "Employee Approval Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a user to approve.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            string firstName = txtFNameSearch.Text;
            string lastName = txtLNameSearch.Text;
            string email = txtEmailSearch.Text;

            searchEmps = userManager.SearchEmployee(firstName, lastName, email);
            DisplayEmployees(searchEmps); 
        }



        private void btnDeny_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you would like to delete this request?", "Request Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    User userToBeDeleted = (User)cmbPendingEmployee.SelectedItem;
                    userManager.DenyEmpAccessAsAdmin(userToBeDeleted.Email, _userEmail);
                    LoadPendingEmployees();
                    DisplayEmployees(empUsers);

                    lblEmailPending.Text = string.Empty;

                    MessageBox.Show($"{userToBeDeleted.FirstName}{userToBeDeleted.LastName} has been successfully deleted!", "Employee Denial Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (UserNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DataAccessException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
