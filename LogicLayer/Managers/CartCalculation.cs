using LogicLayer.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Managers
{
    public static class CartCalculation
    {
        public static decimal CalculateOrderTotal(List<OrderItem> orderItems)
        {
            decimal totalPrice = 0;
            foreach (OrderItem orderItem in orderItems)
            {
                totalPrice += (orderItem.Price);
            }

            return totalPrice;
        }
        public static decimal CalculateOrderShipping(List<OrderItem> orderItems)
        {
            decimal totalPrice = 0;

            foreach (OrderItem orderItem in orderItems)
            {
                decimal bookFinalPrice = orderItem.Book.CalculateFinalPrice();

                totalPrice += bookFinalPrice * orderItem.Quantity;
            }

            return totalPrice;
        }
    }
}
