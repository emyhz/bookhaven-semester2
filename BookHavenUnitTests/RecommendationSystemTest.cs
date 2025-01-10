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
            // Initialize mocks
            _userMock = new UserMock();
            _userManager = new UserManager(_userMock);
            _bookMock = new BookMock();
            _bookManager = new BookManager(_bookMock);
            _orderItem2Mock = new OrderItem2Mock(_bookMock);
            _order2Mock = new Order2Mock(_orderItem2Mock);

            // Initialize managers
            _orderManager = new OrderManager(_order2Mock, _userManager, new OrderItemManager(_orderItem2Mock, _userManager, _bookManager));
            _recommendationSystem = new RecommendationSystem(_orderManager, _bookManager);

            // Add books to BookMock
            _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.0m, "Fiction", "English", "path1.jpg", 100, 0);
            _bookMock.AddBook("Book 2", "Author 2", 12346, DateTime.Now, 15.0m, "Fiction", "English", "path2.jpg", 50, 0);
            _bookMock.AddBook("Book 3", "Author 3", 12347, DateTime.Now, 20.0m, "Non-Fiction", "English", "path3.jpg", 30, 0);

            // Add user to UserMock
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password", "CUSTOMER");

            // Retrieve user ID (assuming GetUserByEmail is available)
            var user = _userManager.GetUserByEmail("john.doe@example.com");
            int userId = user.Id; // Retrieve userId from the added user

            // Add orders and order items
            int orderId1 = _order2Mock.AddOrder(userId, "123 Street", "Country", "City", "12345", 100.0m, 1);
            _orderItem2Mock.AddOrderItem(orderId1, 1, 2); // Order 1 includes 2 copies of Book 1
            _orderItem2Mock.AddOrderItem(orderId1, 2, 1); // Order 1 includes 1 copy of Book 2

            int orderId2 = _order2Mock.AddOrder(userId, "456 Avenue", "Country", "City", "67890", 50.0m, 1);
            _orderItem2Mock.AddOrderItem(orderId2, 2, 3); // Order 2 includes 3 copies of Book 2
            _orderItem2Mock.AddOrderItem(orderId2, 3, 1); // Order 2 includes 1 copy of Book 3
        }

        [TestMethod]
        public void GetFrequentlyBoughtBooks_ShouldReturnCorrectRecommendations()
        {
            // Act
            var recommendations = _recommendationSystem.GetFrequentlyBoughtBooks(1, 2);

            // Assert
            Assert.AreEqual(2, recommendations.Count, "Should return the top 2 recommended books.");
            Assert.AreEqual(2, recommendations[0].Id, "Book 2 should be the most frequently bought book.");
            Assert.AreEqual(3, recommendations[1].Id, "Book 3 should be the next frequently bought book.");
        }

        [TestMethod]
        public void GetFrequentlyBoughtBooks_ShouldExcludeTargetBook()
        {
            // Act
            var recommendations = _recommendationSystem.GetFrequentlyBoughtBooks(2, 2);

            // Assert
            Assert.IsFalse(recommendations.Any(book => book.Id == 2), "The target book should not be included in recommendations.");
        }

        [TestMethod]
        public void GetFrequentlyBoughtBooks_ShouldReturnEmptyListForNoData()
        {
            // Act
            var recommendations = _recommendationSystem.GetFrequentlyBoughtBooks(999, 2); // Book ID 999 doesn't exist

            // Assert
            Assert.AreEqual(0, recommendations.Count, "Should return an empty list for a non-existent book.");
        }

        [TestMethod]
        public void GetFrequentlyBoughtBooks_ShouldHandleRequestForMoreBooksThanAvailable()
        {
            // Act
            var recommendations = _recommendationSystem.GetFrequentlyBoughtBooks(1, 5); // Requesting more books than available

            // Assert
            Assert.AreEqual(2, recommendations.Count, "Should return all available recommendations, which is 2 in this case.");
        }

        [TestMethod]
        public void GetFrequentlyBoughtBooks_ShouldHandleNoOrdersForTargetBook()
        {
            // Act
            var recommendations = _recommendationSystem.GetFrequentlyBoughtBooks(3, 2); // No orders specifically for Book 3

            // Assert
            Assert.AreEqual(0, recommendations.Count, "Should return an empty list when there are no orders for the target book.");
        }







    }
}
