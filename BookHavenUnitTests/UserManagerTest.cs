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
            _userManager.DeleteUser("jane.smith@example.com");

            // Assert
            Assert.IsFalse(_userDbMock.EmailExists("jane.smith@example.com"), "The user should be removed from the mock database.");
        }

        
        [TestMethod]
        public void UpdateUserType_ShouldChangeUserTypeToEmployee_WhenLoggedInUserIsAdmin()
        {
            // Arrange
            // Add a PENDING_EMPLOYEE user
            _userDbMock.AddUser("Sam", "Adams", "sam.adams@example.com", "password123", UserType.PENDING_EMPLOYEE.ToString());

            // Add an ADMIN user to act as the logged-in user
            _userDbMock.AddUser("Admin", "User", "admin@example.com", "adminpassword", UserType.ADMIN.ToString());

            // Act
            _userManager.UpdateToEmployee(1, "admin@example.com");

            // Assert
            var updatedUser = _userManager.GetUserByEmail("sam.adams@example.com");
            Assert.IsNotNull(updatedUser, "User should not be null.");
            Assert.AreEqual(UserType.EMPLOYEE, updatedUser.UserType, "User type should be updated to EMPLOYEE.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "You do not have permission to do this")]
        public void UpdateUserType_ShouldThrowException_WhenLoggedInUserIsNotAdmin()
        {
            // Arrange
            // Add a PENDING_EMPLOYEE user
            _userDbMock.AddUser("Sam", "Adams", "sam.adams@example.com", "password123", UserType.PENDING_EMPLOYEE.ToString());

            // Add a non-ADMIN user to act as the logged-in user
            _userDbMock.AddUser("John", "Doe", "john.doe@example.com", "userpassword", UserType.EMPLOYEE.ToString());

            // Act
            _userManager.UpdateToEmployee(1, "john.doe@example.com");

            // Assert handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "User not found")]
        public void UpdateUserType_ShouldThrowException_WhenUserToBeUpdatedDoesNotExist()
        {
            // Arrange
            // Add an ADMIN user to act as the logged-in user
            _userDbMock.AddUser("Admin", "User", "admin@example.com", "adminpassword", UserType.ADMIN.ToString());

            // Act
            _userManager.UpdateToEmployee(99, "admin@example.com"); // Non-existent user ID

            // Assert handled by ExpectedException
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