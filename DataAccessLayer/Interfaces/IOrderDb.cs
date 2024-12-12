using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IOrderDb 
    {
        int AddOrder(int userId, string address, string country, string city, string zipCode, decimal totalPrice, int orderStatus);
        DataTable GetOrders();
        DataTable GetUserOrders(int userId);
        DataTable GetOrdersForBook(int bookId);
        DataTable GetOrderDetails(int id);
        DataTable GetStatisticOrders(DateTime startDate);
        DataTable GetCompletedOrders();
        DataTable GetLastUsedAddress(int userId);
        void UpdateOrderStatus(int orderId, int status);
        DateTime? GetLastOrderDate(int userId);
        DataTable GetOrderByNumber(int orderNumber);
    }
}
