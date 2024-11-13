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
        public void AddToCart(int bookId, int orderId, int quantity = 1);
        public DataTable GetCartFromUserID(int userID, int orderStatus);
        public DataTable GetOrderItems(int orderID);

        public void IncreaseQuantity(int orderItemId);
        public void DecreaseQuantity(int orderItemId);
        public void Checkout(int orderId, string orderStatus);
    }
}
