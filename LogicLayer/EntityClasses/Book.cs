using LogicLayer.DesignPattern;
using LogicLayer.Enums;
using LogicLayer.Interfaces;
using LogicLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.EntityClasses
{
    public abstract class Book
    {
        //data fields
        private int id;
        private string title;
        private string author;
        private long isbn;
        private DateTime publishYear;
        private decimal price;
        private decimal discountPrice;
        private Genre genre;
        private string language;
        private string imagePath;
        private int stock;
        private int sales;
        private IDiscountStrategy _discountStrategy;


        //constructors
        public Book(int id, string title, string author, long isbn, DateTime publishYear, decimal price, Genre genre, string language, string imagePath, int stock, int sales)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.publishYear = publishYear;
            this.price = price;
            this.genre = genre;
            this.language = language;
            this.imagePath = imagePath;
            this.stock = stock;
            this.sales = sales;

            _discountStrategy = new NoDiscount();
        }

        public Book(int id, string title, string author, decimal price, string imagePath, int sales)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.price = price;
            this.imagePath = imagePath;
            this.sales = sales;
            _discountStrategy = new NoDiscount();

        }

        //properties
        public int Id { get { return id; } }

        public string Title { get { return title; } }
        public string Author { get { return author; } }
        public long ISBN1 { get { return isbn; } }
        public DateTime PublishYear { get { return publishYear; } }
        public decimal Price { get { return price; } }
        public decimal DiscountPrice { get { return discountPrice; } }
        public Genre Genre { get { return genre; } }
        public string Language { get { return language; } }
        public string ImagePath { get { return imagePath; } }
        public int Stock { get { return stock; } }
        public int Sales { get { return sales; } }


        //methods
        public abstract decimal CalculateFinalPrice();

        //discount strategy
        public void SetDiscountStrategy(IDiscountStrategy strategy)
        {
            _discountStrategy = strategy;
            RecalculateDiscountedPrice();
        }



        private void RecalculateDiscountedPrice()
        {
            this.discountPrice = Math.Round(_discountStrategy?.ApplyDiscount(price) ?? price, 2);

        }
    }
}
