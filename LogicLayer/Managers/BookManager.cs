using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using LogicLayer.EntityClasses;
using LogicLayer.Enums;

namespace LogicLayer.Managers
{

    public class BookManager
    {
        private IBookDb _bookDb;
        private List<Book> _books;

        public BookManager(IBookDb bookDb)
        {
            _bookDb = bookDb;
            _books = GetAllBooks();
        }

        
        //new method to add book
        public int AddBook(string title, string author, long isbn, DateTime publishDate, decimal price, string genre, string language, string imagePath, int stock, int sales,
    TimeSpan? audioLength = null, string fileSize = null, string dimensions = null, int? pages = null, string coverType = null)
        {
            // Validate general book details
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
            {
                throw new ArgumentException("Title and Author are required fields.");
            }

            // Ensure the required parameters are provided for each type of book
            if (audioLength.HasValue && !string.IsNullOrEmpty(fileSize))
            {
                // Validate audiobook fields
                return _bookDb.AddBook(title, author, isbn, publishDate, price, genre, language, imagePath, stock, sales, audioLength, fileSize);
            }
            else if (!string.IsNullOrEmpty(dimensions) && pages.HasValue && !string.IsNullOrEmpty(coverType))
            {
                // Validate physical book fields
                return _bookDb.AddBook(title, author, isbn, publishDate, price, genre, language, imagePath, stock, sales, dimensions: dimensions, pages: pages, coverType: coverType);
            }
            else
            {
                throw new ArgumentException("Invalid book details provided. Ensure required fields are filled for the specific type of book.");
            }
        }




        public List<Book> GetAllBooks()
        {
            DataTable dt = _bookDb.GetBooks();
            List<Book> allBooks = new List<Book>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Book book;

                    // Check if it's an AudioBook by the presence of audio-specific fields
                    if (!string.IsNullOrEmpty(row["AudioLength"].ToString()) && !string.IsNullOrEmpty(row["FileSize"].ToString()))
                    {
                        book = new AudioBook(
                            id: Convert.ToInt32(row["ID"]),
                            title: row["Title"].ToString(),
                            author: row["Author"].ToString(),
                            isbn: Convert.ToInt64(row["ISBN"]),
                            publishYear: Convert.ToDateTime(row["PublishDate"]),
                            price: Convert.ToDecimal(row["Price"]),
                            genre: (Genre)Enum.Parse(typeof(Genre), row["Genre"].ToString()),
                            language: row["Language"].ToString(),
                            imagePath: row["ImagePath"].ToString(),
                            stock: Convert.ToInt32(row["Stock"]),
                            sales: Convert.ToInt32(row["Sales"]),
                            audioLength: TimeSpan.Parse(row["AudioLength"].ToString()),
                            fileSize: row["FileSize"].ToString()
                        );
                    }
                    // Check if it's a PhysicalBook by the presence of physical-specific fields
                    else if (!string.IsNullOrEmpty(row["Dimensions"].ToString()) && !string.IsNullOrEmpty(row["CoverType"].ToString()))
                    {
                        book = new PhysicalBook(
                            id: Convert.ToInt32(row["ID"]),
                            title: row["Title"].ToString(),
                            author: row["Author"].ToString(),
                            isbn: Convert.ToInt64(row["ISBN"]),
                            publishYear: Convert.ToDateTime(row["PublishDate"]),
                            price: Convert.ToDecimal(row["Price"]),
                            genre: (Genre)Enum.Parse(typeof(Genre), row["Genre"].ToString()),
                            language: row["Language"].ToString(),
                            imagePath: row["ImagePath"].ToString(),
                            stock: Convert.ToInt32(row["Stock"]),
                            sales: Convert.ToInt32(row["Sales"]),
                            dimensions: row["Dimensions"].ToString(),
                            pages: Convert.ToInt32(row["Pages"]),
                            coverType: row["CoverType"].ToString()
                        );
                    }
                    else
                    {
                        continue; // Skip if it's neither AudioBook nor PhysicalBook
                    }

                    allBooks.Add(book);
                }
            }

