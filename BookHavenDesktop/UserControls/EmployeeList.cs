using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHavenDesktop.UserControls
{
    public partial class EmployeeList : UserControl
    {

        private string name;
        private string email;
        public EmployeeList()
        {
            InitializeComponent();
        }

        public string Name
        {
            get { return name; }
            set { name = value; lblUserName.Text = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; lblEmail.Text = value; }
        }
    }
}
