using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MockDAL
{
    public class ReviewMock : IReviewDb
    {
        private List<(int Id, int UserId, int BookId, int Rating, string? Title, string? Comment)> _reviews = new List<(int, int, int, int, string?, string?)>();
        private int _nextId = 1;

        public void AddReview(int userId, int bookId, int rating, string? title, string? comment)
        {
            int newId = _nextId++;
            _reviews.Add((newId, userId, bookId, rating, title, comment));
        }

        public DataTable GetReviewsForBook(int bookId)
        {
            var reviewsForBook = _reviews.Where(r => r.BookId == bookId).ToList();
            return CreateDataTable(reviewsForBook);
        }

        public DataTable GetReviewsByUser(int userId)
        {
            var reviewsByUser = _reviews.Where(r => r.UserId == userId).ToList();
            return CreateDataTable(reviewsByUser);
        }

        public DataTable GetReviewDetails(int reviewId)
        {
            var review = _reviews.FirstOrDefault(r => r.Id == reviewId);
            if (review.Equals(default((int, int, int, int, string?, string?))))
            {
                return new DataTable();
            }

            return CreateDataTable(new List<(int, int, int, int, string?, string?)> { review });
        }

        public void UpdateReview(int id, int rating, string? title, string? comment)
        {
            int index = _reviews.FindIndex(r => r.Id == id);
            if (index >= 0)
            {
                _reviews[index] = (id, _reviews[index].UserId, _reviews[index].BookId, rating, title, comment);
            }
        }

        public void DeleteReview(int id)
        {
            int index = _reviews.FindIndex(r => r.Id == id);
            if (index >= 0)
            {
                _reviews.RemoveAt(index);
            }
        }

        private DataTable CreateDataTable(List<(int Id, int UserId, int BookId, int Rating, string? Title, string? Comment)> reviews)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("UserId", typeof(int));
            dt.Columns.Add("BookId", typeof(int));
            dt.Columns.Add("Rating", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Comment", typeof(string));

            foreach (var review in reviews)
            {
                DataRow row = dt.NewRow();
                row["Id"] = review.Id;
                row["UserId"] = review.UserId;
                row["BookId"] = review.BookId;
                row["Rating"] = review.Rating;
                row["Title"] = review.Title ?? (object)DBNull.Value;
                row["Comment"] = review.Comment ?? (object)DBNull.Value;
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
