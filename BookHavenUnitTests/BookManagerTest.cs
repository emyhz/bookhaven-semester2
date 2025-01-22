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
        private Order2Mock _order2Mock;
        private OrderItem2Mock _orderItem2Mock;


        [TestInitialize]
        public void Setup()
        {
            _bookMock = new BookMock();
            _bookManager = new BookManager(_bookMock);

            _orderItem2Mock = new OrderItem2Mock(_bookMock); 
            _order2Mock = new Order2Mock(_orderItem2Mock);

            int bookId1 = _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.0m, "Fiction", "English", "path1.jpg", 100, 0);
            int bookId2 = _bookMock.AddBook("Book 2", "Author 2", 12346, DateTime.Now, 15.0m, "Fiction", "English", "path2.jpg", 50, 0);

            foreach (var book in _bookMock.GetBooks().AsEnumerable())
            {
                Console.WriteLine($"Book ID: {book["Id"]}, Title: {book["Title"]}");
            }
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

            // Assert : Verify that the book was added to the mock database
            DataTable books = _bookMock.GetBooks();
            DataRow book = books.AsEnumerable().FirstOrDefault(row => (int)row["Id"] == bookId);

            // Make sure book exists and has the correct title
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

            // Assert : Verify the books details
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

            // Assert : verify the book was updated
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

            // Act : delelte the book
            _bookManager.DeleteBook(bookId);

            // Assert : verify the book was removed
            DataTable books = _bookMock.GetBooks();
            DataRow book = books.AsEnumerable().FirstOrDefault(row => (int)row["Id"] == bookId);
            Assert.IsNull(book, "Book should be removed from the mock database.");
        }

        [TestMethod]
        public void GetBestSellingBooks_ShouldReturnTopSellingBooks()
        {
            // Arrange
            int book1Id = _bookMock.AddBook("Book 1", "Author 1", 123, DateTime.Now, 19.99m, "Fiction", "English", "path/1.jpg", 20, 0);
            int book2Id = _bookMock.AddBook("Book 2", "Author 2", 456, DateTime.Now, 29.99m, "Fiction", "English", "path/2.jpg", 15, 0);
            int book3Id = _bookMock.AddBook("Book 3", "Author 3", 789, DateTime.Now, 39.99m, "Fiction", "English", "path/3.jpg", 10, 0);

            // Simulate purchases
            _bookMock.BuyBook(book1Id, 5); // Book 1 sold 5 copies
            _bookMock.BuyBook(book2Id, 10); // Book 2 sold 10 copies
            _bookMock.BuyBook(book3Id, 8); // Book 3 sold 8 copies

            // Act : get the top 2 best-selling books
            DataTable bestSellingBooksTable = _bookMock.GetBestSellingBooks(2);

            // Assert: Validate the top 2 books
            Assert.AreEqual(2, bestSellingBooksTable.Rows.Count, "Should return the top 2 best-selling books.");

            Assert.AreEqual("Book 2", bestSellingBooksTable.Rows[0]["Title"], "First book should be the top seller.");
            Assert.AreEqual("Book 3", bestSellingBooksTable.Rows[1]["Title"], "Second book should be the next top seller.");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuyBook_ShouldThrowException_WhenQuantityIsZeroOrNegative()
        {
            // Arrange : add book with stock of 10
            int bookId = _bookMock.AddBook("Buy Test", "Author", 123, DateTime.Now, 19.99m, "Fiction", "English", "path.jpg", 10, 0);

            // Act : try to buy 0 copies
            _bookManager.BuyBook(bookId, 0);

            // Assert : handled by ExpectedException attribute
        }

        [TestMethod]
        public void BuyBook_ShouldReduceStockAndIncreaseSales()
        {
            // Arrange : add stock 10 and sales 0
            int bookId = _bookMock.AddBook("Buy Test", "Author", 123, DateTime.Now, 19.99m, "Fiction", "English", "path.jpg", 10, 0);

            // Act
            _bookManager.BuyBook(bookId, 3);

            // Assert : check that stock and sales were updated
            DataTable books = _bookMock.GetBooks();
            DataRow book = books.AsEnumerable().FirstOrDefault(row => (int)row["Id"] == bookId);
            Assert.AreEqual(7, book["Stock"], "Stock should be reduced by 3.");
            Assert.AreEqual(3, book["Sales"], "Sales should increase by 3.");
        }

        [TestMethod]
        public void BookMock_GetBookById_ShouldReturnCorrectBook()
        {
            // Arrange 
            int bookId = _bookMock.AddBook("Book 2", "Author 1", 23456, DateTime.Now, 10.0m, "Fiction", "English", "path/to/image1", 10, 0);
            Console.WriteLine($"Book added with ID: {bookId}");

            // Act : get the book by ID
            DataTable bookTable = null; // DataTable to store the result
            try
            {
                bookTable = _bookMock.GetBookById(bookId); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                Assert.Fail("GetBookById threw an exception.");
            }

            // Assert : Verify the retrieved book matches the expected properties
            Assert.IsNotNull(bookTable, "DataTable should not be null.");
            Assert.AreEqual(1, bookTable.Rows.Count, "Book should be retrieved.");
            Assert.AreEqual("Book 2", bookTable.Rows[0]["Title"], "Book title should match.");
        }


        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetBookById_ShouldThrowException_ForInvalidId()
        {
            // Arrange
            int invalidBookId = 999; // An ID that does not exist

            // Act
            var bookTable = _bookMock.GetBookById(invalidBookId);

        }

    }
}
