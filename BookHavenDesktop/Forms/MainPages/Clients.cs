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
        public Clients(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            //userManager = new UserManager();
            customers = userManager.GetCustomers();
            GenerateEmployees(customers);
        }

        private void GenerateEmployees(List<User> customer)
        {
            flpCustomer.Controls.Clear();

            if ( customer!= null && customers.Count > 0)
            {
                EmployeeList[] listItems = new EmployeeList[customers.Count];

                for (int i = 0; i < customers.Count; i++)
                {
                    User employee = customers[i];
                    listItems[i] = new EmployeeList();

                    string name = $"{employee.FirstName} {employee.LastName}";
                    listItems[i].Name = name;
                    listItems[i].Email = employee.Email;

                    flpCustomer.Controls.Add(listItems[i]);
                }
            }
        }
    }
}
