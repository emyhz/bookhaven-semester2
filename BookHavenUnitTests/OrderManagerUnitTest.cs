using DataAccessLayer.MockDAL;
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
    public class OrderManagerUnitTest
    {
        private OrderManager _orderManager;
        private OrderMock _orderMock;
        private UserMock _userMock;
        private UserManager _userManager;
        private OrderItemMock _orderItemMock;
        private OrderItemManager _orderItemManager;
        private BookMock _bookMock;
        private BookManager _bookManager;

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
        }

        [TestMethod]
        public void AddOrder_ShouldAddOrderToMockDb()
        {
            // Arrange
            int userId = 1;
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password123", "CUSTOMER");

            // Act
            int orderId = _orderManager.AddOrder(userId, "123 Street", "Country", "City", "12345", 99.99m);

            // Assert
            DataTable orders = _orderMock.GetOrders();
            Assert.AreEqual(1, orders.Rows.Count, "One order should be added.");
            Assert.AreEqual(orderId, (int)orders.Rows[0]["Id"], "Order ID should match.");
            Assert.AreEqual(userId, (int)orders.Rows[0]["UserId"], "User ID should match.");
        }

        [TestMethod]
        public void GetOrdersSummary_ShouldReturnAllOrders()
        {
            // Arrange
            int userId = 1;
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password123", "CUSTOMER");
            _orderMock.AddOrder(userId, "123 Street", "Country", "City", "12345", 50.00m, 0);
            _orderMock.AddOrder(userId, "456 Avenue", "Country", "City", "67890", 75.00m, 1);

            // Act
            List<Order> orders = _orderManager.GetOrdersSummary();

            // Assert
            Assert.AreEqual(2, orders.Count, "There should be two orders in the summary.");
            Assert.AreEqual(50.00m, orders[0].TotalPrice, "First order's total price should match.");
            Assert.AreEqual(75.00m, orders[1].TotalPrice, "Second order's total price should match.");
        }

        [TestMethod]
        public void GetUserOrders_ShouldReturnOrdersForSpecificUser()
        {
            // Arrange
            int userId1 = 1;
            int userId2 = 2;
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password123", "CUSTOMER");
            _userMock.AddUser("Jane", "Smith", "jane.smith@example.com", "password123", "CUSTOMER");
            _orderMock.AddOrder(userId1, "123 Street", "Country", "City", "12345", 50.00m, 0);
            _orderMock.AddOrder(userId2, "456 Avenue", "Country", "City", "67890", 75.00m, 1);

            // Act
            List<Order> user1Orders = _orderManager.GetUserOrders(userId1);
            List<Order> user2Orders = _orderManager.GetUserOrders(userId2);

            // Assert
            Assert.AreEqual(1, user1Orders.Count, "User 1 should have one order.");
            Assert.AreEqual(1, user2Orders.Count, "User 2 should have one order.");
        }

        [TestMethod]
        public void GetOrdersForSpecificBook_ShouldReturnOrdersContainingBook()
        {
            // Arrange
            int userId = 1;
            int bookId = _bookMock.AddBook("Book 1", "Author", 12345, DateTime.Now, 10.00m, "Fiction", "English", "path", 10, 0);
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password123", "CUSTOMER");
            int orderId = _orderMock.AddOrder(userId, "123 Street", "Country", "City", "12345", 50.00m, 0);
            _orderItemMock.AddItemToCart(userId, bookId, 1);
            _orderItemMock.Checkout(orderId, 1);

            // Act
            List<Order> orders = _orderManager.GetOrdersForSpecificBook(bookId);

            // Assert
            Assert.AreEqual(1, orders.Count, "There should be one order containing the book.");
            Assert.AreEqual(orderId, orders[0].Id, "Order ID should match.");
        }

        [TestMethod]
        public void GetOrderDetailsForUser_ShouldReturnOrderDetails()
        {
            // Arrange
            int userId = 1;
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password123", "CUSTOMER");
            int orderId = _orderMock.AddOrder(userId, "123 Street", "Country", "City", "12345", 50.00m, 0);

            // Act
            Order order = _orderManager.GetOrderDetailsForUser(orderId);

            // Assert
            Assert.IsNotNull(order, "Order should not be null.");
            Assert.AreEqual(orderId, order.Id, "Order ID should match.");
            Assert.AreEqual(userId, order.User.Id, "User ID should match.");
        }

        [TestMethod]
        public void UpdateOrderStatus_ShouldUpdateOrderStatus()
        {
            // Arrange
            int userId = 1;
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password123", "CUSTOMER");
            int orderId = _orderMock.AddOrder(userId, "123 Street", "Country", "City", "12345", 50.00m, 0);

            // Act
            _orderManager.UpdateOrderStatus(orderId, OrderStatus.SHIPPED);

            // Assert
            DataTable orders = _orderMock.GetOrders();
            Assert.AreEqual((int)OrderStatus.SHIPPED, (int)orders.Rows[0]["Status"], "Order status should be updated to SHIPPED.");
        }

        [TestMethod]
        public void GetLastUsedAddress_ShouldReturnCorrectAddress()
        {
            // Arrange
            int userId = 1;
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password123", "CUSTOMER");
            _orderMock.AddOrder(userId, "123 Street", "Country", "City", "12345", 50.00m, 0);

            // Act
            Order lastOrder = _orderManager.GetLastUsedAddress(userId);

            // Assert
            Assert.IsNotNull(lastOrder, "Last order should not be null.");
            Assert.AreEqual("123 Street", lastOrder.Address, "Address should match.");
        }
    }
}
