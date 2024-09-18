using LogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.EntityClasses
{
    public class AudioBook : Book
    {

        private int audioLength;
        private int fileSize;

        public AudioBook(int id, string title, string author, int isbn, DateTime publishYear, decimal price, Genre genre, string language, int audioLength, int fileSize)
        : base(id, title, author, isbn, publishYear, price, genre, language)
        {
            this.audioLength = audioLength;
            this.fileSize = fileSize;
        }

        public int AudioLength { get { return audioLength; } set { audioLength = value; } }
        public int FileSize { get { return fileSize; } set { fileSize = value; } }

        public override void CheckOut() //no implementation yet
        {
            throw new NotImplementedException();
        }
    }
}
