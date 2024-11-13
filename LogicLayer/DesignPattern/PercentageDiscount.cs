using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DesignPattern
{
    public class PercentageDiscount : IDiscountStrategy
    {
        private decimal percentage;

        public PercentageDiscount(decimal percentage)
        {
            this.percentage = percentage;
        }
        
        public decimal ApplyDiscount(decimal price)
        {
            return price * (1 - percentage / 100);
        }
    }
}
