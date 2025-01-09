using DataAccessLayer.MockDAL;
using LogicLayer.Algorithm;
using LogicLayer.EntityClasses;
using LogicLayer.Enums;
using LogicLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenUnitTests
{
    [TestClass]
    public class RecommendationSystemTest
    {
        private RecommendationSystem _recommendationSystem;
        private OrderMock _orderMock;
        private OrderItemMock _orderItemMock;
        private BookMock _bookMock;
        private UserMock _userMock;
        private UserManager _userManager;
        private BookManager _bookManager;
        private OrderItemManager _orderItemManager;
        private OrderManager _orderManager;

        [TestInitialize]
        public void Setup()
        {
            _orderMock = new OrderMock();
            _userMock = new UserMock();
            _userManager = new UserManager(_userMock);
            _bookMock = new BookMock();
            _bookManager = new BookManager(_bookMock);
            _orderItemMock = new OrderItemMock(_bookMock);
            _orderItemManager = new OrderItemManager(_orderItemMock, _userManager, _bookManager);
            _orderManager = new OrderManager(_orderMock, _userManager, _orderItemManager);
            _recommendationSystem = new RecommendationSystem(_orderManager, _bookManager);
        }

        [TestMethod]
        public void GetFrequentlyBoughtBooks_ShouldReturnEmptyList_WhenNoOrdersExistForBook()
        {
            // Arrange
            int bookId = 1;
            int count = 5;

            // Act
            List<Book> recommendedBooks = _recommendationSystem.GetFrequentlyBoughtBooks(bookId, count);

            // Assert
            Assert.IsNotNull(recommendedBooks, "Recommended books list should not be null.");
            Assert.AreEqual(0, recommendedBooks.Count, "Recommended books list should be empty when no orders exist.");
        }

        [TestMethod]
        public void GetFrequentlyBoughtBooks_ShouldReturnEmptyList_WhenNoOtherBooksBoughtWithSpecifiedBook()
        {
            // Arrange
            int bookId = 1;
            int count = 5;
            int userId = 1;

            // Add book and order
            _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.0m, "Fiction", "English", "path/to/image1", 10, 0);
            int orderId = _orderMock.AddOrder(userId, "123 Main St", "USA", "City", "12345", 100.0m, 1);
            _orderItemMock.AddOrderItem(orderId, bookId, 1);

            // Act
            List<Book> recommendedBooks = _recommendationSystem.GetFrequentlyBoughtBooks(bookId, count);

            // Assert
            Assert.IsNotNull(recommendedBooks);
            Assert.AreEqual(0, recommendedBooks.Count, "Recommended books list should be empty when no other books are bought.");
        }

        [TestMethod]
        public void GetFrequentlyBoughtBooks_ShouldReturnFrequentlyBoughtBooks()
        {
            // Arrange
            int bookId1 = _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.0m, "FICTION", "English", "path/to/image1", 10, 0);
            int bookId2 = _bookMock.AddBook("Book 2", "Author 2", 67890, DateTime.Now, 15.0m, "NON_FICTION", "English", "path/to/image2", 8, 0);
            int bookId3 = _bookMock.AddBook("Book 3", "Author 3", 11111, DateTime.Now, 20.0m, "THRILLER", "English", "path/to/image3", 5, 0);

            int userId = 1;
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password123", "CUSTOMER");
            int orderId1 = _orderMock.AddOrder(userId, "123 Main St", "USA", "City", "12345", 50.0m, 1);

            // Add books to an order
            _orderItemMock.AddOrderItem(orderId1, bookId1, 1);
            _orderItemMock.AddOrderItem(orderId1, bookId2, 1);
            _orderItemMock.AddOrderItem(orderId1, bookId3, 1);

            // Act
            List<Book> recommendedBooks = _recommendationSystem.GetFrequentlyBoughtBooks(bookId1, 2);

            // Assert
            Assert.IsNotNull(recommendedBooks, "Recommended books list should not be null.");
            Assert.AreEqual(2, recommendedBooks.Count, "Should return two recommended books.");
            Assert.IsTrue(recommendedBooks.Any(b => b.Id == bookId2), "Recommended books should contain Book 2.");
            Assert.IsTrue(recommendedBooks.Any(b => b.Id == bookId3), "Recommended books should contain Book 3.");
        }


    }
}
