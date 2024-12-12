using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHavenDesktop.UserControls;
using LogicLayer.EntityClasses;
using LogicLayer.Managers;

namespace BookHavenDesktop.Forms.MainPages
{
    public partial class Clients : Form
    {

        private List<User> customers;
        private UserManager userManager;
        private List<User> searchCustomers;
        public Clients(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            customers = userManager.GetCustomers();
            GenerateEmployees(customers);
        }

        private void GenerateEmployees(List<User> customers)
        {
            flpCustomer.Controls.Clear();

            foreach (User customer in customers)
            {
                EmployeeList employeeControl = new EmployeeList
                {
                    Name = $"{customer.FirstName} {customer.LastName}",
                    Email = customer.Email
                };

                flpCustomer.Controls.Add(employeeControl);
            }
        }

        private void btnSearchClient_Click(object sender, EventArgs e)
        {
            string firstName = txtFNameSearch.Text;
            string lastName = txtLNameSearch.Text;
            string email = txtEmailSearch.Text;

            searchCustomers = userManager.SearchCustomer(firstName, lastName, email);
            GenerateEmployees(searchCustomers);
        }
    }
}
