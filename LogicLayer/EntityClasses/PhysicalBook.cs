using LogicLayer.Enums;
using LogicLayer.Managers;
using System;
using System.Collections;
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
        public PhysicalBook(int id, string title, string author, long isbn, DateTime publishYear, decimal price, Genre genre, string language, string imagePath, int stock, int sales, string dimensions, int pages, string coverType)
        : base(id, title, author, isbn, publishYear, price, genre, language, imagePath, stock, sales)
        {
            this.dimensions = dimensions;
            this.pages = pages;
            this.coverType = coverType;
        }

        //properties
        public string Dimensions { get { return dimensions; } }
        public int Pages { get { return pages; } }
        public string CoverType { get { return coverType; } }

        //methods
        public override decimal CalculateFinalPrice()
        {
            const decimal shippingRate = 0.10m; // 10% shipping
            decimal shippingCost = Math.Round(Price * shippingRate, 2); // Round to 2 decimal places
            return Math.Round(Price + shippingCost, 2); // Return rounded final price
        }
    }
}
