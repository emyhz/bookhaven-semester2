using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IBookDb
    {
        int AddBook(string title, string author, long isbn, DateTime publishDate, decimal price, string genre, string language, string imagePath, int stock, int sales, string bookType, TimeSpan? length = null, string fileSize = null,string dimensions = null, int? pages = null, string coverType = null);
        DataTable GetAllAudioBooks();
        DataTable GetAllPhysicalBooks();
        DataTable GetBooks();
        void UpdateBook(int id, string title, string author, string isbn, DateTime publishDate, decimal price, string genre,string language, string imagePath, int stock, int sales, string bookType, TimeSpan? length = null,string fileSize = null, string dimensions = null, int? pages = null, string coverType = null);
        void DeleteBook(int id);
        DataTable GetBooksSummary();
        DataTable GetBookDetails(int id);
        public void BuyBook(int bookId, int quantity);

    }
}
