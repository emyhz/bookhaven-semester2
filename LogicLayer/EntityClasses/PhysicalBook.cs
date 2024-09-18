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
        private int dimensions;
        private int pages;
        private string coverType;


        public PhysicalBook(int id, string title, string author, int isbn, DateTime publishYear, decimal price, Genre genre, string language, int dimensions, int pages, string coverType)
        : base(id, title, author, isbn, publishYear, price, genre, language)
        {
            this.dimensions = dimensions;
            this.pages = pages;
            this.coverType = coverType;
        }

        public int Dimensions { get { return dimensions; } set { dimensions = value; } }
        public int Pages { get { return pages; } set { pages = value; } }
        public string CoverType { get { return coverType; } set { coverType = value; } }

        public override void CheckOut()//no implementation yet
        {
            throw new NotImplementedException();
        }
    }
}
