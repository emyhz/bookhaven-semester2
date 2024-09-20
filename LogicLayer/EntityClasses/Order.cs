using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.EntityClasses
{
    public class Order
    {
        //data fields
        private int id;
        private DateTime dateCreated;
        private User user;
        private string address;
        private string country;
        private string city;
        private decimal zipCode;
        private decimal totalPrice;
        private List<OrderItem> orderItems;


        //constructors
        public Order(int id, DateTime dateCreated, User user, string address, string country, string city, decimal zipCode, decimal totalPrice, List<OrderItem> orderItems)
        {
            this.id = id;
            this.dateCreated = dateCreated;
            this.user = user;
            this.address = address;
            this.country = country;
            this.city = city;
            this.zipCode = zipCode;
            this.totalPrice = totalPrice;
            this.orderItems = orderItems;
        }


        //properties
        public int Id { get { return id; } set { id = value; } }
        public DateTime DateCreated { get { return dateCreated; } set { dateCreated = value; } }
        public User User { get { return user; } set { user = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Country { get { return country; } set { country = value; } }
        public string City { get { return city; } set { city = value; } }
        public decimal ZipCode { get { return zipCode; } set { zipCode = value; } }
        public decimal TotalPrice { get { return totalPrice; } set { totalPrice = value; } }
        public List<OrderItem> OrderItems { get { return orderItems; } set { orderItems = value; } }
    }
}
