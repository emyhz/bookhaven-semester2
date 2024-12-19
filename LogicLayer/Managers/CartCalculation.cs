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
                decimal itemFinalPrice = orderItem.Book.CalculateFinalPrice();
                totalPrice += itemFinalPrice * orderItem.Quantity;
            }

            return Math.Round(totalPrice, 2);

        }
        public static decimal CalculateOrderShipping(List<OrderItem> orderItems)
        {

            decimal totalShippingCost = 0;

            foreach (OrderItem orderItem in orderItems)
            {
                if (orderItem.Book is PhysicalBook physicalBook)
                {
                    decimal shippingCost = physicalBook.CalculateFinalPrice() - physicalBook.DiscountPrice;
                    totalShippingCost += shippingCost * orderItem.Quantity;
                }
            }

            return Math.Round(totalShippingCost, 2);
        }
        public static decimal CalculateGrandTotal(List<OrderItem> orderItems)
        {
            decimal itemsTotal = CalculateOrderTotal(orderItems);
            decimal shippingTotal = CalculateOrderShipping(orderItems);

            return Math.Round(itemsTotal + shippingTotal, 2);
        }
    }
}
