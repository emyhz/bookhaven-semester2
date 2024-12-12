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
        private List<Order> _orders;
        private List<Order> _filter;
        private OrderManager _orderManager;
        public Orders(OrderManager orderManager)
        {
            InitializeComponent();
            _orderManager = orderManager;
            _orders = new List<Order>();
            _filter = _orders;
            LoadStatisticsAndOrders(0);
            cmbStatisticsTime.SelectedIndex = 0;

        }

        private void GenerateOrders(List<Order> orders)
        {
            flpOrders.Controls.Clear();

            if (orders != null && orders.Count > 0)
            {
                // Create a list of OrderList controls to represent each order
                OrderList[] listItems = new OrderList[orders.Count];

                for (int i = 0; i < orders.Count; i++)
                {
                    Order order = orders[i];

                    listItems[i] = new OrderList(_orderManager)
                    {
                        OrderId = order.Id,
                        Customer = order.User.Email,
                        TotalPrice = order.TotalPrice,
                        Date = order.DateCreated,
                        OrderData = order
                    };

                    flpOrders.Controls.Add(listItems[i]);
                }
                if (orders.Count > 1)
                {
                    lblOrdersFound.Text = $"{orders.Count} Orders Found";
                }
                else
                {
                    lblOrdersFound.Text = $"{orders.Count} Orders Found";
                }
            }
            else
            {
                lblOrdersFound.Text = "0 Orders Found";
            }
        }
        private void LoadStatisticsAndOrders(int selectedTime)
        {
            switch (selectedTime)
            {
                case 0:
                    _orders = _orderManager.GetOrdersLast24Hours();
                    break;
                case 1:
                    _orders = _orderManager.GetOrdersLast7Days();
                    break;
                case 2:
                    _orders = _orderManager.GetOrdersLastMonth();
                    break;
                case 3:
                    _orders = _orderManager.GetOrdersLastYear();
                    break;


            }

            GenerateOrders(_orders);

        }

        private void cmbStatisticsTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbStatisticsTime.SelectedIndex = cmbStatisticsTime.SelectedIndex;
            LoadStatisticsAndOrders(cmbStatisticsTime.SelectedIndex);
        }

        private void btnSearchOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int orderNumber = int.Parse(txtOrderNo.Text);

                _orders = _orderManager.GetOrderByNumber(orderNumber);

                GenerateOrders(_orders);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid order number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
