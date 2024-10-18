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
        public int AddOrder(int userId, string address, string country, string city, decimal zipCode, decimal totalPrice)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO [Order] (UserID, Address, Country, City, ZipCode, TotalPrice) VALUES (@UserID, @Address, @Country, @City, @ZipCode, @TotalPrice); " +
                           "SELECT SCOPE_IDENTITY()";
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
        public DataTable GetOrders()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT Id, Date, UserId, TotalPrice, Status FROM [Order]";
            SqlCommand cmd = new SqlCommand(query, connection);
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
        public DataTable GetOrdersByUser(int userId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Date, UserId, TotalPrice, Status FROM [Order] WHERE UserId = @UserId";
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
        public DataTable GetOrdersForBook(int bookId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                               SELECT o.Id, o.Date, o.UserId, o.TotalPrice, o.Status 
                               FROM [Order] o
                               INNER JOIN OrderItem oi ON o.Id = oi.OrderId
                               WHERE oi.BookId = @BookId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@BookId", bookId);

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
        public DataTable GetOrderDetails(int id)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [Order] WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }



    }

}
