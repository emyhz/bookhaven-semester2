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
    public partial class MainForm : Form
    {
        private Form _activeForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenChildForms(Form childForm, object btnSender)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlMainForm.Controls.Add(childForm);
            this.pnlMainForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenChildForms(new Products(), sender);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenChildForms(new Orders(), sender);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            OpenChildForms(new Employees(), sender);
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            OpenChildForms(new Clients(), sender);
        }

        private void btnMyAccount_Click(object sender, EventArgs e)
        {
            OpenChildForms(new MyAccount(), sender);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // confirmation message
            DialogResult result = MessageBox.Show("Are you sure you would like to log out?", "Log Out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                AccessForm accessForm = new AccessForm();
                accessForm.Show();
                this.Hide();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForms(new HomePage(), sender);
        }
    }
}
