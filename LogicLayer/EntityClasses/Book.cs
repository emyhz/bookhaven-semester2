using LogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.EntityClasses
{
    public abstract class Book
    {
        private int id;
        private string title;
        private string author;
        private int isbn;
        private DateTime publishYear;
        private decimal price;
        private Genre genre;
        private string language;

        public Book(int id, string title, string author, int isbn, DateTime publishYear, decimal price, Genre genre, string language)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.publishYear = publishYear;
            this.price = price;
            this.genre = genre;
            this.language = language;
        }

        public int Id { get { return id; } set { id = value; } }

        public string Title { get { return title; } set { title = value; } }
        public string Author { get { return author; } set { author = value; } }
        public int ISBN1 { get { return isbn; } set { isbn = value; } }
        public DateTime PublishYear { get { return publishYear; } set { publishYear = value; } }
        public decimal Price { get { return price; } set { price = value; } }
        public Genre Genre { get { return genre; } set { genre = value; } }
        public string Language { get { return language; } set { language = value; } }

        public abstract void CheckOut();

    }
}
