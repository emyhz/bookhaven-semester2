using BookHavenDesktop.Forms.PopUpForms;
using LogicLayer.EntityClasses;
using LogicLayer.Enums;
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
        private Order orderData;
        private OrderStatus orderStatus;
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

        public Order OrderData
        {
            get { return orderData; }
            set { orderData = value; }
        }
        public OrderStatus OrderStatus
        {
            get { return orderStatus; }
            set { orderStatus = value; }
        }



        private void OrderList_Click(object sender, EventArgs e)
        {
            UpdateOrderStatus updateOrderStatus = new UpdateOrderStatus(orderData, _orderManager);
            updateOrderStatus.ShowDialog();
        }
    }
}
