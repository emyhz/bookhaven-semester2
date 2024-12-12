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
        public void AddItemToCart(int userId, int bookId, int quantity = 1)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertItemQuery = "INSERT INTO OrderItem (UserId, BookId, Quantity) VALUES (@UserId, @BookId, @Quantity)";
                using (SqlCommand command = new SqlCommand(insertItemQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Retrieves cart items for a specific user based on the user ID
        public DataTable GetUserCart(int userID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM OrderItem WHERE UserId = @UserId AND OrderId IS NULL";

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
                string query = "SELECT * FROM OrderItem WHERE OrderId = @OrderId";

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
        //removes audiobook from cart (without quantity)
        public void RemoveAudioOrderItem(int orderItemId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM OrderItem WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", orderItemId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        // Checkout method that updates status in Order and OrderItem tables
        public void Checkout(int id,int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Update the Order's status to mark it as checked out
                string updateOrderStatusQuery = "UPDATE OrderItem SET OrderId = @OrderId WHERE Id = @Id";

                using (SqlCommand updateOrderStatusCommand = new SqlCommand(updateOrderStatusQuery, connection))
                {
                    updateOrderStatusCommand.Parameters.AddWithValue("@OrderId", orderId);
                    updateOrderStatusCommand.Parameters.AddWithValue("@Id", id);

                    updateOrderStatusCommand.ExecuteNonQuery();
                }
            }
        }



    }
}
