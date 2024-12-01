using DataAccessLayer.Interfaces;
using LogicLayer.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Managers
{
    public class ReviewManager
    {
        private readonly IReviewDb _reviewDb;
        private readonly UserManager _userManager;
        private readonly BookManager _bookManager;

        public ReviewManager(IReviewDb reviewDb, UserManager userManager, BookManager bookManager)
        {
            _reviewDb = reviewDb;
            _userManager = userManager;
            _bookManager = bookManager;
        }

        public void AddReview(int userId, int bookId, int rating, string? title, string? comment)
        {
            _reviewDb.AddReview(userId, bookId, rating, title, comment);
        }

        public List<Review> GetReviewsForBook(int bookId)
        {
            DataTable dt = _reviewDb.GetReviewsForBook(bookId);
            List<Review> reviews = new List<Review>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int reviewId = Convert.ToInt32(row["Id"]);
                    int userId = Convert.ToInt32(row["UserId"]);
                    User user = _userManager.GetUserById(userId);
                    Book book = _bookManager.GetBookById(bookId);

                    Review review = new Review(
                        reviewId,
                        user,
                        book,
                        Convert.ToInt32(row["Rating"]),
                        row["Title"] as string,
                        row["Comment"] as string
                    );

                    reviews.Add(review);
                }
            }

            return reviews;
        }

        public List<Review> GetReviewsByUser(int userId)
        {
            DataTable dt = _reviewDb.GetReviewsByUser(userId);
            List<Review> reviews = new List<Review>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int reviewId = Convert.ToInt32(row["Id"]);
                    int bookId = Convert.ToInt32(row["BookId"]);
                    User user = _userManager.GetUserById(userId);
                    Book book = _bookManager.GetBookById(bookId);

                    Review review = new Review(
                        reviewId,
                        user,
                        book,
                        Convert.ToInt32(row["Rating"]),
                        row["Title"] as string,
                        row["Comment"] as string
                    );

                    reviews.Add(review);
                }
            }

            return reviews;
        }

        public Review GetReviewDetails(int reviewId)
        {
            DataTable dt = _reviewDb.GetReviewDetails(reviewId);

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = dt.Rows[0];
            int userId = Convert.ToInt32(row["UserId"]);
            int bookId = Convert.ToInt32(row["BookId"]);

            User user = _userManager.GetUserById(userId);
            Book book = _bookManager.GetBookById(bookId);

            Review review = new Review(
                reviewId,
                user,
                book,
                Convert.ToInt32(row["Rating"]),
                row["Title"] as string,
                row["Comment"] as string
            );

            return review;
        }

        public void UpdateReview(int id, int rating, string? title, string? comment)
        {
            _reviewDb.UpdateReview(id, rating, title, comment);
        }

        public void DeleteReview(int id)
        {
            _reviewDb.DeleteReview(id);
        }

    }
}
