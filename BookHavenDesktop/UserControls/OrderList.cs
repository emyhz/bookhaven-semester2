using LogicLayer.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHavenDesktop.UserControls
{
    public partial class OrderList : UserControl
    {
        private int id;
        private string customer;
        private decimal totalPrice;
        private DateTime date;
        private OrderManager _orderManager;
        public OrderList(OrderManager orderManager)
        {
            InitializeComponent();
            _orderManager = orderManager;
        }

        public int OrderId
        {
            get { return id; }
            set { id = value; lblOrderNo.Text = "Order #" + value; }
        }
        public string Customer
        {
            get { return customer; }
            set { customer = value; lblCustomer.Text = "Placed by: " + value; }
        }
        public decimal TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; lblTotalPrice.Text = "Total Price: " + value.ToString("C"); }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; lblOrderDate.Text = "Placed on: " + value.ToString("dd/MM/yyyy"); }
        }
    }
}
