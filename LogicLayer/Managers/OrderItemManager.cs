using DataAccessLayer.Interfaces;
using LogicLayer.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Managers
{
    public class OrderItemManager
    {
        private IOrderItemDb _orderItemDb;
        private UserManager _userManager;
        private OrderManager _orderManager;
        private BookManager _bookManager;

        public OrderItemManager(IOrderItemDb orderItemDb, UserManager userManager, OrderManager orderManager, BookManager bookManager)
        {
            _orderItemDb = orderItemDb;
            _userManager = userManager;
            _orderManager = orderManager;
            _bookManager = bookManager;
        }

        public void AddItemToCart(int bookId, int orderId, int quantity = 1)
        {
            _orderItemDb.AddToCart(bookId, orderId, quantity);
        }

        public List<OrderItem> GetOrderItems(int orderId)
        {
            List<OrderItem> items = new List<OrderItem>();
            DataTable dt = _orderItemDb.GetOrderItems(orderId);

            foreach (DataRow row in dt.Rows)
            {
                int itemId = Convert.ToInt32(row["Id"]);
                int quantity = Convert.ToInt32(row["Quantity"]);
                decimal price = Convert.ToDecimal(row["Price"]);
                int bookId = Convert.ToInt32(row["BookId"]);
                Book book = _bookManager.GetBookById(bookId);

                OrderItem orderItem = new OrderItem(itemId, quantity, price, orderId, book);
                items.Add(orderItem);
            }

            return items;
        }

        public void IncreaseQuantity(int orderItemId)
        {
            _orderItemDb.IncreaseQuantity(orderItemId);
        }

        public void DecreaseQuantity(int orderItemId)
        {
            _orderItemDb.DecreaseQuantity(orderItemId);
        }

        public void Checkout(int orderId, string orderStatus)
        {
            _orderItemDb.Checkout(orderId, orderStatus);
        }
    }
}
