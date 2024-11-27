using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DBReview : DatabaseConnection, IReviewDb
    {
        public void AddReview(int userID, int vinylID, int rating, string? title, string? comment)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            {
                string query = "INSERT INTO [Review] (UserID, Rating, VinylID, Title, Comment) " +
                               "VALUES (@UserID, @Rating, @VinylID, @Title, @Comment)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@VinylID", vinylID);
                command.Parameters.AddWithValue("@Rating", rating);

                // Use DBNull.Value if the title or comment is null
                command.Parameters.AddWithValue("@Title", (object?)title ?? DBNull.Value);
                command.Parameters.AddWithValue("@Comment", (object?)comment ?? DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
