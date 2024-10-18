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

        //        public int AddOrder(int userId, string address, string country, string city, decimal zipCode, decimal totalPrice)
        //        {
        //            return _orderDb.AddOrder(userId, address, country, city, zipCode, totalPrice);
        //        }

        //        public List<Order> GetOrdersByUser(int userId)
        //        {
        //            DataTable dt = _orderDb.GetOrdersByUser(userId);
        //            List<Order> orders = new List<Order>();

        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow row in dt.Rows)
        //                {
        //                    int orderId = Convert.ToInt32(row["Id"]);
        //                    User user = _userManager.GetUserById(userId);
        //                    //List<OrderItem> orderItems = Order.GetOrderItems(orderId);

        //                    Order order = new Order(
        //                        orderId,
        //                        Convert.ToDateTime(row["Date"]),
        //                        user,
        //                        Convert.ToDecimal(row["TotalPrice"]),
        //                        (OrderStatus)Convert.ToInt32(row["Status"]),
        //                        orderItems
        //                    );

        //                    orders.Add(order);
        //                }
        //            }

        //            return orders;
        //        }

        //        public List<Order> GetOrdersForBook(int bookId)
        //        {
        //            DataTable dt = _orderDb.GetOrdersForBook(bookId);
        //            List<Order> orders = new List<Order>();

        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow row in dt.Rows)
        //                {
        //                    int orderId = Convert.ToInt32(row["Id"]);
        //                    int userId = Convert.ToInt32(row["UserId"]);
        //                    User user = _userManager.GetUserById(userId);
        //                    //List<OrderItem> orderItems = orderItemManager.GetOrderItems(orderId);

        //                    Order order = new Order(
        //                        orderId,
        //                        Convert.ToDateTime(row["Date"]),
        //                        user,
        //                        Convert.ToDecimal(row["TotalPrice"]),
        //                        (OrderStatus)Convert.ToInt32(row["Status"]),
        //                        orderItems
        //                    );

        //                    orders.Add(order);
        //                }
        //            }

        //            return orders;
        //        }
        //    }
        //}
    }
}
