using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MockDAL
{
    public class OrderMock : IOrderDb
    {
        private List<(int Id, int UserId, string Address, string Country, string City, string ZipCode, decimal TotalPrice, int Status, DateTime Date)> Orders { get; } = new();
        private int _nextOrderId = 1;

        // Add a new order to the in-memory storage
        public int AddOrder(int userId, string address, string country, string city, string zipCode, decimal totalPrice, int orderStatus)
        {
            int orderId = _nextOrderId++;
            Orders.Add((orderId, userId, address, country, city, zipCode, totalPrice, orderStatus, DateTime.Now));
            return orderId;
        }

        // Retrieve all orders
        public DataTable GetOrders()
        {
            DataTable dt = CreateOrderDataTable();
            foreach (var order in Orders)
            {
                AddOrderToDataTable(dt, order);
            }
            return dt;
        }

        // Retrieve orders for a specific user
        public DataTable GetUserOrders(int userId)
        {
            DataTable dt = CreateOrderDataTable();
            foreach (var order in Orders)
            {
                if (order.UserId == userId)
                {
                    AddOrderToDataTable(dt, order);
                }
            }
            return dt;
        }

        // Retrieve orders containing a specific book (mock implementation)
        public DataTable GetOrdersForBook(int bookId)
        {
            DataTable dt = new();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("UserId", typeof(int));
            dt.Columns.Add("TotalPrice", typeof(decimal));
            dt.Columns.Add("Status", typeof(int));

            // Since this functionality depends on OrderItems, it's just mocked here
            return dt;
        }

        // Retrieve details for a specific order
        public DataTable GetOrderDetails(int id)
        {
            DataTable dt = CreateOrderDataTable();
            foreach (var order in Orders)
            {
                if (order.Id == id)
                {
                    AddOrderToDataTable(dt, order);
                    break;
                }
            }
            return dt;
        }

        // Retrieve orders starting from a specific date
        public DataTable GetStatisticOrders(DateTime startDate)
        {
            DataTable dt = CreateOrderDataTable();
            foreach (var order in Orders)
            {
                if (order.Date >= startDate)
                {
                    AddOrderToDataTable(dt, order);
                }
            }
            return dt;
        }

        // Retrieve completed orders
        public DataTable GetCompletedOrders()
        {
            DataTable dt = CreateOrderDataTable();
            foreach (var order in Orders)
            {
                if (order.Status == 1) // Assuming status 1 is "completed"
                {
                    AddOrderToDataTable(dt, order);
                }
            }
            return dt;
        }

        // Retrieve the last used address for a user
        public DataTable GetLastUsedAddress(int userId)
        {
            DataTable dt = new();
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Country", typeof(string));
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("ZipCode", typeof(string));

            foreach (var order in Orders)
            {
                if (order.UserId == userId)
                {
                    DataRow row = dt.NewRow();
                    row["Address"] = order.Address;
                    row["Country"] = order.Country;
                    row["City"] = order.City;
                    row["ZipCode"] = order.ZipCode;
                    dt.Rows.Add(row);
                    break;
                }
            }
            return dt;
        }

        // Update the status of an order
        public void UpdateOrderStatus(int orderId, int status)
        {
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].Id == orderId)
                {
                    var order = Orders[i];
                    Orders[i] = (order.Id, order.UserId, order.Address, order.Country, order.City, order.ZipCode, order.TotalPrice, status, order.Date);
                    break;
                }
            }
        }

        // Retrieve the last order date for a user
        public DateTime? GetLastOrderDate(int userId)
        {
            foreach (var order in Orders)
            {
                if (order.UserId == userId)
                {
                    return order.Date;
                }
            }
            return null;
        }

        // Retrieve an order by its number
        public DataTable GetOrderByNumber(int orderNumber)
        {
            DataTable dt = CreateOrderDataTable();
            foreach (var order in Orders)
            {
                if (order.Id == orderNumber)
                {
                    AddOrderToDataTable(dt, order);
                    break;
                }
            }
            return dt;
        }

        // Helper methods
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
    }
}
