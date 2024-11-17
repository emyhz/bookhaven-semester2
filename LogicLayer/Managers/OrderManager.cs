using DataAccessLayer.Interfaces;
using LogicLayer.EntityClasses;
using LogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Managers
{
    public class OrderManager
    {
        private UserManager _userManager;
        private OrderItemManager _orderItemManager;
        private IOrderDb _orderDb;

        public OrderManager(IOrderDb orderDb, UserManager userManager, OrderItemManager orderItemManager)
        {
            _orderDb = orderDb;
            _userManager = userManager;
            _orderItemManager = orderItemManager;
        }

        public int CreateOrder(int userId, string address, string country, string city, string zipCode, decimal totalPrice, int orderStatus)
        {
            return _orderDb.AddOrder(userId, address, country, city, zipCode, totalPrice, (int)OrderStatus.PENDING);
        }

        // Checks if there's an existing cart order (IN_CART) for the user
        public int GetOrCreateCartOrderId(int userId)
        {
            DataTable orders = _orderDb.GetOrdersByUser(userId);

            foreach (DataRow row in orders.Rows)
            {
                int orderId = Convert.ToInt32(row["Id"]);
                int status = Convert.ToInt32(row["Status"]);
                if (status == (int)OrderStatus.IN_CART)
                {
                    return orderId; // Return the existing cart order
                }
            }

            // If no cart order exists, create a new one with IN_CART status
            return _orderDb.AddOrder(userId, "", "", "", 0, 0, (int)OrderStatus.IN_CART);
        }
 


        public List<Order> GetOrdersSummary()
        {
            DataTable dt = _orderDb.GetOrders();
            List<Order> orders = new List<Order>();

            foreach (DataRow row in dt.Rows)
            {
                int orderId = Convert.ToInt32(row["Id"]);
                DateTime date = Convert.ToDateTime(row["Date"]);
                decimal totalPrice = Convert.ToDecimal(row["TotalPrice"]);
                OrderStatus status = Enum.Parse<OrderStatus>(row["Status"].ToString());

                // Fetch user and items
                User user = _userManager.GetUserById(Convert.ToInt32(row["UserId"]));
                List<OrderItem> items = _orderItemManager.GetOrderItems(orderId);

                Order order = new Order(orderId, date, user, totalPrice, status, items);
                orders.Add(order);
            }

            return orders;
        }
        public List<Order> GetOrderByUser(int userId)
        {
            DataTable dt = _orderDb.GetOrders();
            List<Order> orders = new List<Order>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int orderId = Convert.ToInt32(row["Id"]);
                    User user = _userManager.GetUserById(userId);
                    List<OrderItem> items = _orderItemManager.GetOrderItems(orderId);

                    Order order = new Order(
                    orderId,
                    Convert.ToDateTime(row["Date"]),
                    user,
                    Convert.ToDecimal(row["TotalPrice"]),
                    (OrderStatus)Convert.ToInt32(row["Status"]),
                    items
                );

                    orders.Add(order);
                }
            }
            return orders;

        }
    }


}
