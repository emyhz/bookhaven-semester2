using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IOrderItemDb
    {
        public void AddItemToCart(int userId, int bookId, int quantity = 1);
        public DataTable GetCartFromUsersID(int userID);
        public DataTable GetOrderItems(int orderID);
        public void IncreaseQuantity(int orderItemId);
        public void DecreaseQuantity(int orderItemId);
        public void Checkout(int orderId);
    }
}
