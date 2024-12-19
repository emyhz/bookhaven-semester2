using LogicLayer.Enums;
using LogicLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.EntityClasses
{
    public class AudioBook : Book
    {
        //data fields
        private TimeSpan audioLength;
        private string fileSize;
        private string link;

        //constructor
        public AudioBook(int id, string title, string author, long isbn, DateTime publishYear, decimal price, Genre genre, string language, string imagePath, int stock, int sales, TimeSpan audioLength, string fileSize, string link)
        : base(id, title, author, isbn, publishYear, price, genre, language, imagePath, stock, sales)
        {
            this.audioLength = audioLength;
            this.fileSize = fileSize;
            this.link = link;
        }

        //properties
        public TimeSpan AudioLength { get { return audioLength; } }
        public string FileSize { get { return fileSize; } }
        public string Link { get { return link; } }

        public override decimal CalculateFinalPrice()
        {
            return DiscountPrice;
        }
    }
}
