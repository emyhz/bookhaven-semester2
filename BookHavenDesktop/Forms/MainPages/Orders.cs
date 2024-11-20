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
    public partial class Orders : Form
    {
        private List<Order> orders;
        private OrderManager _orderManager;
        public Orders(OrderManager orderManager)
        {
            InitializeComponent();
            _orderManager = orderManager;
            orders = new List<Order>();
           //rders = _orderManager.GetOrders();
            DisplayOrders(orders);

        }

        private void DisplayOrders(List<Order> orders)
        {
            flpOrders.Controls.Clear();

            foreach (Order order in orders)
            {
                OrderList orderList = new OrderList()
                {
                    OrderId = order.Id
                };

                flpOrders.Controls.Add(orderList);
            }
        }
    }
}
