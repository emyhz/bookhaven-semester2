using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MockDAL
{
    public class Order2Mock : IOrderDb
    {
        private List<(int Id, int UserId, string Address, string Country, string City, string ZipCode, decimal TotalPrice, int Status, DateTime Date)> _orders = new();
        private int _nextOrderId = 1;

        // Reference to OrderItem2Mock to handle the Order-Book relationship
        private readonly OrderItem2Mock _orderItem2Mock;

        public Order2Mock(OrderItem2Mock orderItem2Mock)
        {
            _orderItem2Mock = orderItem2Mock;
            
        }

        public int AddOrder(int userId, string address, string country, string city, string zipCode, decimal totalPrice, int orderStatus)
        {
            int orderId = _nextOrderId++;
            _orders.Add((orderId, userId, address, country, city, zipCode, totalPrice, orderStatus, DateTime.Now));
            return orderId;
        }

        public DataTable GetOrders()
        {
            return ConvertOrdersToDataTable(_orders);
        }

        public DataTable GetUserOrders(int userId)
        {
            var userOrders = _orders.Where(o => o.UserId == userId).ToList();
            return ConvertOrdersToDataTable(userOrders);
        }

        public DataTable GetOrdersForBook(int bookId)
        {
            Console.WriteLine($"Fetching orders for Book ID: {bookId}");

            DataTable dt = CreateOrderDataTable();
            var matchingOrderItems = _orderItem2Mock.GetOrderItemsByBookId(bookId);

            foreach (var orderItem in matchingOrderItems)
            {
                var order = _orders.FirstOrDefault(o => o.Id == orderItem.OrderId);
                if (order != default)
                {
                    Console.WriteLine($"Order ID {order.Id} found for Book ID {bookId}");
                    AddOrderToDataTable(dt, order);
                }
            }

            Console.WriteLine($"Total Orders Found for Book ID {bookId}: {dt.Rows.Count}");
            return dt;
        }



        public DataTable GetOrderDetails(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            return ConvertOrdersToDataTable(order != default ? new List<(int, int, string, string, string, string, decimal, int, DateTime)> { order } : new List<(int, int, string, string, string, string, decimal, int, DateTime)>());
        }

        public DataTable GetStatisticOrders(DateTime startDate)
        {
            var filteredOrders = _orders.Where(o => o.Date >= startDate).ToList();
            return ConvertOrdersToDataTable(filteredOrders);
        }

        public DataTable GetCompletedOrders()
        {
            const int completedStatus = 2;
            var completedOrders = _orders.Where(o => o.Status == completedStatus).ToList();
            return ConvertOrdersToDataTable(completedOrders);
        }

        public DataTable GetLastUsedAddress(int userId)
        {
            var order = _orders.LastOrDefault(o => o.UserId == userId);
            if (order == default) return new();

            DataTable dt = new();
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Country", typeof(string));
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("Zip", typeof(string));

            dt.Rows.Add(order.Address, order.Country, order.City, order.ZipCode);
            return dt;
        }

        public void UpdateOrderStatus(int orderId, int status)
        {
            int index = _orders.FindIndex(o => o.Id == orderId);
            if (index >= 0)
            {
                var order = _orders[index];
                _orders[index] = (order.Id, order.UserId, order.Address, order.Country, order.City, order.ZipCode, order.TotalPrice, status, order.Date);
            }
            else
            {
                throw new Exception($"Order with ID {orderId} not found.");
            }
        }

        public DateTime? GetLastOrderDate(int userId)
        {
            var order = _orders.LastOrDefault(o => o.UserId == userId);
            return order != default ? order.Date : null;
        }

        public DataTable GetOrderByNumber(int orderNumber)
        {
            var order = _orders.FirstOrDefault(o => o.Id == orderNumber);
            return ConvertOrdersToDataTable(order != default ? new List<(int, int, string, string, string, string, decimal, int, DateTime)> { order } : new List<(int, int, string, string, string, string, decimal, int, DateTime)>());
        }

        public List<(int OrderId, int BookId, int Quantity)> GetOrderItemsForOrder(int orderId)
        {
            return _orderItem2Mock.GetOrderItems(orderId)
                .AsEnumerable()
                .Select(row => (
                    OrderId: (int)row["OrderId"],
                    BookId: (int)row["BookId"],
                    Quantity: (int)row["Quantity"]
                ))
                .ToList();
        }


        private DataTable ConvertOrdersToDataTable(IEnumerable<(int Id, int UserId, string Address, string Country, string City, string ZipCode, decimal TotalPrice, int Status, DateTime Date)> orders)
        {
            DataTable dt = new();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("UserId", typeof(int));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Country", typeof(string));
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("Zip", typeof(string));
            dt.Columns.Add("TotalPrice", typeof(decimal));
            dt.Columns.Add("Status", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));

            foreach (var order in orders)
            {
                dt.Rows.Add(order.Id, order.UserId, order.Address, order.Country, order.City, order.ZipCode, order.TotalPrice, order.Status, order.Date);
            }

            return dt;
        }

        private DataTable CreateOrderDataTable()
        {
            DataTable dt = new();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("UserId", typeof(int));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Country", typeof(string));
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("ZipCode", typeof(string));
            dt.Columns.Add("TotalPrice", typeof(decimal));
            dt.Columns.Add("Status", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));
            return dt;
        }

        private void AddOrderToDataTable(DataTable dt, (int Id, int UserId, string Address, string Country, string City, string ZipCode, decimal TotalPrice, int Status, DateTime Date) order)
        {
            DataRow row = dt.NewRow();
            row["Id"] = order.Id;
            row["UserId"] = order.UserId;
            row["Address"] = order.Address;
            row["Country"] = order.Country;
            row["City"] = order.City;
            row["ZipCode"] = order.ZipCode;
            row["TotalPrice"] = order.TotalPrice;
            row["Status"] = order.Status;
            row["Date"] = order.Date;
            dt.Rows.Add(row);
        }

        public List<(int OrderId, int UserId, string Address, string Country, string City, string ZipCode, decimal TotalPrice, int Status, DateTime Date)> GetOrdersForSpecificBook(int bookId)
        {
            Console.WriteLine($"Fetching orders for Book ID: {bookId}");

            // Fetch matching order items for the book
            var matchingOrderItems = _orderItem2Mock.GetOrderItemsByBookId(bookId);

            // Find corresponding orders
            var matchingOrders = matchingOrderItems
                .Select(orderItem => _orders.FirstOrDefault(order => order.Id == orderItem.OrderId))
                .Where(order => order != default)
                .Distinct()
                .ToList();

            Console.WriteLine($"Total Orders Found for Book ID {bookId}: {matchingOrders.Count}");
            return matchingOrders;
        }

    }
}
