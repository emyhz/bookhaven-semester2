using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DesignPattern
{
    public class LongTimeNoBuyDiscount : IDiscountStrategy
    {
        private DateTime _lastPurcashedDate;
        private decimal _discountRate;

        public LongTimeNoBuyDiscount(DateTime lastPurcashedDate, decimal discountRate)
        {
            _lastPurcashedDate = lastPurcashedDate;
            _discountRate = discountRate;
        }

        public decimal ApplyDiscount(decimal price)
        {
            //check if the user has not purchased anything in the last  days
            int daysSinceLastPurchase = (DateTime.Now - _lastPurcashedDate).Days;

            //if the user has not purchased anything in the last 20 days, apply the discount
            if (daysSinceLastPurchase > 30) 
            {
                return price * (1 - _discountRate / 100); 
            }
            return price;
        }
    }
}
