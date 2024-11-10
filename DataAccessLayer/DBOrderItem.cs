using DataAccessLayer.Interfaces;
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
    public class DBOrderItem : DatabaseConnection, IOrderItemDb
    {
        // Adds a book to the cart
        public void AddToCart(int bookId, int orderId, int quantity = 1)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

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

        // Retrieves cart items for a specific user based on the user ID
        public DataTable GetCartFromUserID(int userID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT oi.*, b.Title, b.Price
            FROM OrderItem oi
            JOIN Book b ON oi.BookId = b.Id
            JOIN [Order] o ON oi.OrderId = o.Id
            WHERE o.UserId = @UserId AND o.Status IS NULL";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userID);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }
        public DataTable GetOrderItems(int orderID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT oi.*, b.Title, b.Price
            FROM OrderItem oi
            JOIN Book b ON oi.BookId = b.Id
            WHERE oi.OrderId = @OrderId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderID);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }


        // Increases the quantity of an item in the cart
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

        // Decreases the quantity or removes the item if quantity drops below 1
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
                        string updateQuery = "UPDATE OrderItem SET Quantity = Quantity - 1 WHERE Id = @OrderItemId";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@OrderItemId", orderItemId);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
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

        // Checkout method that updates status in Order and OrderItem tables
        public void Checkout(int orderId, string orderStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Update the Order's status to mark it as checked out
                string updateOrderStatusQuery = @"
                UPDATE [Order]
                SET Status = @Status
                WHERE Id = @OrderId";

                using (SqlCommand updateOrderStatusCommand = new SqlCommand(updateOrderStatusQuery, connection))
                {
                    updateOrderStatusCommand.Parameters.AddWithValue("@OrderId", orderId);
                    updateOrderStatusCommand.Parameters.AddWithValue("@Status", orderStatus);
                    updateOrderStatusCommand.ExecuteNonQuery();
                }
            }
        }



    }
}