            return allBooks;
        }

        public List<Book> SearchBook(string title, string author)
        {
            List<Book> searchResult = new List<Book>();

            foreach (Book book in _books)
            {
                bool matchesTitle = string.IsNullOrEmpty(title) || book.Title.Contains(title, StringComparison.OrdinalIgnoreCase);
                bool matchesAuthor = string.IsNullOrEmpty(author) || book.Author.Contains(author, StringComparison.OrdinalIgnoreCase);


                if (matchesTitle && matchesAuthor)
                {
                    searchResult.Add(book);
                }
            }

            return searchResult;
        }
       

        public void UpdateBook(int id, string title, string author, long isbn, DateTime publishYear, decimal price, string genre, string language, string imagePath, int stock,
    TimeSpan? length = null, string fileSize = null, string dimensions = null, int? pages = null, string coverType = null)
        {
            _bookDb.UpdateBook(id, title, author, isbn, publishYear, price, genre, language, imagePath, stock, length, fileSize, dimensions, pages, coverType);
        }

        public void DeleteBook(int bookId)
        {
            _bookDb.DeleteBook(bookId);

        }

        // Get summary of all books
        public List<Book> GetBooksSummary()
        {
            DataTable dt = _bookDb.GetBooksSummary();

            _books = new List<Book>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Book book = null;

                    // Check if it's an audiobook or physical book
                    string bookType = row["BookType"].ToString();
                    if (bookType == "AudioBook")
                    {
                        book = new AudioBook(
                            id: Convert.ToInt32(row["ID"]),
                            title: row["Title"].ToString(),
                            author: row["Author"].ToString(),
                            isbn: Convert.ToInt64(row["ISBN"]),
                            publishYear: Convert.ToDateTime(row["PublishDate"]),
                            price: Convert.ToDecimal(row["Price"]),
                            genre: (Genre)Enum.Parse(typeof(Genre), row["Genre"].ToString()),
                            language: row["Language"].ToString(),
                            imagePath: row["ImagePath"].ToString(),
                            stock: Convert.ToInt32(row["Stock"]),
                            sales: Convert.ToInt32(row["Sales"]),
                            audioLength: (TimeSpan)row["AudioLength"],
                            fileSize: row["FileSize"].ToString()
                        );
                    }
                    else if (bookType == "PhysicalBook")
                    {
                        book = new PhysicalBook(
                            id: Convert.ToInt32(row["ID"]),
                            title: row["Title"].ToString(),
                            author: row["Author"].ToString(),
                            isbn: Convert.ToInt64(row["ISBN"]),
                            publishYear: Convert.ToDateTime(row["PublishDate"]),
                            price: Convert.ToDecimal(row["Price"]),
                            genre: (Genre)Enum.Parse(typeof(Genre), row["Genre"].ToString()),
                            language: row["Language"].ToString(),
                            imagePath: row["ImagePath"].ToString(),
                            stock: Convert.ToInt32(row["Stock"]),
                            sales: Convert.ToInt32(row["Sales"]),
                            dimensions: row["Dimensions"].ToString(),
                            pages: Convert.ToInt32(row["Pages"]),
                            coverType: row["CoverType"].ToString()
                        );
                    }

                    _books.Add(book);
                }
            }

            return _books;
        }

        // Get a book by its ID (could be AudioBook or PhysicalBook)
        public Book GetBookById(int id)
        {
            DataTable dt = _bookDb.GetBookDetails(id);
            Book book = null; // Initialize book to null

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                string bookType = row["BookType"].ToString();

                if (bookType == "AudioBook")
                {
                    book = new AudioBook(
                        id: Convert.ToInt32(row["ID"]),
                        title: row["Title"].ToString(),
                        author: row["Author"].ToString(),
                        isbn: Convert.ToInt64(row["ISBN"]),
                        publishYear: Convert.ToDateTime(row["PublishDate"]),
                        price: Convert.ToDecimal(row["Price"]),
                        genre: (Genre)Enum.Parse(typeof(Genre), row["Genre"].ToString()),
                        language: row["Language"].ToString(),
                        imagePath: row["ImagePath"].ToString(),
                        stock: Convert.ToInt32(row["Stock"]),
                        sales: Convert.ToInt32(row["Sales"]),
                        audioLength: (TimeSpan)row["AudioLength"],
                        fileSize: row["FileSize"].ToString()
                    );
                }
                else if (bookType == "PhysicalBook")
                {
                    book = new PhysicalBook(
                        id: Convert.ToInt32(row["ID"]),
                        title: row["Title"].ToString(),
                        author: row["Author"].ToString(),
                        isbn: Convert.ToInt64(row["ISBN"]),
                        publishYear: Convert.ToDateTime(row["PublishDate"]),
                        price: Convert.ToDecimal(row["Price"]),
                        genre: (Genre)Enum.Parse(typeof(Genre), row["Genre"].ToString()),
                        language: row["Language"].ToString(),
                        imagePath: row["ImagePath"].ToString(),
                        stock: Convert.ToInt32(row["Stock"]),
                        sales: Convert.ToInt32(row["Sales"]),
                        dimensions: row["Dimensions"].ToString(),
                        pages: Convert.ToInt32(row["Pages"]),
                        coverType: row["CoverType"].ToString()
                    );
                }
            }

            return book; // Return null if no book was found or type doesn't match
        }
        public void BuyBook(int bookId, int quantity)
        {
            if(GetBookById(bookId).Stock > quantity)
            {
                _bookDb.BuyBook(bookId, quantity);
            }
        }

        public List<Book> GetBestSellingBooks(int count)
        {
            DataTable dt = _bookDb.GetBestSellingBooks(count);
            List<Book> bestSellingBooks = new List<Book>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Book book;

                    if (!string.IsNullOrEmpty(row["AudioLength"].ToString()) && !string.IsNullOrEmpty(row["FileSize"].ToString()))
                    {
                        book = new AudioBook(
                            id: Convert.ToInt32(row["Id"]),
                            title: row["Title"].ToString(),
                            author: row["Author"].ToString(),
                            isbn: 0, 
                            publishYear: DateTime.MinValue,
                            price: Convert.ToDecimal(row["Price"]),
                            genre: (Genre)0,
                            language: "Unknown",
                            imagePath: row["ImagePath"].ToString(),
                            stock: 0, 
                            sales: Convert.ToInt32(row["Sales"]),
                            audioLength: TimeSpan.Parse(row["AudioLength"].ToString()),
                            fileSize: row["FileSize"].ToString()
                        );
                    }
                    else if (!string.IsNullOrEmpty(row["Dimensions"].ToString()) && !string.IsNullOrEmpty(row["CoverType"].ToString()))
                    {
                        book = new PhysicalBook(
                            id: Convert.ToInt32(row["Id"]),
                            title: row["Title"].ToString(),
                            author: row["Author"].ToString(),
                            isbn: 0, 
                            publishYear: DateTime.MinValue, 
                            price: Convert.ToDecimal(row["Price"]),
                            genre: (Genre)0,
                            language: "Unknown",
                            imagePath: row["ImagePath"].ToString(),
                            stock: 0,
                            sales: Convert.ToInt32(row["Sales"]),
                            dimensions: row["Dimensions"].ToString(),
                            pages: 0,
                            coverType: row["CoverType"].ToString()
                        );
                    }
                    else
                    {
                        continue;
                    }

                    bestSellingBooks.Add(book);
                }
            }

            return bestSellingBooks;
        }
    }
}
