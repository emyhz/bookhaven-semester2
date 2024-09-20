using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.EntityClasses
{
    public class OrderItem
    {
        //data fields
        private int id;
        private int quantity;
        private decimal price;

        //constructor
        public OrderItem(int id, int quantity, decimal price)
        {
            this.id = id;
            this.quantity = quantity;
            this.price = price;
        }

        //properties
        public int Id { get { return id; } set { id = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public decimal Price { get { return price; } set { price = value; } }

    }
}

