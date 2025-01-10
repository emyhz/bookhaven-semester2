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
    }
}
