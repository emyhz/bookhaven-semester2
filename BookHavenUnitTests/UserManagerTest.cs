using DataAccessLayer.MockDAL;
using LogicLayer.Enums;
using LogicLayer.Managers;

namespace BookHavenUnitTests
{
    [TestClass]
    public class UserManagerTest
    {
        private UserManager _userManager;
        private UserMock _userDbMock;

        // Setup method to initialize the UserManager with the mock data access
        [TestInitialize]
        public void Setup()
        {
            _userDbMock = new UserMock();
            _userManager = new UserManager(_userDbMock); // Inject mock into UserManager
        }

        // Example test case: Adding a user
        [TestMethod]
        public void AddUser_ShouldAddUserToMockDb()
        {
            // Act
            _userManager.AddUser("John", "Doe", "john.doe@example.com", "password123", UserType.CUSTOMER);

            // Assert
            Assert.IsTrue(_userDbMock.EmailExists("john.doe@example.com"), "The user should be added to the mock database.");
        }

        // Example test case: Retrieving a user by email
        [TestMethod]
        public void GetUserByEmail_ShouldReturnCorrectUser()
        {
            // Arrange
            _userDbMock.AddUser("John", "Doe", "john.doe@example.com", "password123", UserType.CUSTOMER.ToString());

            // Act
            var user = _userManager.GetUserByEmail("john.doe@example.com");

            // Assert
            Assert.IsNotNull(user, "User should not be null.");
            Assert.AreEqual("John", user.FirstName, "First name should be John.");
            Assert.AreEqual("Doe", user.LastName, "Last name should be Doe.");
            Assert.AreEqual(UserType.CUSTOMER, user.UserType, "User type should be CUSTOMER.");
        }

        // Example test case: Deleting a user
        [TestMethod]
        public void DeleteUser_ShouldRemoveUserFromMockDb()
        {
            // Arrange
            _userDbMock.AddUser("Jane", "Smith", "jane.smith@example.com", "password123", UserType.EMPLOYEE.ToString());

            // Act
            _userManager.DeleteEmployee("jane.smith@example.com");

            // Assert
            Assert.IsFalse(_userDbMock.EmailExists("jane.smith@example.com"), "The user should be removed from the mock database.");
        }

        // Example test case: Updating a user's type
        [TestMethod]
        public void UpdateUserType_ShouldChangeUserTypeInMockDb()
        {
            // Arrange
            _userDbMock.AddUser("Sam", "Adams", "sam.adams@example.com", "password123", UserType.PENDING_EMPLOYEE.ToString());

            // Act
            _userManager.UpdateToEmployee(1, "admin@example.com"); // Assuming 1 is the ID and admin has rights to update

            // Assert
            var user = _userManager.GetUserByEmail("sam.adams@example.com");
            Assert.IsNotNull(user, "User should not be null.");
            Assert.AreEqual(UserType.EMPLOYEE, user.UserType, "User type should be updated to EMPLOYEE.");
        }

        // Example test case: Authenticating a user
        [TestMethod]
        public void AuthenticateUser_ShouldReturnTrueForCorrectCredentials()
        {
            // Arrange
            string email = "jane.doe@example.com";
            string password = "password123";
            _userDbMock.AddUser("Jane", "Doe", email, BCrypt.Net.BCrypt.HashPassword(password), UserType.CUSTOMER.ToString());

            // Act
            bool isAuthenticated = _userManager.AuthenticateUser(email, password);

            // Assert
            Assert.IsTrue(isAuthenticated, "Authentication should succeed for correct credentials.");
        }

        // Example test case: Authenticating a user with wrong password
        [TestMethod]
        public void AuthenticateUser_ShouldReturnFalseForIncorrectCredentials()
        {
            // Arrange
            string email = "jane.doe@example.com";
            string password = "password123";
            _userDbMock.AddUser("Jane", "Doe", email, BCrypt.Net.BCrypt.HashPassword(password), UserType.CUSTOMER.ToString());

            // Act
            bool isAuthenticated = _userManager.AuthenticateUser(email, "wrongpassword");

            // Assert
            Assert.IsFalse(isAuthenticated, "Authentication should fail for incorrect credentials.");
        }
    }
}