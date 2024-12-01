using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DBReview : DatabaseConnection, IReviewDb
    {
        public void AddReview(int userID, int bookId, int rating, string? title, string? comment)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            {
                string query = "INSERT INTO [Review] (UserId, Rating, BookId, Title, Comment) " +
                               "VALUES (@UserId, @Rating, @BookId, @Title, @Comment)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userID);
                command.Parameters.AddWithValue("@BookId", bookId);
                command.Parameters.AddWithValue("@Rating", rating);

                // Use DBNull.Value if the title or comment is null
                command.Parameters.AddWithValue("@Title", (object?)title ?? DBNull.Value);
                command.Parameters.AddWithValue("@Comment", (object?)comment ?? DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public DataTable GetReviewsForBook(int bookID)
        {
            DataTable dt = new DataTable();
            using SqlConnection connection = new SqlConnection(connectionString);
            {
                string query = "SELECT * FROM [Review] WHERE BookId = @BookId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookId", bookID);

                connection.Open();
                using SqlDataAdapter adapter = new SqlDataAdapter(command);
                {
                    adapter.Fill(dt);
                }
                connection.Close();
            }
            return dt;
        }

        public DataTable GetReviewsByUser(int userID)
        {
            DataTable dt = new DataTable();
            using SqlConnection connection = new SqlConnection(connectionString);
            {
                string query = "SELECT * FROM [Review] WHERE UserId = @UserId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userID);

                connection.Open();
                using SqlDataAdapter adapter = new SqlDataAdapter(command);
                {
                    adapter.Fill(dt);
                }
                connection.Close();
            }
            return dt;
        }

        public DataTable GetReviewDetails(int reviewId)
        {
            DataTable dt = new DataTable();
            using SqlConnection connection = new SqlConnection(connectionString);
            {
                string query = "SELECT * FROM [Review] WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", reviewId);

                connection.Open();
                using SqlDataAdapter adapter = new SqlDataAdapter(command);
                {
                    adapter.Fill(dt);
                }
                connection.Close();
            }
            return dt;
        }


        public void UpdateReview(int id, int rating, string? title, string? comment)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            {
                string query = "UPDATE [Review] SET Rating = @Rating, Title = @Title, Comment = @Comment WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Rating", rating);
                command.Parameters.AddWithValue("@Title", (object?)title ?? DBNull.Value);
                command.Parameters.AddWithValue("@Comment", (object?)comment ?? DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteReview(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            {
                string query = "DELETE FROM [Review] WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
