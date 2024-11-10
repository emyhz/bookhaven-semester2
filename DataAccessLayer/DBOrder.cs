using DataAccessLayer.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DBOrder : DatabaseConnection, IOrderDb
    {
        // Adds a new order and returns the generated order ID
        public int AddOrder(int userId, string address, string country, string city, decimal zipCode, decimal totalPrice)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = @"
            INSERT INTO [Order] (UserID, Address, Country, City, ZipCode, TotalPrice) 
            VALUES (@UserID, @Address, @Country, @City, @ZipCode, @TotalPrice); 
            SELECT SCOPE_IDENTITY()";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Country", country);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@ZipCode", zipCode);
                command.Parameters.AddWithValue("@TotalPrice", totalPrice);

                int orderId = Convert.ToInt32(command.ExecuteScalar());
                return orderId;
            }
        }

        // Retrieves all orders
        public DataTable GetOrders()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT Id, Date, UserId, TotalPrice, Status FROM [Order]";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

        // Retrieves orders for a specific user
        public DataTable GetOrdersByUser(int userId)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT Id, Date, UserId, TotalPrice, Status FROM [Order] WHERE UserId = @UserId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // Retrieves orders containing a specific book
        public DataTable GetOrdersForBook(int bookId)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = @"
            SELECT o.Id, o.Date, o.UserId, o.TotalPrice, o.Status 
            FROM [Order] o
            INNER JOIN OrderItem oi ON o.Id = oi.OrderId
            WHERE oi.BookId = @BookId";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@BookId", bookId);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
        }

        // Retrieves details for a specific order by its ID
        public DataTable GetOrderDetails(int orderId)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM [Order] WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", orderId);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // Finalizes an order by setting its status
        public void FinalizeOrder(int orderId, string orderStatus)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string updateStatusQuery = "UPDATE [Order] SET Status = @Status WHERE Id = @OrderId";
            using (SqlCommand command = new SqlCommand(updateStatusQuery, connection))
            {
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@Status", orderStatus);
                command.ExecuteNonQuery();
            }
        }

    }

}
