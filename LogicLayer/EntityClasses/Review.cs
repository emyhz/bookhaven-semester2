using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogicLayer.EntityClasses
{
    public class Review
    {
        private int id;
        private User author;
        private Book book;
        private int rating;
        private string? title;
        private string? comment;

        public Review(int id, User author, Book book, int rating, string? title, string? comment)
        {
            this.id = id;
            this.author = author;
            this.book = book;
            this.rating = rating;
            this.title = title;
            this.comment = comment;
        }

        public int Id { get { return id; } }
        public User Author { get { return author; } }
        public Book Book { get { return book; } }
        public int Rating { get { return rating; } }
        public string? Title { get { return title; } }
        public string? Comment { get { return comment; } }

    }
}
