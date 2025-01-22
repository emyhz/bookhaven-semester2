using DataAccessLayer.MockDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenUnitTests
{
    [TestClass]
    public class Order2Tests
    {
        private Order2Mock _order2Mock;

        private OrderItem2Mock _orderItem2Mock;
        private BookMock _bookMock;

        [TestInitialize]
        public void Setup()
        {
            _bookMock = new BookMock();

            _orderItem2Mock = new OrderItem2Mock(_bookMock);

            _order2Mock = new Order2Mock(_orderItem2Mock);
        }

        [TestMethod]
        public void AddOrder_ShouldAddOrderToMock()
        {
            // Arrange
            int userId = 1;
            string address = "123 Street";
            string country = "Country";
            string city = "City";
            string zipCode = "12345";
            decimal totalPrice = 100.0m;

            // Act
            int orderId = _order2Mock.AddOrder(userId, address, country, city, zipCode, totalPrice, 1);

            // Assert
            DataTable orders = _order2Mock.GetOrders();
            Assert.AreEqual(1, orders.Rows.Count, "One order should be added.");
            Assert.AreEqual(orderId, orders.Rows[0]["Id"], "Order ID should match.");
        }

        [TestMethod]
        public void GetUserOrders_ShouldReturnOrdersForSpecificUser()
        {
            // Arrange
            _order2Mock.AddOrder(1, "123 Street", "Country", "City", "12345", 50.0m, 0);
            _order2Mock.AddOrder(2, "456 Avenue", "Country", "City", "67890", 75.0m, 1);

            // Act
            DataTable userOrders = _order2Mock.GetUserOrders(1);

            // Assert
            Assert.AreEqual(1, userOrders.Rows.Count, "User should have one order.");
            Assert.AreEqual("123 Street", userOrders.Rows[0]["Address"], "Address should match.");
        }

        [TestMethod]
        public void UpdateOrderStatus_ShouldUpdateOrderStatus()
        {
            // Arrange
            int orderId = _order2Mock.AddOrder(1, "123 Street", "Country", "City", "12345", 50.0m, 0);

            // Act
            _order2Mock.UpdateOrderStatus(orderId, 1);

            // Assert
            DataTable orders = _order2Mock.GetOrders();
            Assert.AreEqual(1, orders.Rows[0]["Status"], "Order status should be updated.");
        }

        [TestMethod]
        public void GetLastUsedAddress_ShouldReturnCorrectAddress()
        {
            // Arrange
            _order2Mock.AddOrder(1, "123 Street", "Country", "City", "12345", 50.0m, 0);

            // Act
            DataTable address = _order2Mock.GetLastUsedAddress(1);

            // Assert
            Assert.AreEqual("123 Street", address.Rows[0]["Address"], "Address should match.");
        }

        [TestMethod]
        public void GetStatisticOrders_ShouldReturnOrdersAfterSpecifiedDate()
        {
            // Arrange
            _order2Mock.AddOrder(1, "123 Street", "Country", "City", "12345", 50.0m, 0);
            _order2Mock.AddOrder(1, "456 Avenue", "Country", "City", "67890", 75.0m, 0);

            // Act
            DataTable orders = _order2Mock.GetStatisticOrders(DateTime.Now.AddDays(-1));

            // Assert
            Assert.AreEqual(2, orders.Rows.Count, "All orders within the last day should be returned.");
        }

        [TestMethod]
        public void GetOrdersForBook_ShouldReturnCorrectOrders()
        {
            // Arrange
            var bookId1 = _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.0m, "Fiction", "English", "path/to/image1.jpg", 100, 0); // Add Book 1 to the mock
            var bookId2 = _bookMock.AddBook("Book 2", "Author 2", 12346, DateTime.Now, 15.0m, "Non-Fiction", "English", "path/to/image2.jpg", 50, 0); // Add Book 2 to the mock
            var userId = 1;
            var orderId1 = _order2Mock.AddOrder(userId, "Address 1", "Country 1", "City 1", "12345", 50.0m, 1);
            var orderId2 = _order2Mock.AddOrder(userId, "Address 2", "Country 2", "City 2", "67890", 75.0m, 1);

            // Add order items for the books
            _orderItem2Mock.AddOrderItem(orderId1, bookId1, 1); // Book 1 in Order 1
            _orderItem2Mock.AddOrderItem(orderId2, bookId2, 1); // Book 2 in Order 2 (should not match)

            // Act
            var ordersForBook = _order2Mock.GetOrdersForBook(bookId1);

            // Assert
            Assert.AreEqual(1, ordersForBook.Rows.Count, "Only one order should contain the specified book.");
            Assert.AreEqual(orderId1, ordersForBook.Rows[0]["Id"], "The order ID should match.");
        }

        [TestMethod]
        public void GetOrdersForSpecificBook_ShouldReturnMatchingOrders()
        {
            // Arrange: Add books to the mock
            int bookId1 = _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.0m, "Fiction", "English", "path/to/image1.jpg", 100, 0);
            int bookId2 = _bookMock.AddBook("Book 2", "Author 2", 12346, DateTime.Now, 15.0m, "Non-Fiction", "English", "path/to/image2.jpg", 50, 0);

            // Add a user
            int userId = 1;

            // Add orders
            int orderId1 = _order2Mock.AddOrder(userId, "Address 1", "Country 1", "City 1", "12345", 50.0m, 1);
            int orderId2 = _order2Mock.AddOrder(userId, "Address 2", "Country 2", "City 2", "67890", 75.0m, 1);

            // Add order items referencing books
            _orderItem2Mock.AddOrderItem(orderId1, bookId1, 2); // Book 1 in Order 1
            _orderItem2Mock.AddOrderItem(orderId2, bookId2, 1); // Book 2 in Order 2

            // Act: Call the method being tested
            var matchingOrders = _order2Mock.GetOrdersForSpecificBook(bookId1);

            // Assert: Validate the result
            Assert.AreEqual(1, matchingOrders.Count, "Should return only one order containing the specified book.");
            Assert.AreEqual(orderId1, matchingOrders[0].OrderId, "Order ID should match the order containing the specified book.");
            Assert.AreEqual(userId, matchingOrders[0].UserId, "User ID should match the user who placed the order.");
            Assert.AreEqual("Address 1", matchingOrders[0].Address, "Address should match the order details.");
        }




    }
}
