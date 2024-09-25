using LogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.EntityClasses
{
    public class PhysicalBook : Book
    {
        //data fields
        private string dimensions;
        private int pages;
        private string coverType;

        //constructors
        public PhysicalBook(int id, string title, string author, long isbn, DateTime publishYear, decimal price, Genre genre, string language, string imagePath, int stock, string dimensions, int pages, string coverType)
        : base(id, title, author, isbn, publishYear, price, genre, language, imagePath, stock)
        {
            this.dimensions = dimensions;
            this.pages = pages;
            this.coverType = coverType;
        }

        //properties
        public string Dimensions { get { return dimensions; } set { dimensions = value; } }
        public int Pages { get { return pages; } set { pages = value; } }
        public string CoverType { get { return coverType; } set { coverType = value; } }

        //methods
        public override void CheckOut()//no implementation yet
        {
            throw new NotImplementedException();
        }
    }
}
