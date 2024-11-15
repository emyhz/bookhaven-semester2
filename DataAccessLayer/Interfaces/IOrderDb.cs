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
        public int AddOrder(int userId, string address, string country, string city, decimal zipCode, decimal totalPrice, int orderStatus);
        DataTable GetOrders();
        DataTable GetOrdersByUser(int userId);
        DataTable GetOrdersForBook(int bookId);
        DataTable GetOrderDetails(int id);
    }
}
