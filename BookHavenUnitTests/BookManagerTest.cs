using DataAccessLayer.MockDAL;
using LogicLayer.EntityClasses;
using LogicLayer.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenUnitTests
{
    [TestClass]
    public class BookManagerTest
    {
        private BookManager _bookManager;
        private BookMock _bookMock;

        [TestInitialize]
        public void Setup()
        {
            _bookMock = new BookMock();
            _bookManager = new BookManager(_bookMock);
        }

        [TestMethod]
        public void AddBook_ShouldAddBookToMockDb()
        {
            // Act
            int bookId = _bookManager.AddBook(
                title: "Test Book",
                author: "Test Author",
                isbn: 1234567890,
                publishDate: DateTime.Now,
                price: 19.99m,
                genre: "Fiction",
                language: "English",
                imagePath: "path/to/image.jpg",
                stock: 10,
                sales: 0,
                dimensions: "6x9",
                pages: 300,
                coverType: "Hardcover"
            );

            // Assert
            DataTable books = _bookMock.GetBooks();
            DataRow book = books.AsEnumerable().FirstOrDefault(row => (int)row["Id"] == bookId);
            Assert.IsNotNull(book, "Book should be added to the mock database.");
            Assert.AreEqual("Test Book", book["Title"], "Book title should match.");
        }

        [TestMethod]
        public void GetBookById_ShouldReturnCorrectBook()
        {
            // Arrange
            int bookId = _bookMock.AddBook(
                title: "Sample Book",
                author: "Sample Author",
                isbn: 9876543210,
                publishDate: DateTime.Now,
                price: 29.99m,
                genre: "SCIENCE_FICTION",
                language: "English",
                imagePath: "path/to/sample.jpg",
                stock: 5,
                sales: 2,
                dimensions: "7x10",
                pages: 150,
                coverType: "Paperback"
            );

            // Act
            Book book = _bookManager.GetBookById(bookId);

            // Assert
            Assert.IsNotNull(book, "Book should not be null.");
            Assert.AreEqual("Sample Book", book.Title, "Book title should match.");
        }

        [TestMethod]
        public void UpdateBook_ShouldUpdateBookDetailsInMockDb()
        {
            // Arrange
            int bookId = _bookMock.AddBook(
                title: "Old Title",
                author: "Old Author",
                isbn: 1111111111,
                publishDate: DateTime.Now.AddYears(-1),
                price: 15.99m,
                genre: "Old Genre",
                language: "English",
                imagePath: "path/to/old.jpg",
                stock: 8,
                sales: 5
            );

            // Act
            _bookManager.UpdateBook(
                id: bookId,
                title: "New Title",
                author: "New Author",
                isbn: 2222222222,
                publishYear: DateTime.Now,
                price: 19.99m,
                genre: "New Genre",
                language: "English",
                imagePath: "path/to/new.jpg",
                stock: 12
            );

            // Assert
            DataTable books = _bookMock.GetBooks();
            DataRow book = books.AsEnumerable().FirstOrDefault(row => (int)row["Id"] == bookId);
            Assert.AreEqual("New Title", book["Title"], "Book title should be updated.");
        }

        [TestMethod]
        public void DeleteBook_ShouldRemoveBookFromMockDb()
        {
            // Arrange
            int bookId = _bookMock.AddBook(
                title: "Delete Me",
                author: "Author",
                isbn: 1231231231,
                publishDate: DateTime.Now,
                price: 9.99m,
                genre: "Thriller",
                language: "English",
                imagePath: "path/to/delete.jpg",
                stock: 10,
                sales: 0
            );

            // Act
            _bookManager.DeleteBook(bookId);

            // Assert
            DataTable books = _bookMock.GetBooks();
            DataRow book = books.AsEnumerable().FirstOrDefault(row => (int)row["Id"] == bookId);
            Assert.IsNull(book, "Book should be removed from the mock database.");
        }

        [TestMethod]
        public void GetBestSellingBooks_ShouldReturnTopSellingBooks()
        {
            // Arrange
            int book1Id = _bookMock.AddBook("Book 1", "Author 1", 123, DateTime.Now, 19.99m, "Fiction", "English", "path/1.jpg", 20, 0); // Stock: 20
            int book2Id = _bookMock.AddBook("Book 2", "Author 2", 456, DateTime.Now, 29.99m, "Fiction", "English", "path/2.jpg", 15, 0); // Stock: 15
            int book3Id = _bookMock.AddBook("Book 3", "Author 3", 789, DateTime.Now, 39.99m, "Fiction", "English", "path/3.jpg", 10, 0); // Stock: 10

            // Simulate purchases
            _bookManager.BuyBook(book1Id, 5); // Book 1 sold 5 copies
            _bookManager.BuyBook(book2Id, 10); // Book 2 sold 10 copies
            _bookManager.BuyBook(book3Id, 8); // Book 3 sold 8 copies

            // Act
            List<Book> bestSellingBooks = _bookManager.GetBestSellingBooks(2);

            // Assert
            Assert.AreEqual(2, bestSellingBooks.Count, "Should return the top 2 best-selling books.");
            Assert.AreEqual("Book 2", bestSellingBooks[0].Title, "First book should be the top seller.");
            Assert.AreEqual("Book 3", bestSellingBooks[1].Title, "Second book should be the next top seller.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuyBook_ShouldThrowException_WhenQuantityIsZeroOrNegative()
        {
            // Arrange
            int bookId = _bookMock.AddBook("Buy Test", "Author", 123, DateTime.Now, 19.99m, "Fiction", "English", "path.jpg", 10, 0);

            // Act
            _bookManager.BuyBook(bookId, 0);
        }

        [TestMethod]
        public void BuyBook_ShouldReduceStockAndIncreaseSales()
        {
            // Arrange
            int bookId = _bookMock.AddBook("Buy Test", "Author", 123, DateTime.Now, 19.99m, "Fiction", "English", "path.jpg", 10, 0);

            // Act
            _bookManager.BuyBook(bookId, 3);

            // Assert
            DataTable books = _bookMock.GetBooks();
            DataRow book = books.AsEnumerable().FirstOrDefault(row => (int)row["Id"] == bookId);
            Assert.AreEqual(7, book["Stock"], "Stock should be reduced by 3.");
            Assert.AreEqual(3, book["Sales"], "Sales should increase by 3.");
        }


    }
}
