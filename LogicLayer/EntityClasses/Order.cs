using LogicLayer.Enums;
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
        private string zipCode;
        private decimal totalPrice;
        private List<OrderItem> orderItems;
        private OrderStatus orderStatus;


        //constructors
        public Order(int id, DateTime dateCreated, User user, string address, string country, string city, string zipCode, decimal totalPrice, List<OrderItem> orderItems, OrderStatus orderStatus)
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
            this.orderStatus = orderStatus;
        }
        public Order(int id, DateTime date, User user, decimal totalPrice, OrderStatus status, List<OrderItem> items)
        {
            this.id = id;
            this.dateCreated = date;
            this.user = user;
            this.totalPrice = totalPrice;
            this.orderStatus = status;
            this.orderItems = items;
        }


        //properties
        public int Id { get { return id; } }
        public DateTime DateCreated { get { return dateCreated; } }
        public User User { get { return user; } }
        public string Address { get { return address; } }
        public string Country { get { return country; } }
        public string City { get { return city; } }
        public string ZipCode { get { return zipCode; } }
        public decimal TotalPrice { get { return totalPrice; } }
        public List<OrderItem> OrderItems { get { return orderItems; } }
        public OrderStatus OrderStatus { get { return orderStatus; } }
    }
}
