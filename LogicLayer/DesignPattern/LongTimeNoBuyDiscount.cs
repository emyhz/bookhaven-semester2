using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DesignPattern
{
    public class LongTimeNoBuyDiscount
    {
        private DateTime lastPurcashedDate;
        private decimal discountRate;

        public LongTimeNoBuyDiscount(DateTime lastPurcashedDate, decimal discountRate)
        {
            this.lastPurcashedDate = lastPurcashedDate;
            this.discountRate = discountRate;
        }

        public decimal ApplyDiscount(decimal price)
        {
            int daysSinceLastPurchase = (DateTime.Now - lastPurcashedDate).Days;
            if (daysSinceLastPurchase > 30)
            {
                return price * (1 - discountRate / 100);
            }
            return price;
        }
    }
}
