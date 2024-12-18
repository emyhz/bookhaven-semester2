using BookHavenDesktop.UserControls;
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

namespace BookHavenDesktop.Forms.MainPages
{
    public partial class MainForm : Form
    {
        private Form _activeForm;
        private string _userEmail;
        private Button _currentButton;
        private UserManager _userManager;
        private OrderManager _orderManager;
        private BookManager _bookManager;
        public MainForm(string userEmail, UserManager userManager, OrderManager orderManager, BookManager bookManager)
        {
            InitializeComponent();
            _userEmail = userEmail;
            _userManager = userManager;
            _orderManager = orderManager;
            _bookManager = bookManager;

            DisplayBestSellers(_bookManager.GetBestSellingBooks(4));
        }

        private void DisplayBestSellers(List<Book> books)
        {
            flpBestSellerBooks.Controls.Clear();

            foreach (Book book in books)
            {
                BestSellerBooks bestSellerBooks = new BestSellerBooks
                {
                    Image = book.ImagePath,
                    Title = book.Title,
                    Author = book.Author,
                    Sales = book.Sales
                };


                flpBestSellerBooks.Controls.Add(bestSellerBooks);
            }
        }



        private void OpenChildForms(Form childForm, object btnSender)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }
            EnableButton(btnSender);
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
            OpenChildForms(new Products(_bookManager), sender);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenChildForms(new Orders(_orderManager), sender);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            OpenChildForms(new Employees(_userEmail, _userManager), sender);
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            OpenChildForms(new Clients(_userManager), sender);
        }

        private void btnMyAccount_Click(object sender, EventArgs e)
        {
            OpenChildForms(new MyAccount(_userEmail, _userManager), sender);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you would like to log out?", "Log Out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                AccessForm accessForm = new AccessForm(_userManager, _orderManager, _bookManager);
                accessForm.Show();
                this.Hide();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            EnableButton(sender);
            if (_activeForm != null)
            {
                _activeForm.Close();
            }
        }
        private void EnableButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (_currentButton != (Button)btnSender)
                {
                    DisableButtons();
                    _currentButton = (Button)btnSender;
                    _currentButton.BackColor = Color.Thistle;
                    _currentButton.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
                }
            }
        }
        private void DisableButtons()
        {
            foreach (Control previousBtn in flpMainPage.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(130, 76, 113);
                    previousBtn.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
                }
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            OpenChildForms(new Statistics(), sender);
        }
    }
}
