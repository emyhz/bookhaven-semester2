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
        public int AddOrder(int userId, string address, string country, string city, string zipCode, decimal totalPrice, int orderStatus)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = @"
            INSERT INTO [Order] (UserID, Address, Country, City, Zip, TotalPrice, Status, Date) 
            VALUES (@UserID, @Address, @Country, @City, @Zip, @TotalPrice, @Status, @Date); 
            SELECT SCOPE_IDENTITY()";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Country", country);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@Zip", zipCode);
                command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                command.Parameters.AddWithValue("@Status", orderStatus);
                command.Parameters.AddWithValue("@Date", DateTime.Now);

                int orderId = Convert.ToInt32(command.ExecuteScalar());
                return orderId;
            }
        }


        // Retrieves all orders
        public DataTable GetOrders()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT Id, Date, UserId, TotalPrice, Status FROM [Order] WHERE UserId = @UserId";
            using (SqlCommand cmd = new SqlCommand(query, connection))

            
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

        // Retrieves orders for a specific user
        public DataTable GetUserOrders(int userId)
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
        public DataTable GetStatisticOrders(DateTime startDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Adjust the query based on whether endDate is provided
                string query = @"
                SELECT ID, Date, UserID, TotalPrice, Status 
                FROM [Order] 
                WHERE Date >= @StartDate";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    try
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

        }
        public DataTable GetCompletedOrders()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
        SELECT * 
        FROM [OrderItem] 
        WHERE OrderId IS NOT NULL";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        //public DataTable GetBookOrders(int bookId)
        //{

        //}


    }
}
