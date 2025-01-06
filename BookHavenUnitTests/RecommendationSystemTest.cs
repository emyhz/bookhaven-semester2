using DataAccessLayer.MockDAL;
using LogicLayer.Algorithm;
using LogicLayer.EntityClasses;
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
            _orderItemMock = new OrderItemMock();
            _orderItemManager = new OrderItemManager(_orderItemMock, _userManager, _bookManager);
            _orderManager = new OrderManager(_orderMock, _userManager, _orderItemManager);
            _recommendationSystem = new RecommendationSystem(_orderManager, _bookManager);
        }

        [TestMethod]
        public void GetFrequentlyBoughtBooks_ShouldReturnBooksFrequentlyBoughtWithSpecifiedBook()
        {
            // Arrange
            // Add users
            int user1Id = 1;
            int user2Id = 2;
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password123", "CUSTOMER");
            _userMock.AddUser("Jane", "Smith", "jane.smith@example.com", "password123", "CUSTOMER");

            // Add books
            int bookId1 = _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.00m, "Fiction", "English", "path1", 10, 0);
            int bookId2 = _bookMock.AddBook("Book 2", "Author 2", 67890, DateTime.Now, 15.00m, "Non-Fiction", "English", "path2", 10, 0);
            int bookId3 = _bookMock.AddBook("Book 3", "Author 3", 11223, DateTime.Now, 20.00m, "Fiction", "English", "path3", 10, 0);

            // Add orders for User 1
            int orderId1 = _orderMock.AddOrder(user1Id, "123 Street", "Country", "City", "12345", 25.00m, 1);
            _orderItemMock.AddItemToCart(user1Id, bookId1, 1); // Bought Book 1
            _orderItemMock.AddItemToCart(user1Id, bookId2, 1); // Bought Book 2
            _orderItemMock.Checkout(orderId1, 1);
            _orderItemMock.Checkout(orderId1, 2);

            // Add orders for User 2
            int orderId2 = _orderMock.AddOrder(user2Id, "456 Avenue", "Country", "City", "67890", 35.00m, 1);
            _orderItemMock.AddItemToCart(user2Id, bookId1, 1); // Bought Book 1
            _orderItemMock.AddItemToCart(user2Id, bookId3, 1); // Bought Book 3
            _orderItemMock.Checkout(orderId2, 3);
            _orderItemMock.Checkout(orderId2, 4);

            // Act
            List<Book> recommendedBooks = _recommendationSystem.GetFrequentlyBoughtBooks(bookId1, 2);

            // Assert
            Assert.AreEqual(2, recommendedBooks.Count, "Should return two books frequently bought with the specified book.");
            Assert.IsTrue(recommendedBooks.Exists(b => b.Id == bookId2), "Recommended books should include Book 2.");
            Assert.IsTrue(recommendedBooks.Exists(b => b.Id == bookId3), "Recommended books should include Book 3.");
        }

        [TestMethod]
        public void GetFrequentlyBoughtBooks_ShouldReturnEmptyListWhenNoOtherBooksBought()
        {
            // Arrange
            int userId = 1;
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password123", "CUSTOMER");

            int bookId1 = _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.00m, "Fiction", "English", "path1", 10, 0);

            int orderId1 = _orderMock.AddOrder(userId, "123 Street", "Country", "City", "12345", 10.00m, 1);
            _orderItemMock.AddItemToCart(userId, bookId1, 1);
            _orderItemMock.Checkout(orderId1, 1);

            // Act
            List<Book> recommendedBooks = _recommendationSystem.GetFrequentlyBoughtBooks(bookId1, 2);

            // Assert
            Assert.AreEqual(0, recommendedBooks.Count, "Should return an empty list when no other books were bought.");
        }

        [TestMethod]
        public void GetFrequentlyBoughtBooks_ShouldLimitResultsToSpecifiedCount()
        {
            // Arrange
            int userId = 1;
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password123", "CUSTOMER");

            int bookId1 = _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.00m, "Fiction", "English", "path1", 10, 0);
            int bookId2 = _bookMock.AddBook("Book 2", "Author 2", 67890, DateTime.Now, 15.00m, "Non-Fiction", "English", "path2", 10, 0);
            int bookId3 = _bookMock.AddBook("Book 3", "Author 3", 11223, DateTime.Now, 20.00m, "Fiction", "English", "path3", 10, 0);
            int bookId4 = _bookMock.AddBook("Book 4", "Author 4", 44556, DateTime.Now, 25.00m, "Drama", "English", "path4", 10, 0);

            int orderId1 = _orderMock.AddOrder(userId, "123 Street", "Country", "City", "12345", 75.00m, 1);
            _orderItemMock.AddItemToCart(userId, bookId1, 1);
            _orderItemMock.AddItemToCart(userId, bookId2, 1);
            _orderItemMock.AddItemToCart(userId, bookId3, 1);
            _orderItemMock.AddItemToCart(userId, bookId4, 1);
            _orderItemMock.Checkout(orderId1, 1);
            _orderItemMock.Checkout(orderId1, 2);
            _orderItemMock.Checkout(orderId1, 3);
            _orderItemMock.Checkout(orderId1, 4);

            // Act
            List<Book> recommendedBooks = _recommendationSystem.GetFrequentlyBoughtBooks(bookId1, 2);

            // Assert
            Assert.AreEqual(2, recommendedBooks.Count, "Should limit the results to the specified count.");
        }
    }
}
