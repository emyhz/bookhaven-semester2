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

        public int AddBook(string title, string author, string isbn, DateTime publishDate, decimal price, string genre, string language, string imagePath, int stock, int sales, string bookType,
                       TimeSpan? length = null, string fileSize = null, string dimensions = null, int? pages = null, string coverType = null)
        {
            // Validate the general book details
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(isbn))
            {
                throw new ArgumentException("Title, Author, and ISBN are required fields.");
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

            // Call the database method to add the book and return the generated book ID
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
                    isbn: Convert.ToInt64(row["ISBN"]), // Use Convert.ToInt64 for ISBN
                    publishYear: Convert.ToDateTime(row["PublishDate"]),
                    price: Convert.ToDecimal(row["Price"]),
                    genre: (Genre)Enum.Parse(typeof(Genre), row["Genre"].ToString()), // Assuming Genre is an enum
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
    }
}
