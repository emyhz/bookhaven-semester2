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

        //constructor
        public AudioBook(int id, string title, string author, long isbn, DateTime publishYear, decimal price, Genre genre, string language, string imagePath, int stock, TimeSpan audioLength, string fileSize)
        : base(id, title, author, isbn, publishYear, price, genre, language, imagePath, stock)
        {
            this.audioLength = audioLength;
            this.fileSize = fileSize;
        }

        //properties
        public TimeSpan AudioLength { get { return audioLength; } }
        public string FileSize { get { return fileSize; } }

        public override decimal CalculateFinalPrice()
        {
            return Price;
        }
    }
}
