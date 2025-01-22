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

                // Multiply the final price by the quantity and add to the total price
                totalPrice += itemFinalPrice * orderItem.Quantity;
            }
            // 2 deciaml places
            return Math.Round(totalPrice, 2);

        }
        public static decimal CalculateOrderShipping(List<OrderItem> orderItems)
        {

            decimal totalShippingCost = 0;

            foreach (OrderItem orderItem in orderItems)
            {
                if (orderItem.Book is PhysicalBook physicalBook)
                {
                    // Calculate shipping cost as the difference between the full price and the discounted price 
                    decimal shippingCost = physicalBook.CalculateFinalPrice() - physicalBook.DiscountPrice;

                    // Multiply the shipping cost by the quantity and add to the total shipping cost
                    totalShippingCost += shippingCost * orderItem.Quantity;
                }
            }

            // 2 decimal places
            return Math.Round(totalShippingCost, 2);
        }
    }
}
