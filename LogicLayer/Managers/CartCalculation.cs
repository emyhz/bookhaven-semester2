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
        public static decimal CalculateTotal(List<OrderItem> orderItems)
        {
            decimal totalPrice = 0;
            foreach (OrderItem orderItem in orderItems)
            {
                totalPrice += (orderItem.Price);
            }

            return totalPrice;
        }
    }
}
