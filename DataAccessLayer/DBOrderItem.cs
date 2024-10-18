using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DBOrderItem : DatabaseConnection
    {
        public void AddToCart(int bookId, int orderId, int quantity = 1)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Directly add or update the book in the OrderItem table using the provided OrderId
                string insertItemQuery = "INSERT INTO OrderItem (OrderId, BookId, Quantity) VALUES (@OrderId, @BookId, @Quantity)";

                using (SqlCommand command = new SqlCommand(insertItemQuery, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.ExecuteNonQuery();
                }
            }
        }
        public DataTable GetCartFromUserID(int userId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT oi.*, b.Title, b.Price
            FROM OrderItem oi
            JOIN [Order] o ON oi.OrderId = o.Id
            JOIN Book b ON oi.BookId = b.Id
            WHERE o.UserId = @UserId AND o.Status IS NULL";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }
        public void IncreaseQuantity(int orderItemId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE OrderItem SET Quantity = Quantity + 1 WHERE Id = @OrderItemId";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@OrderItemId", orderItemId);
                    updateCommand.ExecuteNonQuery();
                }
            }
        }
        public void DecreaseQuantity(int orderItemId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Quantity FROM OrderItem WHERE Id = @OrderItemId";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@OrderItemId", orderItemId);
                    int quantity = (int)selectCommand.ExecuteScalar();

                    if (quantity > 1)
                    {
                        // Decrease quantity by 1
                        string updateQuery = "UPDATE OrderItem SET Quantity = Quantity - 1 WHERE Id = @OrderItemId";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@OrderItemId", orderItemId);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Remove item from cart if quantity would drop below 1
                        string deleteQuery = "DELETE FROM OrderItem WHERE Id = @OrderItemId";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@OrderItemId", orderItemId);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        public void CheckoutCartItem(int userId, int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Update all cart items for the user (OrderItem entries) with the OrderID upon checkout
                string updateQuery = @"
            UPDATE OrderItem
            SET OrderId = @OrderId
            WHERE OrderId IN (
                SELECT o.Id
                FROM [Order] o
                WHERE o.UserId = @UserId AND o.Status IS NULL
            )";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@OrderId", orderId);
                    updateCommand.Parameters.AddWithValue("@UserId", userId);
                    updateCommand.ExecuteNonQuery();
                }

                
            }
        }


    }
}
