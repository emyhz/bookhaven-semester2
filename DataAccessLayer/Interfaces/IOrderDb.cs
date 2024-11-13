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
        public int AddOrder(int userId, string address = null, string country = null, string city = null, decimal zipCode = 0, decimal totalPrice = 0, int orderStatus = 0);
        DataTable GetOrders();
        DataTable GetOrdersByUser(int userId);
        DataTable GetOrdersForBook(int bookId);
        DataTable GetOrderDetails(int id);
        public void FinalizeOrder(int orderId, int orderStatus);
    }
}
