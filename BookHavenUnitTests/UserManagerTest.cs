using DataAccessLayer.MockDAL;
using LogicLayer.EntityClasses;
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

        [TestMethod]
        public void UpdatePassword_ShouldReturnMissingFields_WhenEmailIsEmpty()
        {
            // Act
            var result = _userManager.UpdatePassword("", "oldPass", "newPass", "newPass");

            // Assert
            Assert.AreEqual(UpdatePasswordResults.MISSING_FIELDS, result, "Result should indicate missing fields.");
        }

        [TestMethod]
        public void UpdatePassword_ShouldReturnInvalidOldPassword_WhenOldPasswordIsWrong()
        {
            // Arrange
            _userDbMock.AddUser("John", "Doe", "john.doe@example.com", BCrypt.Net.BCrypt.HashPassword("password123"), UserType.CUSTOMER.ToString());

            // Act
            var result = _userManager.UpdatePassword("john.doe@example.com", "wrongPassword", "newPass", "newPass");

            // Assert
            Assert.AreEqual(UpdatePasswordResults.INVALID_OLD_PASSWORD, result, "Result should indicate invalid old password.");
        }

        [TestMethod]
        public void UpdatePassword_ShouldReturnPasswordsDontMatch_WhenNewPasswordsMismatch()
        {
            // Arrange
            _userDbMock.AddUser("Jane", "Doe", "jane.doe@example.com", BCrypt.Net.BCrypt.HashPassword("password123"), UserType.CUSTOMER.ToString());

            // Act
            var result = _userManager.UpdatePassword("jane.doe@example.com", "password123", "newPass", "differentPass");

            // Assert
            Assert.AreEqual(UpdatePasswordResults.PASSWORDS_DONT_MATCH, result, "Result should indicate passwords don't match.");
        }

        [TestMethod]
        public void UpdatePassword_ShouldUpdatePassword_WhenAllFieldsValid()
        {
            // Arrange
            _userDbMock.AddUser("Jane", "Doe", "jane.doe@example.com", BCrypt.Net.BCrypt.HashPassword("password123"), UserType.CUSTOMER.ToString());

            // Act
            var result = _userManager.UpdatePassword("jane.doe@example.com", "password123", "newPass", "newPass");

            // Assert
            Assert.AreEqual(UpdatePasswordResults.PASSWORD_UPDATED, result, "Result should indicate password was updated.");
            var updatedUser = _userManager.GetUserByEmail("jane.doe@example.com");
            Assert.IsTrue(BCrypt.Net.BCrypt.Verify("newPass", updatedUser.Password), "Password should be updated in the database.");
        }

        [TestMethod]
        public void GetEmployees_ShouldReturnOnlyEmployees()
        {
            // Arrange
            _userDbMock.AddUser("John", "Doe", "john.doe@example.com", "password123", UserType.EMPLOYEE.ToString());
            _userDbMock.AddUser("Jane", "Smith", "jane.smith@example.com", "password123", UserType.CUSTOMER.ToString());

            // Act
            var employees = _userManager.GetEmployees();

            // Assert
            Assert.AreEqual(1, employees.Count, "Only one employee should be returned.");
            Assert.AreEqual("John", employees[0].FirstName, "Employee's first name should match.");
        }

        [TestMethod]
        public void GetPendingEmployees_ShouldReturnPendingEmployees()
        {
            // Arrange
            // Add users with various user types to the mock data access
            _userDbMock.AddUser("Alice", "Brown", "alice.brown@example.com", "password1", UserType.ADMIN.ToString());
            _userDbMock.AddUser("Bob", "Smith", "bob.smith@example.com", "password2", UserType.EMPLOYEE.ToString());
            _userDbMock.AddUser("Charlie", "Davis", "charlie.davis@example.com", "password3", UserType.PENDING_EMPLOYEE.ToString());
            _userDbMock.AddUser("Diana", "Taylor", "diana.taylor@example.com", "password4", UserType.PENDING_EMPLOYEE.ToString());

            // Act
            List<User> pendingEmployees = _userManager.GetPendingEmployees();

            // Assert
            Assert.IsNotNull(pendingEmployees, "Pending employees list should not be null.");
            Assert.AreEqual(2, pendingEmployees.Count, "There should be 2 pending employees.");
            Assert.AreEqual("Charlie", pendingEmployees[0].FirstName, "The first pending employee's first name should be Charlie.");
            Assert.AreEqual("Davis", pendingEmployees[0].LastName, "The first pending employee's last name should be Davis.");
            Assert.AreEqual("charlie.davis@example.com", pendingEmployees[0].Email, "The first pending employee's email should be correct.");
            Assert.AreEqual(UserType.PENDING_EMPLOYEE, pendingEmployees[0].UserType, "The first pending employee's UserType should be PENDING_EMPLOYEE.");

           
        }


    }
}