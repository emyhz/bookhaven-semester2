using LogicLayer.EntityClasses;
using LogicLayer.Enums;
using LogicLayer.Managers;

namespace BookHavenDesktop.Forms.PopUpForms
{
    public partial class UpdateOrderStatus : Form
    {
        private OrderManager _orderManager;
        private Order _order;
        private Order _selectedOrder;
        public UpdateOrderStatus(Order order, OrderManager orderManager)
        {
            InitializeComponent();
            _order = order;
            _selectedOrder = order;
            _orderManager = orderManager;



            lblOrderDate.Text = order.DateCreated.ToString("dd/MM/yyyy");
            lblOrderNo.Text = $"Order #{order.Id}";
            cmbStatus.Items.Clear();
            foreach (OrderStatus status in Enum.GetValues(typeof(OrderStatus)))
            {
                cmbStatus.Items.Add(status.ToString());
            }

            // Set the ComboBox's selected item to the current status
            cmbStatus.SelectedItem = order.OrderStatus.ToString();
        }

        private void btnSubmitNewOrderStatus_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected status from the ComboBox as a string
                string selectedStatus = cmbStatus.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedStatus))
                {
                    MessageBox.Show("Please select a valid order status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                OrderStatus newStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), selectedStatus);

                _orderManager.UpdateOrderStatus(_order.Id, newStatus);

                MessageBox.Show("Order status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update order status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
