using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MockDAL
{
    public class OrderItem2Mock : IOrderItemDb
    {
        private List<(int Id, int UserId, int BookId, int Quantity, int OrderId)> _orderItems = new();
        private readonly BookMock _bookMock;
        private int _nextId = 1;

        public OrderItem2Mock(BookMock bookMock)
        {
            _bookMock = bookMock;
            
        }

        public void AddItemToCart(int userId, int bookId, int quantity = 1)
        {
            if (!_bookMock.GetBooks().Rows.Cast<DataRow>().Any(row => (int)row["Id"] == bookId))
            {
                throw new Exception($"Book ID {bookId} does not exist.");
            }

            _orderItems.Add((_nextId++, userId, bookId, quantity, 0)); // OrderId 0 indicates it's in the cart
        }

        public void AddOrderItem(int orderId, int bookId, int quantity)
        {
            Console.WriteLine($"Attempting to add OrderItem with Book ID {bookId} to Order ID {orderId}.");

            // Fetch all books from the mock
            var booksTable = _bookMock.GetBooks();
            Console.WriteLine($"Books fetched: {booksTable.Rows.Count} rows.");

            // Check if the book exists in the DataTable
            var bookExists = booksTable.AsEnumerable().Any(row => row.Field<int>("Id") == bookId);
            Console.WriteLine($"Book with ID {bookId} exists in GetBooks: {bookExists}");

            if (!bookExists)
            {
                throw new Exception($"Book ID {bookId} does not exist in BookMock.");
            }

            // Add the order item
            _orderItems.Add((_nextId++, 0, bookId, quantity, orderId));
            Console.WriteLine($"OrderItem added successfully: Order ID = {orderId}, Book ID = {bookId}, Quantity = {quantity}.");
        }

        public DataTable GetUserCart(int userId)
        {
            DataTable dt = CreateOrderItemDataTable();

            foreach (var item in _orderItems.Where(i => i.UserId == userId && i.OrderId == 0))
            {
                AddOrderItemToDataTable(dt, item);
            }

            return dt;
        }

        public DataTable GetOrderItems(int orderId)
        {
            DataTable dt = CreateOrderItemDataTable();

            foreach (var item in _orderItems.Where(i => i.OrderId == orderId))
            {
                AddOrderItemToDataTable(dt, item);
            }

            return dt;
        }

        public void IncreaseQuantity(int orderItemId)
        {
            int index = _orderItems.FindIndex(item => item.Id == orderItemId);
            if (index >= 0)
            {
                var item = _orderItems[index];
                _orderItems[index] = (item.Id, item.UserId, item.BookId, item.Quantity + 1, item.OrderId);
            }
            else
            {
                throw new Exception($"Order item with ID {orderItemId} not found.");
            }
        }

        public void DecreaseQuantity(int orderItemId)
        {
            int index = _orderItems.FindIndex(item => item.Id == orderItemId);
            if (index >= 0 && _orderItems[index].Quantity > 1)
            {
                var item = _orderItems[index];
                _orderItems[index] = (item.Id, item.UserId, item.BookId, item.Quantity - 1, item.OrderId);
            }
            else
            {
                throw new Exception($"Order item with ID {orderItemId} not found or quantity is already at minimum.");
            }
        }

        public void Checkout(int orderItemId, int orderId)
        {
            int index = _orderItems.FindIndex(item => item.Id == orderItemId);
            if (index >= 0)
            {
                var item = _orderItems[index];
                _orderItems[index] = (item.Id, item.UserId, item.BookId, item.Quantity, orderId);
            }
            else
            {
                throw new Exception($"Order item with ID {orderItemId} not found.");
            }
        }

        public void RemoveAudioOrderItem(int orderItemId)
        {
            int index = _orderItems.FindIndex(item => item.Id == orderItemId);
            if (index >= 0)
            {
                _orderItems.RemoveAt(index);
            }
            else
            {
                throw new Exception($"Order item with ID {orderItemId} not found.");
            }
        }
        public List<(int Id, int UserId, int BookId, int Quantity, int OrderId)> GetOrderItemsByBookId(int bookId)
        {
            Console.WriteLine($"Fetching order items for Book ID: {bookId}");
            var items = _orderItems.Where(item => item.BookId == bookId).ToList();

            Console.WriteLine($"Total Order Items Found for Book ID {bookId}: {items.Count}");
            foreach (var item in items)
            {
                Console.WriteLine($"OrderItem ID: {item.Id}, Order ID: {item.OrderId}, Quantity: {item.Quantity}");
            }

            return items;
        }

        private DataTable CreateOrderItemDataTable()
        {
            DataTable dt = new();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("UserId", typeof(int));
            dt.Columns.Add("BookId", typeof(int));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("OrderId", typeof(int));
            return dt;
        }

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
