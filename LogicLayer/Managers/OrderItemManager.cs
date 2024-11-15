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
    public class OrderItemManager
    {
        private IOrderItemDb _orderItemDb;
        private UserManager _userManager;
        private BookManager _bookManager;

        public OrderItemManager(IOrderItemDb orderItemDb, UserManager userManager, BookManager bookManager)
        {
            _orderItemDb = orderItemDb;
            _userManager = userManager;
            _bookManager = bookManager;
        }

        public void AddItemToCart(int userId, int bookId, int quantity = 1)
        {
            _orderItemDb.AddItemToCart(userId, bookId, quantity);
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
        public List<OrderItem> GetCartFromUserID(int userID)
        {
            List<OrderItem> items = new List<OrderItem>();
            DataTable dt = _orderItemDb.GetCartFromUsersID(userID);

            foreach (DataRow row in dt.Rows)
            {
                int itemId = Convert.ToInt32(row["Id"]);
                int quantity = Convert.ToInt32(row["Quantity"]);
                decimal price = Convert.ToDecimal(row["Price"]);
                int bookId = Convert.ToInt32(row["BookId"]);
                string title = Convert.ToString(row["Title"]);

                // Get the Book object using BookManager
                Book book = _bookManager.GetBookById(bookId);

                OrderItem orderItem = new OrderItem(itemId, quantity, price, 0, book);
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
        public int GetItemQuantityFromUser(int userId)
        {
            List<OrderItem> order = this.GetCartFromUserID(userId);
            int quantityItems = 0;

            foreach (OrderItem orderItem in order)
            {
                quantityItems += (orderItem.Quantity);
            }

            return quantityItems;
        }
        public void Checkout(int orderId )
        {
            _orderItemDb.Checkout(orderId);
        }
    }
}
