using DataAccessLayer.Interfaces;
using LogicLayer.EntityClasses;
using LogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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



        public List<OrderItem> GetOrderItems(int orderID)
        {
            List<OrderItem> items = new List<OrderItem>();
            DataTable dt = _orderItemDb.GetOrderItems(orderID);

            foreach (DataRow row in dt.Rows)
            {
                int Id = Convert.ToInt32(row["Id"]);
                int clientId = Convert.ToInt32(row["UserId"]);
                Book book = _bookManager.GetBookById(Convert.ToInt32(row["BookId"]));
                int quantity = Convert.ToInt32(row["Quantity"]);
                int orderId = Convert.ToInt32(row["OrderId"]);


                if (book == null)
                {
                    throw new InvalidOperationException($"Book with ID {book} not found in the database.");
                }


                decimal price = book.Price * quantity;

                OrderItem orderitem = new OrderItem(
                    Id,
                    quantity,
                    price,
                    orderId,
                    book

                );

                if (orderId == orderID)
                {
                    items.Add(orderitem);
                }

            }
            return items;
        }
        public List<OrderItem> GetUserCart(int userID)
        {
            List<OrderItem> cart = new List<OrderItem>();

            DataTable dt = _orderItemDb.GetUserCart(userID);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["Id"]);
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    int bookId = Convert.ToInt32(row["BookId"]);

                    Book book = _bookManager.GetBookById(bookId);

                    decimal price = book != null ? book.Price * quantity : 0;

                    OrderItem orderItem = new OrderItem(id, quantity, price, 0, book);

                    cart.Add(orderItem);
                }
            }

            return cart;
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
            List<OrderItem> order = this.GetUserCart(userId);
            int quantityItems = 0;

            foreach (OrderItem orderItem in order)
            {
                quantityItems += (orderItem.Quantity);
            }

            return quantityItems;
        }
        public void Checkout(int orderId, int orderItemId )
        {
            _orderItemDb.Checkout(orderId, orderItemId);
        }

        public void RemoveAudioItemFromCart(int orderItemId)
        {
            _orderItemDb.RemoveAudioOrderItem(orderItemId);
        }
    }
}
