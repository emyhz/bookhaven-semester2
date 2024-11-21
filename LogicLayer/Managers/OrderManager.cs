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

        public int CreateOrder(int userId, string address, string country, string city, string zipCode, decimal totalPrice)
        {
            int pendingStatus = (int)OrderStatus.PENDING;
            return _orderDb.AddOrder(userId, address, country, city, zipCode, totalPrice, pendingStatus);
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
        public Order GetOrderDetailsForUser(int id)
        {
            DataTable orderData = _orderDb.GetOrderDetails(id);

            if (orderData.Rows.Count == 0)
            {
                return null;
            }

            DataRow orderRow = orderData.Rows[0];
            int orderId = Convert.ToInt32(orderRow["Id"]);
            DateTime orderDate = Convert.ToDateTime(orderRow["Date"]);
            int userId = Convert.ToInt32(orderRow["UserId"]);

            User user = _userManager.GetUserById(userId);

            string address = Convert.ToString(orderRow["Address"]);
            string country = Convert.ToString(orderRow["Country"]);
            string city = Convert.ToString(orderRow["City"]);
            string zipCode = Convert.ToString(orderRow["Zip"]);
            decimal totalPrice = Convert.ToDecimal(orderRow["TotalPrice"]);
            OrderStatus status = (OrderStatus)Convert.ToInt32(orderRow["Status"]);

            List<OrderItem> orderItems = _orderItemManager.GetOrderItems(orderId);

            Order order = new Order(orderId, orderDate, user, address, country, city, zipCode, totalPrice, orderItems, status);

            return order;
        }
        //public List<Order> GetAllOrders()
        //{
        //    DataTable dt = _orderDb.GetOrders();
        //    List<Order> orders = new List<Order>();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        Order order = new Order(
        //            id: Convert.ToInt32(row["Id"]),
        //            date: Convert.ToDateTime(row["Date"]),
        //            user: _userManager.GetUserById(Convert.ToInt32(row["UserId"])),
        //            address: row["Address"].ToString(),
        //            country: row["Country"].ToString(),
        //            city: row["City"].ToString(),
        //            zipCode: row["ZipCode"].ToString(),
        //            totalPrice: Convert.ToDecimal(row["TotalPrice"]),
        //            orderItems: _orderItemManager.GetOrderItems(Convert.ToInt32(row["Id"])),
        //            status: (OrderStatus)Convert.ToInt32(row["Status"])
        //        );
        //        orders.Add(order);
        //    }

        //    return orders;
        //}

    }
}
