using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MockDAL
{
    public class BookMock : IBookDb
    {
        private List<(int Id, string Title, string Author, long ISBN, DateTime PublishDate, decimal Price, string Genre, string Language, string ImagePath, int Stock, int Sales, TimeSpan? AudioLength, string FileSize, string Link, string Dimensions, int? Pages, string CoverType)> _books = new List<(int, string, string, long, DateTime, decimal, string, string, string, int, int, TimeSpan?, string, string, string, int?, string)>();
        private int _nextId = 1;

        public int AddBook(string title, string author, long isbn, DateTime publishDate, decimal price, string genre, string language, string imagePath, int stock, int sales,
            TimeSpan? audioLength = null, string fileSize = null, string link = null, string dimensions = null, int? pages = null, string coverType = null)
        {
            int newId = _nextId++;
            _books.Add((newId, title, author, isbn, publishDate, price, genre, language, imagePath, stock, sales, audioLength, fileSize, link, dimensions, pages, coverType));
            return newId;
        }

        public void UpdateBook(int id, string title, string author, long isbn, DateTime publishDate, decimal price, string genre, string language, string imagePath, int stock,
            TimeSpan? length = null, string fileSize = null, string link = null, string dimensions = null, int? pages = null, string coverType = null)
        {
            var index = _books.FindIndex(b => b.Id == id);
            if (index >= 0)
            {
                _books[index] = (id, title, author, isbn, publishDate, price, genre, language, imagePath, stock, _books[index].Sales, length, fileSize, link, dimensions, pages, coverType);
            }
            else
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }
        }

        public void DeleteBook(int id)
        {
            var index = _books.FindIndex(b => b.Id == id);
            if (index >= 0)
            {
                _books.RemoveAt(index);
            }
            else
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }
        }

        public DataTable GetBooks()
        {
            DataTable dt = CreateBookDataTable();
            foreach (var book in _books)
            {
                AddBookToDataTable(dt, book);
            }
            return dt;
        }

        public DataTable GetAllAudioBooks()
        {
            DataTable dt = CreateBookDataTable();
            foreach (var book in _books)
            {
                if (book.AudioLength.HasValue && !string.IsNullOrEmpty(book.FileSize) && !string.IsNullOrEmpty(book.Link))
                {
                    AddBookToDataTable(dt, book);
                }
            }
            return dt;
        }

        public DataTable GetAllPhysicalBooks()
        {
            DataTable dt = CreateBookDataTable();
            foreach (var book in _books)
            {
                if (!string.IsNullOrEmpty(book.Dimensions) && book.Pages.HasValue && !string.IsNullOrEmpty(book.CoverType))
                {
                    AddBookToDataTable(dt, book);
                }
            }
            return dt;
        }

        public DataTable GetBooksSummary()
        {
            return GetBooks(); // For simplicity, return all books as the summary
        }

        public DataTable GetBookDetails(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book.Id == 0) throw new KeyNotFoundException($"Book with ID {id} not found.");

            DataTable dt = CreateBookDataTable();
            AddBookToDataTable(dt, book);
            return dt;
        }

        public void BuyBook(int bookId, int quantity)
        {
            var index = _books.FindIndex(b => b.Id == bookId);
            if (index >= 0)
            {
                if (_books[index].Stock < quantity)
                    throw new InvalidOperationException("Insufficient stock.");

                _books[index] = (_books[index].Id, _books[index].Title, _books[index].Author, _books[index].ISBN, _books[index].PublishDate, _books[index].Price, _books[index].Genre,
                    _books[index].Language, _books[index].ImagePath, _books[index].Stock - quantity, _books[index].Sales + quantity, _books[index].AudioLength, _books[index].FileSize,
                    _books[index].Link, _books[index].Dimensions, _books[index].Pages, _books[index].CoverType);
            }
            else
            {
                throw new KeyNotFoundException($"Book with ID {bookId} not found.");
            }
        }

        public DataTable GetBestSellingBooks(int count)
        {
            var bestsellingBooks = _books
                .OrderByDescending(b => b.Sales) // Use updated Sales field
                .Take(count)
                .ToList();

            DataTable dt = CreateBookDataTable();
            foreach (var book in bestsellingBooks)
            {
                AddBookToDataTable(dt, book);
            }
            return dt;
        }

        private DataTable CreateBookDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Author", typeof(string));
            dt.Columns.Add("ISBN", typeof(long));
            dt.Columns.Add("PublishDate", typeof(DateTime));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Genre", typeof(string));
            dt.Columns.Add("Language", typeof(string));
            dt.Columns.Add("ImagePath", typeof(string));
            dt.Columns.Add("Stock", typeof(int));
            dt.Columns.Add("Sales", typeof(int));
            dt.Columns.Add("AudioLength", typeof(TimeSpan));
            dt.Columns.Add("FileSize", typeof(string));
            dt.Columns.Add("Link", typeof(string));
            dt.Columns.Add("Dimensions", typeof(string));
            dt.Columns.Add("Pages", typeof(int));
            dt.Columns.Add("CoverType", typeof(string));
            return dt;
        }

        private void AddBookToDataTable(DataTable dt, (int Id, string Title, string Author, long ISBN, DateTime PublishDate, decimal Price, string Genre, string Language, string ImagePath, int Stock, int Sales, TimeSpan? AudioLength, string FileSize, string Link, string Dimensions, int? Pages, string CoverType) book)
        {
            DataRow row = dt.NewRow();
            row["Id"] = book.Id;
            row["Title"] = book.Title;
            row["Author"] = book.Author;
            row["ISBN"] = book.ISBN;
            row["PublishDate"] = book.PublishDate;
            row["Price"] = book.Price;
            row["Genre"] = book.Genre;
            row["Language"] = book.Language;
            row["ImagePath"] = book.ImagePath;
            row["Stock"] = book.Stock;
            row["Sales"] = book.Sales;
            row["AudioLength"] = book.AudioLength ?? (object)DBNull.Value;
            row["FileSize"] = book.FileSize ?? (object)DBNull.Value; 
            row["Link"] = book.Link ?? (object)DBNull.Value; 
            row["Dimensions"] = book.Dimensions ?? (object)DBNull.Value; 
            row["Pages"] = book.Pages ?? (object)DBNull.Value;
            row["CoverType"] = book.CoverType ?? (object)DBNull.Value;
            dt.Rows.Add(row);
        }

        public DataTable GetSalesByBookType()
        {
            int audioBookSales = 0;
            int physicalBookSales = 0;

            foreach (var book in _books)
            {
                if (book.AudioLength.HasValue && !string.IsNullOrEmpty(book.FileSize) && !string.IsNullOrEmpty(book.Link))
                {
                    audioBookSales += book.Sales;
                }
                else if (!string.IsNullOrEmpty(book.Dimensions) && book.Pages.HasValue && !string.IsNullOrEmpty(book.CoverType))
                {
                    physicalBookSales += book.Sales;
                }
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("BookType", typeof(string));
            dt.Columns.Add("TotalSales", typeof(int));

            dt.Rows.Add("AudioBook", audioBookSales);
            dt.Rows.Add("PhysicalBook", physicalBookSales);

            return dt;
        }




    }
}
