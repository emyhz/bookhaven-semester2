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
    public class ReviewManagerTests
    {
        private ReviewManager _reviewManager;
        private ReviewMock _reviewMock;
        private UserMock _userMock;
        private BookMock _bookMock;
        private UserManager _userManager;
        private BookManager _bookManager;

        [TestInitialize]
        public void Setup()
        {
            _reviewMock = new ReviewMock();
            _userMock = new UserMock();
            _bookMock = new BookMock();
            _userManager = new UserManager(_userMock);
            _bookManager = new BookManager(_bookMock);
            _reviewManager = new ReviewManager(_reviewMock, _userManager, _bookManager);
        }

        [TestMethod]
        public void AddReview_ShouldAddReviewToMockDb()
        {
            // Arrange
            int userId = 1;
            int bookId = _bookMock.AddBook("Test Book", "Author", 12345, DateTime.Now, 10.0m, "Fiction", "English", "path/to/image", 10, 0);
            _userMock.AddUser("John", "Doe", "john.doe@example.com", "password", UserType.CUSTOMER.ToString());

            // Act
            _reviewManager.AddReview(userId, bookId, 5, "Great Book!", "Loved it");

            // Assert
            DataTable reviews = _reviewMock.GetReviewsForBook(bookId);
            Assert.AreEqual(1, reviews.Rows.Count, "Review should be added.");
            Assert.AreEqual(5, reviews.Rows[0]["Rating"], "Rating should match.");
            Assert.AreEqual("Great Book!", reviews.Rows[0]["Title"], "Title should match.");
        }

        [TestMethod]
        public void GetReviewsForBook_ShouldReturnReviewsForSpecificBook()
        {
            // Arrange
            int bookId1 = _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.0m, "Fiction", "English", "path/to/image1", 10, 0);
            int bookId2 = _bookMock.AddBook("Book 2", "Author 2", 67890, DateTime.Now, 20.0m, "Non-Fiction", "English", "path/to/image2", 5, 0);

            _reviewMock.AddReview(1, bookId1, 5, "Amazing!", "Highly recommend");
            _reviewMock.AddReview(2, bookId2, 4, "Good", "Enjoyable");

            // Act
            List<Review> reviewsForBook1 = _reviewManager.GetReviewsForBook(bookId1);

            // Assert
            Assert.AreEqual(1, reviewsForBook1.Count, "Should return one review for Book 1.");
            Assert.AreEqual("Amazing!", reviewsForBook1[0].Title, "Title should match.");
        }

        [TestMethod]
        public void GetReviewsByUser_ShouldReturnReviewsBySpecificUser()
        {
            // Arrange
            int bookId1 = _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.0m, "Fiction", "English", "path/to/image1", 10, 0);
            int bookId2 = _bookMock.AddBook("Book 2", "Author 2", 67890, DateTime.Now, 20.0m, "Non-Fiction", "English", "path/to/image2", 5, 0);

            _reviewMock.AddReview(1, bookId1, 5, "Excellent!", "Loved every part");
            _reviewMock.AddReview(1, bookId2, 3, "Average", "It was okay");

            // Act
            List<Review> userReviews = _reviewManager.GetReviewsByUser(1);

            // Assert
            Assert.AreEqual(2, userReviews.Count, "Should return two reviews for the user.");
            Assert.AreEqual("Excellent!", userReviews[0].Title, "Title of first review should match.");
        }

        [TestMethod]
        public void GetReviewDetails_ShouldReturnCorrectReview()
        {
            // Arrange
            int bookId = _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.0m, "Fiction", "English", "path/to/image1", 10, 0);
            _reviewMock.AddReview(1, bookId, 4, "Good Book", "Liked the story");
            int reviewId = 1;

            // Act
            Review review = _reviewManager.GetReviewDetails(reviewId);

            // Assert
            Assert.IsNotNull(review, "Review should not be null.");
            Assert.AreEqual(4, review.Rating, "Rating should match.");
            Assert.AreEqual("Good Book", review.Title, "Title should match.");
        }

        [TestMethod]
        public void UpdateReview_ShouldModifyReviewDetails()
        {
            // Arrange
            int bookId = _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.0m, "Fiction", "English", "path/to/image1", 10, 0);
            _reviewMock.AddReview(1, bookId, 3, "Okay Book", "Decent read");

            // Act
            _reviewManager.UpdateReview(1, 5, "Fantastic Book", "Highly recommend");

            // Assert
            DataTable reviews = _reviewMock.GetReviewsForBook(bookId);
            Assert.AreEqual(1, reviews.Rows.Count, "Review should still exist.");
            Assert.AreEqual(5, reviews.Rows[0]["Rating"], "Rating should be updated.");
            Assert.AreEqual("Fantastic Book", reviews.Rows[0]["Title"], "Title should be updated.");
        }

        [TestMethod]
        public void DeleteReview_ShouldRemoveReview()
        {
            // Arrange
            int bookId = _bookMock.AddBook("Book 1", "Author 1", 12345, DateTime.Now, 10.0m, "Fiction", "English", "path/to/image1", 10, 0);
            _reviewMock.AddReview(1, bookId, 4, "Good Book", "Liked the story");

            // Act
            _reviewManager.DeleteReview(1);

            // Assert
            DataTable reviews = _reviewMock.GetReviewsForBook(bookId);
            Assert.AreEqual(0, reviews.Rows.Count, "Review should be deleted.");
        }

    }
}
