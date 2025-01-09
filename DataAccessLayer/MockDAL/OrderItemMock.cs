using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MockDAL
{
    public class OrderItemMock : IOrderItemDb
    {
        private List<(int Id, int UserId, int BookId, int Quantity, int OrderId)> _orderItems = new List<(int, int, int, int, int)>();
        private readonly BookMock _bookMock;

        private int _nextId = 1;

        public OrderItemMock(BookMock bookMock)
        {
            _bookMock = bookMock;
        }


        // Adds an item to the cart
        public void AddItemToCart(int userId, int bookId, int quantity = 1)
        {
            int id = _nextId++; // Generate an order item ID
            _orderItems.Add((id, userId, bookId, quantity, 0)); // Use the BookId from BookMock
        }


        // Gets all items for a specific order
        public DataTable GetOrderItems(int orderId)
        {
            DataTable dt = CreateOrderItemDataTable();

            foreach (var item in _orderItems)
            {
                if (item.OrderId == orderId)
                {
                    AddOrderItemToDataTable(dt, item); // Ensure BookId is correct here
                }
            }

            return dt;
        }


        // Gets all items in a user's cart
        public DataTable GetUserCart(int userId)
        {
            DataTable dt = CreateOrderItemDataTable();

            foreach (var item in _orderItems)
            {
                if (item.UserId == userId && item.OrderId == 0)
                {
                    AddOrderItemToDataTable(dt, item);
                }
            }

            return dt;
        }


        // Increases the quantity of a specific order item
        public void IncreaseQuantity(int orderItemId)
        {
            int index = _orderItems.FindIndex(item => item.Id == orderItemId);
            if (index >= 0)
            {
                var item = _orderItems[index];
                _orderItems[index] = (item.Id, item.UserId, item.BookId, item.Quantity + 1, item.OrderId);
            }
        }

        // Decreases the quantity of a specific order item
        public void DecreaseQuantity(int orderItemId)
        {
            int index = _orderItems.FindIndex(item => item.Id == orderItemId);
            if (index >= 0 && _orderItems[index].Quantity > 1)
            {
                var item = _orderItems[index];
                _orderItems[index] = (item.Id, item.UserId, item.BookId, item.Quantity - 1, item.OrderId);
            }
        }

        // Moves an item from the cart to a finalized order
        public void Checkout(int orderId, int orderItemId)
        {
            int index = _orderItems.FindIndex(item => item.Id == orderItemId);
            if (index >= 0)
            {
                var item = _orderItems[index];
                _orderItems[index] = (item.Id, item.UserId, item.BookId, item.Quantity, orderId);
            }
        }





        // Removes an audio item from the cart
        public void RemoveAudioOrderItem(int orderItemId)
        {
            int index = _orderItems.FindIndex(item => item.Id == orderItemId);
            if (index >= 0)
            {
                _orderItems.RemoveAt(index);
            }
        }

        // Adds an order item to a finalized order (not the cart)
        public void AddOrderItem(int orderId, int bookId, int quantity)
        {
            int id = _nextId++;
            _orderItems.Add((id, 0, bookId, quantity, orderId));
        }

        // Creates the DataTable schema for order items
        private DataTable CreateOrderItemDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("UserId", typeof(int));
            dt.Columns.Add("BookId", typeof(int));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("OrderId", typeof(int));
            return dt;
        }

        // Adds an order item to the DataTable
        private void AddOrderItemToDataTable(DataTable dt, (int Id, int UserId, int BookId, int Quantity, int OrderId) item)
        {
            DataRow row = dt.NewRow();
            row["Id"] = item.Id;
            row["UserId"] = item.UserId;
            row["BookId"] = item.BookId;
            row["Quantity"] = item.Quantity;
            row["OrderId"] = item.OrderId;
            dt.Rows.Add(row);
        }
    }
}
