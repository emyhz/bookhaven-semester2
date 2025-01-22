using DataAccessLayer.MockDAL;
using LogicLayer.Algorithm;
using LogicLayer.EntityClasses;
using LogicLayer.Enums;
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
    public class RecommendationSystemTest
    {
        private RecommendationSystem _recommendationSystem;
        private OrderManager _orderManager;
        private BookManager _bookManager;
        private Order2Mock _order2Mock;
        private OrderItem2Mock _orderItem2Mock;
        private BookMock _bookMock;
        private UserMock _userMock;
        private UserManager _userManager;

        [TestInitialize]
        public void Setup()
        {
            _userMock = new UserMock();
            _userManager = new UserManager(_userMock);
            _bookMock = new BookMock();
            _bookManager = new BookManager(_bookMock);
            _orderItem2Mock = new OrderItem2Mock(_bookMock);
            _order2Mock = new Order2Mock(_orderItem2Mock);
            _orderManager = new OrderManager(_order2Mock, _userManager, new OrderItemManager(_orderItem2Mock, _userManager, _bookManager));
            _recommendationSystem = new RecommendationSystem(_orderManager, _bookManager);

            // Setup initial data
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password", "CUSTOMER");
            var user = _userManager.GetUserByEmail("john.doe@example.com"); // Retrieve the user
            int userId = user.Id; // Get the user ID

            int bookId1 = _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.0m, "Fiction", "English", "path1.jpg", 100, 0);
            int bookId2 = _bookMock.AddBook("Book 2", "Author 2", 12346, DateTime.Now, 15.0m, "Fiction", "English", "path2.jpg", 50, 0);
            int orderId = _order2Mock.AddOrder(userId, "Address 1", "Country", "City", "12345", 50.0m, 1);
            _orderItem2Mock.AddOrderItem(orderId, bookId1, 2);
            _orderItem2Mock.AddOrderItem(orderId, bookId2, 1);
        }

        [TestMethod]
        public void GetFrequentlyBoughtBooks_ShouldReturnCorrectRecommendations()
        {
            // Arrange
            var bookId = _bookMock.AddBook("Book 1", "Author 1", 45752, DateTime.Now, 10.0m, "Fiction", "English", "path1.jpg", 100, 0);
            var book2Id = _bookMock.AddBook("Book 2", "Author 2", 56732, DateTime.Now, 15.0m, "Fiction", "English", "path2.jpg", 50, 0);
            var book3Id = _bookMock.AddBook("Book 3", "Author 3", 12347, DateTime.Now, 20.0m, "Non-Fiction", "English", "path3.jpg", 30, 0);

            Console.WriteLine($"Added Book IDs: {bookId}, {book2Id}, {book3Id}");

            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password", "CUSTOMER");
            var user = _userManager.GetUserByEmail("john.doe@example.com");

            var orderId1 = _order2Mock.AddOrder(user.Id, "123 Street", "Country", "City", "12345", 100.0m, 1);
            _orderItem2Mock.AddOrderItem(orderId1, bookId, 2);
            _orderItem2Mock.AddOrderItem(orderId1, book2Id, 1);

            var orderId2 = _order2Mock.AddOrder(user.Id, "456 Avenue", "Country", "City", "67890", 50.0m, 1);
            _orderItem2Mock.AddOrderItem(orderId2, book2Id, 3);
            _orderItem2Mock.AddOrderItem(orderId2, book3Id, 1);

            // Act
            var recommendations = _recommendationSystem.GetFrequentlyBoughtBooks(bookId, 2);

            // Assert
            Assert.AreEqual(2, recommendations.Count, "Should return the top 2 recommended books.");
            Assert.AreEqual(book2Id, recommendations[0].Id, "Book 2 should be the most frequently bought book.");
            Assert.AreEqual(book3Id, recommendations[1].Id, "Book 3 should be the next frequently bought book.");
        }


        [TestMethod]
        public void GetFrequentlyBoughtBooks_ShouldExcludeTargetBook()
        {
            // Arrange
            var bookId = _bookMock.AddBook("Book 10", "Author 1", 56873, DateTime.Now, 10.0m, "Fiction", "English", "path1.jpg", 100, 0);
            var book2Id = _bookMock.AddBook("Book 20", "Author 2", 69234, DateTime.Now, 15.0m, "Fiction", "English", "path2.jpg", 50, 0);

            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password", "CUSTOMER");
            var user = _userManager.GetUserByEmail("john.doe@example.com");

            var orderId = _order2Mock.AddOrder(user.Id, "123 Street", "Country", "City", "12345", 100.0m, 1);
            _orderItem2Mock.AddOrderItem(orderId, bookId, 1);
            _orderItem2Mock.AddOrderItem(orderId, book2Id, 1);

            // Act
            var recommendations = _recommendationSystem.GetFrequentlyBoughtBooks(bookId, 2);

            // Assert
            Assert.IsFalse(recommendations.Any(book => book.Id == bookId), "The target book should not be included in recommendations.");
        }

        [TestMethod]
        public void GetFrequentlyBoughtBooks_ShouldReturnEmptyListForNonExistentBook()
        {
            // Act
            var recommendations = _recommendationSystem.GetFrequentlyBoughtBooks(999, 2);

            // Assert
            Assert.AreEqual(0, recommendations.Count, "Should return an empty list for a non-existent book.");
        }

        [TestMethod]
        public void GetOrdersForSpecificBook_ShouldReturnValidOrders()
        {
            // Arrange
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password", "CUSTOMER");
            var user = _userManager.GetUserByEmail("john.doe@example.com");

            int userId = user.Id;
            int bookId = _bookMock.AddBook("Test Book", "Test Author", 12345, DateTime.Now, 10.0m, "Fiction", "English", "test.jpg", 50, 0);
            int orderId = _order2Mock.AddOrder(userId, "Address", "Country", "City", "12345", 50.0m, 1);
            _orderItem2Mock.AddOrderItem(orderId, bookId, 1);

            // Act
            var orders = _orderManager.GetOrdersForSpecificBook(bookId);

            // Assert
            Assert.AreEqual(1, orders.Count);
            Console.WriteLine($"Orders fetched: {orders.Count}");
        }
    }
}
