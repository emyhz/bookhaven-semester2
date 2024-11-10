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
        private int orderId;
        private Book book;

        //constructor
        public OrderItem(int id, int quantity, decimal price, int orderId, Book book)
        {
            this.id = id;
            this.quantity = quantity;
            this.price = price;
            this.orderId = orderId;
            this.book = book;
        }

        //properties
        public int Id { get { return id; } }
        public int Quantity { get { return quantity; } }
        public decimal Price { get { return price; } }
        public int OrderId { get { return orderId; } }
        public Book Book { get { return book; } }

    }
}

