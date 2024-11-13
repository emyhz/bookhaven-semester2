using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DesignPattern
{
    public class NoDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price;
        }
    }
}
