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

        // List to store books as mock data

        private List<(int Id, string Title, string Author, long ISBN, DateTime PublishDate, decimal Price, string Genre, string Language, string ImagePath, int Stock, int Sales, TimeSpan? AudioLength, string FileSize, string Link, string Dimensions, int? Pages, string CoverType)> _books = new List<(int, string, string, long, DateTime, decimal, string, string, string, int, int, TimeSpan?, string, string, string, int?, string)>();
        private int _nextId = 1; // Next ID to assign to a new book




        public int AddBook(string title, string author, long isbn, DateTime publishDate, decimal price, string genre, string language, string imagePath, int stock, int sales,
    TimeSpan? audioLength = null, string fileSize = null, string link = null, string dimensions = null, int? pages = null, string coverType = null)
        {

            // Check if a book with the same title and ISBN already exists
            if (_books.Any(b => b.Title == title && b.Author == author && b.ISBN == isbn))
            {
                throw new InvalidOperationException($"A book with title '{title}' and ISBN '{isbn}' already exists.");
            }

            int newId = _nextId++; // Generate a new ID
            _books.Add((newId, title, author, isbn, publishDate, price, genre, language, imagePath, stock, sales, audioLength, fileSize, link, dimensions, pages, coverType));
            return newId;
        }

        public DataTable GetBookById(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);

            if (book.Equals(default((int, string, string, long, DateTime, decimal, string, string, string, int, int, TimeSpan?, string, string, string, int?, string))))
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }

            DataTable dt = CreateBookDataTable(); // Create a DataTable structure
            AddBookToDataTable(dt, book); // Add the book data to the DataTable
            return dt;
        }


        // Updates an existing book in the mock database
        public void UpdateBook(int id, string title, string author, long isbn, DateTime publishDate, decimal price, string genre, string language, string imagePath, int stock,
            TimeSpan? length = null, string fileSize = null, string link = null, string dimensions = null, int? pages = null, string coverType = null)
        {
            var index = _books.FindIndex(b => b.Id == id);
            if (index < 0)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }

            // Check for duplicate ISBN
            if (_books.Any(b => b.ISBN == isbn && b.Id != id))
            {
                throw new InvalidOperationException($"A book with ISBN '{isbn}' already exists.");
            }

            // Update the book's data
            _books[index] = (id, title, author, isbn, publishDate, price, genre, language, imagePath, stock, _books[index].Sales, length, fileSize, link, dimensions, pages, coverType);
        }

        // Deletes a book by its ID
        public void DeleteBook(int id)
        {
            var index = _books.FindIndex(b => b.Id == id);
            if (index >= 0)
            {
                _books.RemoveAt(index); // Remove the book from the list
            }
            else
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }
        }

        // Retrieves all books in the mock database
        public DataTable GetBooks()
        {
            Console.WriteLine("Fetching all books from BookMock...");
            Console.WriteLine($"Total books in BookMock: {_books.Count}");
            DataTable dt = CreateBookDataTable();
            foreach (var book in _books)
            {
                Console.WriteLine($"Book ID: {book.Id}, Title: {book.Title}");
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
            return GetBooks(); 
        }

        public DataTable GetBookDetails(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);

            if (book.Equals(default((int, string, string, long, DateTime, decimal, string, string, string, int, int, TimeSpan?, string, string, string, int?, string))))
            {
                Console.WriteLine($"Book with ID {id} not found in BookMock.");
                return new DataTable(); // Empty DataTable
            }

            DataTable dt = CreateBookDataTable();
            AddBookToDataTable(dt, book);
            return dt;
        }


        public void BuyBook(int bookId, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }

            var index = _books.FindIndex(b => b.Id == bookId);
            if (index < 0)
            {
                throw new KeyNotFoundException($"Book with ID {bookId} not found.");
            }

            if (_books[index].Stock < quantity)
            {
                throw new InvalidOperationException("Insufficient stock.");
            }

            _books[index] = (_books[index].Id, _books[index].Title, _books[index].Author, _books[index].ISBN, _books[index].PublishDate, _books[index].Price, _books[index].Genre,
                _books[index].Language, _books[index].ImagePath, _books[index].Stock - quantity, _books[index].Sales + quantity, _books[index].AudioLength, _books[index].FileSize,
                _books[index].Link, _books[index].Dimensions, _books[index].Pages, _books[index].CoverType);
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

        // Helper method to create the structure of a DataTable for books
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

        // Helper method to add a book's data to a DataTable
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


        public int GetTotalBooksCount()
        {
            // Return a fixed number representing the total number of books in the mock dataset
            return 50; // Example: Simulate 50 books in the dataset
        }

        public DataTable GetBooksWithPagination(int currentPage, int pageSize)
        {
            // Create a mock DataTable
            DataTable booksTable = new DataTable();
            booksTable.Columns.Add("Id", typeof(int));
            booksTable.Columns.Add("Title", typeof(string));
            booksTable.Columns.Add("Author", typeof(string));
            booksTable.Columns.Add("ISBN", typeof(long));
            booksTable.Columns.Add("PublishDate", typeof(DateTime));
            booksTable.Columns.Add("Price", typeof(decimal));
            booksTable.Columns.Add("Genre", typeof(string));
            booksTable.Columns.Add("Language", typeof(string));
            booksTable.Columns.Add("ImagePath", typeof(string));
            booksTable.Columns.Add("Stock", typeof(int));
            booksTable.Columns.Add("AudioLength", typeof(string)); // Nullable for AudioBook
            booksTable.Columns.Add("FileSize", typeof(string));    // Nullable for AudioBook
            booksTable.Columns.Add("Link", typeof(string));        // Nullable for AudioBook
            booksTable.Columns.Add("Dimensions", typeof(string));  // Nullable for PhysicalBook
            booksTable.Columns.Add("Pages", typeof(int));          // Nullable for PhysicalBook
            booksTable.Columns.Add("CoverType", typeof(string));   // Nullable for PhysicalBook

            // Calculate the starting index and ending index for the current page
            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = startIndex + pageSize;

            // Add mock data to the DataTable (simulate a total of 50 books)
            for (int i = startIndex; i < endIndex && i < 50; i++) // Limit to 50 books for mock data
            {
                // Alternate between AudioBook and PhysicalBook mock data
                if (i % 2 == 0) // Even index: AudioBook
                {
                    booksTable.Rows.Add(
                        i + 1,                        // Id
                        $"AudioBook Title {i + 1}",   // Title
                        $"Author {i + 1}",            // Author
                        1234567890123 + i,            // ISBN
                        DateTime.Now.AddDays(-i),     // PublishDate
                        19.99m + i,                   // Price
                        "Fiction",                    // Genre
                        "English",                    // Language
                        $"/images/book{i + 1}.jpg",   // ImagePath
                        100 - i,                      // Stock
                        $"00:30:{i % 60}",            // AudioLength
                        $"{i} MB",                    // FileSize
                        $"http://audiobook{i + 1}.com", // Link
                        DBNull.Value,                 // Dimensions
                        DBNull.Value,                 // Pages
                        DBNull.Value                  // CoverType
                    );
                }
                else // Odd index: PhysicalBook
                {
                    booksTable.Rows.Add(
                        i + 1,                        // Id
                        $"PhysicalBook Title {i + 1}",// Title
                        $"Author {i + 1}",            // Author
                        1234567890123 + i,            // ISBN
                        DateTime.Now.AddDays(-i),     // PublishDate
                        9.99m + i,                    // Price
                        "Non-Fiction",                // Genre
                        "English",                    // Language
                        $"/images/book{i + 1}.jpg",   // ImagePath
                        50 - i,                       // Stock
                        DBNull.Value,                 // AudioLength
                        DBNull.Value,                 // FileSize
                        DBNull.Value,                 // Link
                        $"{i}x{i}x{i}",               // Dimensions
                        100 + i,                      // Pages
                        "Hardcover"                   // CoverType
                    );
                }
            }

            return booksTable;
        }



    }
}
