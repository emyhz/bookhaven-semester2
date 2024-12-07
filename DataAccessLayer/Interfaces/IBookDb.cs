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
        int AddBook(string title, string author, long isbn, DateTime publishDate, decimal price, string genre, string language, string imagePath, int stock, int sales,
    TimeSpan? audioLength = null, string fileSize = null, string dimensions = null, int? pages = null, string coverType = null);
        DataTable GetAllAudioBooks();
        DataTable GetAllPhysicalBooks();
        DataTable GetBooks();
        void UpdateBook(int id, string title, string author, long isbn, DateTime publishDate, decimal price, string genre, string language, string imagePath, int stock,
   TimeSpan? length = null, string fileSize = null, string dimensions = null, int? pages = null, string coverType = null);
        void DeleteBook(int id);
        DataTable GetBooksSummary();
        DataTable GetBookDetails(int id);
        void BuyBook(int bookId, int quantity);
        DataTable GetBestSellingBooks(int count);

    }
}
