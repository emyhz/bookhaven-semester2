using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using LogicLayer.EntityClasses;
using LogicLayer.Enums;

namespace LogicLayer.Managers
{

    public class BookManager
    {
        private DBBook dbBook;
        private List<Book> books;

        public BookManager()
        {
            dbBook = new DBBook();
            books = new List<Book>();
        }

        public int AddBook(string title, string author, long isbn, DateTime publishDate, decimal price, string genre, string language, string imagePath, int stock, int sales, string bookType,
                       TimeSpan? length = null, string fileSize = null, string dimensions = null, int? pages = null, string coverType = null)
        {
            // Validate the general book details
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
            {
                throw new ArgumentException("Title and Author are required fields.");
            }

            // Check the type of book and ensure necessary parameters are provided
            if (bookType == "AudioBook")
            {
                if (!length.HasValue || string.IsNullOrEmpty(fileSize))
                {
                    throw new ArgumentException("Length and File Size are required for audiobooks.");
                }
            }
            else if (bookType == "PhysicalBook")
            {
                if (string.IsNullOrEmpty(dimensions) || !pages.HasValue || string.IsNullOrEmpty(coverType))
                {
                    throw new ArgumentException("Dimensions, Pages, and Cover Type are required for physical books.");
                }
            }
            else
            {
                // If it's a general book, no additional validation is needed
            }

            int bookId = dbBook.AddBook(title, author, isbn, publishDate, price, genre, language, imagePath, stock, sales, bookType, length, fileSize, dimensions, pages, coverType);

            return bookId;
        }

        
        public List<AudioBook> GetAllAudioBooks()
        {
            DataTable audioBooksTable = dbBook.GetAllAudioBooks();

            List<AudioBook> audioBooks = new List<AudioBook>();

            foreach (DataRow row in audioBooksTable.Rows)
            {
                AudioBook audioBook = new AudioBook(
                    id: Convert.ToInt32(row["Id"]),
                    title: row["Title"].ToString(),
                    author: row["Author"].ToString(),
                    isbn: Convert.ToInt64(row["ISBN"]), 
                    publishYear: Convert.ToDateTime(row["PublishDate"]),
                    price: Convert.ToDecimal(row["Price"]),
                    genre: (Genre)Enum.Parse(typeof(Genre), row["Genre"].ToString()),
                    language: row["Language"].ToString(),
                    imagePath: row["ImagePath"].ToString(),
                    stock: Convert.ToInt32(row["Stock"]),
                    audioLength: (TimeSpan)row["AudioLength"],
                    fileSize: row["FileSize"].ToString()
                );

                audioBooks.Add(audioBook);
            }

            return audioBooks;
        }
        public List<PhysicalBook> GetAllPhysicalBooks()
        {
            DataTable physicalBooksTable = dbBook.GetAllPhysicalBooks();

            List<PhysicalBook> physicalBooks = new List<PhysicalBook>();

            foreach (DataRow row in physicalBooksTable.Rows)
            {
                PhysicalBook physicalBook = new PhysicalBook(
                    id: Convert.ToInt32(row["Id"]),
                    title: row["Title"].ToString(),
                    author: row["Author"].ToString(),
                    isbn: Convert.ToInt64(row["ISBN"]),
                    publishYear: Convert.ToDateTime(row["PublishDate"]),
                    price: Convert.ToDecimal(row["Price"]),
                    genre: (Genre)Enum.Parse(typeof(Genre), row["Genre"].ToString()),
                    language: row["Language"].ToString(),
                    imagePath: row["ImagePath"].ToString(),
                    stock: Convert.ToInt32(row["Stock"]),
                    dimensions: row["Dimensions"].ToString(),
                    pages: Convert.ToInt32(row["Pages"]),
                    coverType: row["CoverType"].ToString()
                );

                physicalBooks.Add(physicalBook);
            }

            return physicalBooks;
        }

        public List<Book> SearchBook(string title, string author, long isbn)
        {
            List<Book> searchResult = new List<Book>();
            foreach (Book book in books)
            {
                if (book.Title.Contains(title) && book.Author.Contains(author) && book.ISBN1 == isbn)
                {
                    searchResult.Add(book);
                }
            }
            return searchResult;

        }
        public void UpdateBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book cannot be null");
            }

            string bookType = book is AudioBook ? "AudioBook" : book is PhysicalBook ? "PhysicalBook" : "Book";

            // Default parameters for book type-specific fields
            TimeSpan? length = null;
            string fileSize = null;
            string dimensions = null;
            int? pages = null;
            string coverType = null;

            // Set specific parameters based on the book type
            if (book is AudioBook audioBook)
            {
                length = audioBook.AudioLength;
                fileSize = audioBook.FileSize;
            }
            else if (book is PhysicalBook physicalBook)
            {
                dimensions = physicalBook.Dimensions;
                pages = physicalBook.Pages;
                coverType = physicalBook.CoverType;
            }

            dbBook.UpdateBook(book.Id, book.Title, book.Author, book.ISBN1.ToString(), book.PublishYear, book.Price, book.Genre.ToString(), book.Language, book.ImagePath, book.Stock, 0, bookType, length, fileSize, dimensions, pages, coverType);
        }

        public void DeleteBook(int bookId)
        {
            dbBook.DeleteBook(bookId);

        }
    }
}
