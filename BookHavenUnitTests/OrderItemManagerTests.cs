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
    public class OrderItemManagerTests
    {
        private OrderItemManager _orderItemManager;
        private OrderItemMock _orderItemMock;
        private BookMock _bookMock;
        private BookManager _bookManager;
        private UserManager _userManager;

        [TestInitialize]
        public void Setup()
        {
            // Initialize mocks and managers
            _orderItemMock = new OrderItemMock();
            _bookMock = new BookMock();
            _bookManager = new BookManager(_bookMock);
            _userManager = new UserManager(new UserMock());
            _orderItemManager = new OrderItemManager(_orderItemMock, _userManager, _bookManager);
        }

        [TestMethod]
        public void AddItemToCart_ShouldAddItemToUserCart()
        {
            // Arrange
            int userId = 1;
            int bookId = _bookMock.AddBook("Test Book", "Author", 12345, System.DateTime.Now, 10.0m, "Fiction", "English", "path/to/image", 10, 0);
            int quantity = 2;

            // Act
            _orderItemManager.AddItemToCart(userId, bookId, quantity);

            // Assert
            DataTable userCart = _orderItemMock.GetUserCart(userId);
            Assert.AreEqual(1, userCart.Rows.Count, "Item should be added to the user's cart.");
            Assert.AreEqual(quantity, userCart.Rows[0]["Quantity"], "Quantity should match.");
            Assert.AreEqual(bookId, userCart.Rows[0]["BookId"], "Book ID should match.");
        }

        [TestMethod]
        public void GetOrderItems_ShouldReturnItemsForOrder()
        {
            // Arrange
            int userId = 1;
            int bookId = _bookMock.AddBook("Test Book", "Author", 12345, System.DateTime.Now, 10.0m, "Fiction", "English", "path/to/image", 10, 0);
            _orderItemMock.AddItemToCart(userId, bookId, 1);
            _orderItemMock.Checkout(1, 1); // Move item to an order with ID 1

            // Act
            List<OrderItem> orderItems = _orderItemManager.GetOrderItems(1);

            // Assert
            Assert.AreEqual(1, orderItems.Count, "Order should contain one item.");
            Assert.AreEqual(bookId, orderItems[0].Book.Id, "Book ID should match.");
        }

        [TestMethod]
        public void GetUserCart_ShouldReturnItemsInCart()
        {
            // Arrange
            int userId = 1;
            int bookId1 = _bookMock.AddBook("Book 1", "Author 1", 12345, System.DateTime.Now, 10.0m, "Fiction", "English", "path/to/image1", 10, 0);
            int bookId2 = _bookMock.AddBook("Book 2", "Author 2", 67890, System.DateTime.Now, 20.0m, "Non-Fiction", "English", "path/to/image2", 5, 0);

            _orderItemMock.AddItemToCart(userId, bookId1, 1);
            _orderItemMock.AddItemToCart(userId, bookId2, 2);

            // Act
            List<OrderItem> userCart = _orderItemManager.GetUserCart(userId);

            // Assert
            Assert.AreEqual(2, userCart.Count, "Cart should contain two items.");
            Assert.AreEqual(bookId1, userCart[0].Book.Id, "First book ID should match.");
            Assert.AreEqual(bookId2, userCart[1].Book.Id, "Second book ID should match.");
        }

        [TestMethod]
        public void IncreaseQuantity_ShouldIncrementItemQuantity()
        {
            // Arrange
            int userId = 1;
            int bookId = _bookMock.AddBook("Test Book", "Author", 12345, System.DateTime.Now, 10.0m, "Fiction", "English", "path/to/image", 10, 0);
            _orderItemMock.AddItemToCart(userId, bookId, 1);
            DataTable userCart = _orderItemMock.GetUserCart(userId);
            int orderItemId = (int)userCart.Rows[0]["Id"];

            // Act
            _orderItemManager.IncreaseQuantity(orderItemId);

            // Assert
            userCart = _orderItemMock.GetUserCart(userId);
            Assert.AreEqual(2, userCart.Rows[0]["Quantity"], "Quantity should be incremented.");
        }

        [TestMethod]
        public void DecreaseQuantity_ShouldDecrementItemQuantity()
        {
            // Arrange
            int userId = 1;
            int bookId = _bookMock.AddBook("Test Book", "Author", 12345, System.DateTime.Now, 10.0m, "Fiction", "English", "path/to/image", 10, 0);
            _orderItemMock.AddItemToCart(userId, bookId, 2);
            DataTable userCart = _orderItemMock.GetUserCart(userId);
            int orderItemId = (int)userCart.Rows[0]["Id"];

            // Act
            _orderItemManager.DecreaseQuantity(orderItemId);

            // Assert
            userCart = _orderItemMock.GetUserCart(userId);
            Assert.AreEqual(1, userCart.Rows[0]["Quantity"], "Quantity should be decremented.");
        }

        [TestMethod]
        public void Checkout_ShouldMoveItemToOrder()
        {
            // Arrange
            int userId = 1;
            int bookId = _bookMock.AddBook("Test Book", "Author", 12345, System.DateTime.Now, 10.0m, "Fiction", "English", "path/to/image", 10, 0);
            _orderItemMock.AddItemToCart(userId, bookId, 1);
            DataTable userCart = _orderItemMock.GetUserCart(userId);
            int orderItemId = (int)userCart.Rows[0]["Id"];

            // Act
            _orderItemManager.Checkout(1, orderItemId);

            // Assert
            DataTable orderItems = _orderItemMock.GetOrderItems(1);
            Assert.AreEqual(1, orderItems.Rows.Count, "Order should contain the checked-out item.");
            Assert.AreEqual(bookId, orderItems.Rows[0]["BookId"], "Book ID should match.");
        }

        [TestMethod]
        public void RemoveAudioItemFromCart_ShouldRemoveItem()
        {
            // Arrange
            int userId = 1;
            int bookId = _bookMock.AddBook("Test Audio Book", "Author", 12345, System.DateTime.Now, 10.0m, "Audio", "English", "path/to/audio", 10, 0);
            _orderItemMock.AddItemToCart(userId, bookId, 1);
            DataTable userCart = _orderItemMock.GetUserCart(userId);
            int orderItemId = (int)userCart.Rows[0]["Id"];

            // Act
            _orderItemManager.RemoveAudioItemFromCart(orderItemId);

            // Assert
            userCart = _orderItemMock.GetUserCart(userId);
            Assert.AreEqual(0, userCart.Rows.Count, "Cart should be empty after removing the item.");
        }

        [TestMethod]
        public void GetItemQuantityFromUser_ShouldReturnCorrectQuantity()
        {
            // Arrange
            int userId = 1;
            int bookId = _bookMock.AddBook("Test Book", "Author", 12345, System.DateTime.Now, 10.0m, "Fiction", "English", "path/to/image", 10, 0);
            _orderItemMock.AddItemToCart(userId, bookId, 3);

            // Act
            int quantity = _orderItemManager.GetItemQuantityFromUser(userId);

            // Assert
            Assert.AreEqual(3, quantity, "Total quantity should match the number of items in the cart.");
        }
    }
}
