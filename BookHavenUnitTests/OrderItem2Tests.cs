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
    public class OrderItem2Tests
    {
        private OrderItem2Mock _orderItem2Mock;
        private BookMock _bookMock;

        [TestInitialize]
        public void Setup()
        {
            _bookMock = new BookMock();
            _orderItem2Mock = new OrderItem2Mock(_bookMock);

            // Add sample books to the BookMock
            _bookMock.AddBook("Sample Book 1", "Author 1", 12345, DateTime.Now, 10.0m, "Fiction", "English", "image1.jpg", 10, 0);
            _bookMock.AddBook("Sample Book 2", "Author 2", 67890, DateTime.Now, 15.0m, "Non-Fiction", "English", "image2.jpg", 5, 0);
        }

        [TestMethod]
        public void AddItemToCart_ShouldAddNewItemToCart()
        {
            // Arrange
            int userId = 1;
            int bookId = 1;

            // Act
            _orderItem2Mock.AddItemToCart(userId, bookId, 2);

            // Assert
            DataTable cart = _orderItem2Mock.GetUserCart(userId);
            Assert.AreEqual(1, cart.Rows.Count, "Cart should contain one item.");
            Assert.AreEqual(2, cart.Rows[0]["Quantity"], "Quantity should match.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddItemToCart_ShouldThrowExceptionForInvalidBookId()
        {
            // Arrange
            int userId = 1;
            int invalidBookId = 999;

            // Act
            _orderItem2Mock.AddItemToCart(userId, invalidBookId, 1);
        }

        [TestMethod]
        public void GetUserCart_ShouldReturnCorrectItems()
        {
            // Arrange
            int userId = 1;
            _orderItem2Mock.AddItemToCart(userId, 1, 2);
            _orderItem2Mock.AddItemToCart(userId, 2, 3);

            // Act
            DataTable cart = _orderItem2Mock.GetUserCart(userId);

            // Assert
            Assert.AreEqual(2, cart.Rows.Count, "Cart should contain two items.");
            Assert.AreEqual(2, cart.Rows[0]["Quantity"], "First item's quantity should match.");
            Assert.AreEqual(3, cart.Rows[1]["Quantity"], "Second item's quantity should match.");
        }

        [TestMethod]
        public void IncreaseQuantity_ShouldIncrementItemQuantity()
        {
            // Arrange
            int userId = 1;
            _orderItem2Mock.AddItemToCart(userId, 1, 1);
            DataTable cart = _orderItem2Mock.GetUserCart(userId);
            int orderItemId = (int)cart.Rows[0]["Id"];

            // Act
            _orderItem2Mock.IncreaseQuantity(orderItemId);

            // Assert
            cart = _orderItem2Mock.GetUserCart(userId);
            Assert.AreEqual(2, cart.Rows[0]["Quantity"], "Quantity should be incremented.");
        }

        [TestMethod]
        public void DecreaseQuantity_ShouldDecrementItemQuantity()
        {
            // Arrange
            int userId = 1;
            _orderItem2Mock.AddItemToCart(userId, 1, 2);
            DataTable cart = _orderItem2Mock.GetUserCart(userId);
            int orderItemId = (int)cart.Rows[0]["Id"];

            // Act
            _orderItem2Mock.DecreaseQuantity(orderItemId);

            // Assert
            cart = _orderItem2Mock.GetUserCart(userId);
            Assert.AreEqual(1, cart.Rows[0]["Quantity"], "Quantity should be decremented.");
        }

        [TestMethod]
        public void Checkout_ShouldMoveItemToOrder()
        {
            // Arrange
            int userId = 1;
            _orderItem2Mock.AddItemToCart(userId, 1, 1);
            DataTable cart = _orderItem2Mock.GetUserCart(userId);
            int orderItemId = (int)cart.Rows[0]["Id"];

            // Act
            _orderItem2Mock.Checkout(orderItemId, 1001);

            // Assert
            cart = _orderItem2Mock.GetUserCart(userId);
            Assert.AreEqual(0, cart.Rows.Count, "Cart should be empty after checkout.");
            DataTable orderItems = _orderItem2Mock.GetOrderItems(1001);
            Assert.AreEqual(1, orderItems.Rows.Count, "Order should contain the checked-out item.");
        }

        [TestMethod]
        public void RemoveAudioOrderItem_ShouldRemoveItem()
        {
            // Arrange
            int userId = 1;
            _orderItem2Mock.AddItemToCart(userId, 1, 1);
            DataTable cart = _orderItem2Mock.GetUserCart(userId);
            int orderItemId = (int)cart.Rows[0]["Id"];

            // Act
            _orderItem2Mock.RemoveAudioOrderItem(orderItemId);

            // Assert
            cart = _orderItem2Mock.GetUserCart(userId);
            Assert.AreEqual(0, cart.Rows.Count, "Cart should be empty after removing the item.");
        }
    }
}
