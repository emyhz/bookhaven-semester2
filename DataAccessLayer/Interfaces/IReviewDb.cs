using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IReviewDb
    {
        void AddReview(int userID, int vinylID, int rating, string? title, string? comment);
        DataTable GetReviewsForBook(int bookID);
        DataTable GetReviewsByUser(int userID);
        DataTable GetReviewDetails(int reviewId);
        void UpdateReview(int id, int rating, string? title, string? comment);
        void DeleteReview(int id);
    }
}
