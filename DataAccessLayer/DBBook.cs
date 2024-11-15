using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices.Marshalling;
using System.Collections;
using System.Diagnostics;
using System.Data;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class DBBook : DatabaseConnection , IBookDb
    {
        public int AddBook(string title, string author, long isbn, DateTime publishDate, decimal price, string genre, string language, string imagePath, int stock, int sales, string bookType,
                   TimeSpan? length = null, string fileSize = null, string dimensions = null, int? pages = null, string coverType = null)
        {
            int bookId = 0; // Initialize bookId

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Insert into Book table and get the generated Id
                    string insertBookQuery = "INSERT INTO [Book] (Title, Author, ISBN, PublishDate, Price, Genre, Language, ImagePath, Stock, Sales) " +
                                             "OUTPUT INSERTED.Id " +
                                             "VALUES (@Title, @Author, @ISBN, @PublishDate, @Price, @Genre, @Language, @ImagePath, @Stock, @Sales)";

                    SqlCommand bookCommand = new SqlCommand(insertBookQuery, connection, transaction);
                    bookCommand.Parameters.AddWithValue("@Title", title);
                    bookCommand.Parameters.AddWithValue("@Author", author);
                    bookCommand.Parameters.AddWithValue("@ISBN", isbn);
                    bookCommand.Parameters.AddWithValue("@PublishDate", publishDate);
                    bookCommand.Parameters.AddWithValue("@Price", price);
                    bookCommand.Parameters.AddWithValue("@Genre", genre);
                    bookCommand.Parameters.AddWithValue("@Language", language);
                    bookCommand.Parameters.AddWithValue("@ImagePath", imagePath);
                    bookCommand.Parameters.AddWithValue("@Stock", stock);
                    bookCommand.Parameters.AddWithValue("@Sales", sales);

                    bookId = (int)bookCommand.ExecuteScalar(); // Retrieve the generated book ID from the Book table

                    // Insert into AudioBook table if the type is audiobook
                    if (bookType == "AudioBook" && length.HasValue && !string.IsNullOrEmpty(fileSize))
                    {
                        string insertAudioBookQuery = "INSERT INTO [AudioBook] (Id, Length, FileSize) VALUES (@Id, @Length, @FileSize)";
                        SqlCommand audioBookCommand = new SqlCommand(insertAudioBookQuery, connection, transaction);
                        audioBookCommand.Parameters.AddWithValue("@Id", bookId); // Use the generated bookId from the Book table
                        audioBookCommand.Parameters.AddWithValue("@Length", length.Value);
                        audioBookCommand.Parameters.AddWithValue("@FileSize", fileSize);
                        audioBookCommand.ExecuteNonQuery();
                    }
                    // Insert into PhysicalBook table if the type is physical book
                    else if (bookType == "PhysicalBook" && !string.IsNullOrEmpty(dimensions) && pages.HasValue && !string.IsNullOrEmpty(coverType))
                    {
                        string insertPhysicalBookQuery = "INSERT INTO [PhysicalBook] (Id, Dimensions, Pages, CoverType) VALUES (@Id, @Dimensions, @Pages, @CoverType)";
                        SqlCommand physicalBookCommand = new SqlCommand(insertPhysicalBookQuery, connection, transaction);
                        physicalBookCommand.Parameters.AddWithValue("@Id", bookId); // Use the generated bookId from the Book table
                        physicalBookCommand.Parameters.AddWithValue("@Dimensions", dimensions);
                        physicalBookCommand.Parameters.AddWithValue("@Pages", pages.Value);
                        physicalBookCommand.Parameters.AddWithValue("@CoverType", coverType);
                        physicalBookCommand.ExecuteNonQuery();
                    }

                    // Commit the transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if there is any error
                    transaction.Rollback();
                    throw new Exception("An error occurred while adding the book: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return bookId; // Return the inserted book ID
        }
        public DataTable GetAllAudioBooks()
        {
            DataTable audioBooksTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Include ISBN in the SQL query to get all audiobook details
                string query = @"
        SELECT 
            b.Id,
            b.Title,
            b.Author,
            b.ISBN, -- Add ISBN to the query
            b.PublishDate,
            b.Price,
            b.Genre,
            b.Language,
            b.ImagePath,
            b.Stock,
            ab.Length AS AudioLength,
            ab.FileSize
        FROM 
            [Book] b
        INNER JOIN 
            [AudioBook] ab ON b.Id = ab.Id;";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(audioBooksTable);
            }

            return audioBooksTable;
        }

        public DataTable GetAllPhysicalBooks()
        {
            DataTable physicalBooksTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL query to get all physical book details including ISBN, dimensions, pages, and cover type
                string query = @"
                                SELECT 
                                b.Id,
                                b.Title,
                                b.Author,
                                b.ISBN, -- Include ISBN in the query
                                b.PublishDate,
                                b.Price,
                                b.Genre,
                                b.Language,
                                b.ImagePath,
                                b.Stock,
                                pb.Dimensions,
                                pb.Pages,
                                pb.CoverType
                            FROM 
                                [Book] b
                            INNER JOIN 
                                [PhysicalBook] pb ON b.Id = pb.Id;"; // Join with PhysicalBook table based on the book ID

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(physicalBooksTable);
            }

            return physicalBooksTable;
        }
        public DataTable GetBooks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL query to fetch both AudioBook and PhysicalBook details
                string query = @"
            SELECT 
                b.Id,
                b.Title,
                b.Author,
                b.ISBN,
                b.PublishDate,
                b.Price,
                b.Genre,
                b.Language,
                b.ImagePath,
                b.Stock,
                'AudioBook' AS BookType,
                ab.Length AS AudioLength,
                ab.FileSize,
                NULL AS Dimensions,
                NULL AS Pages,
                NULL AS CoverType
            FROM [Book] b
            INNER JOIN [AudioBook] ab ON b.Id = ab.Id

            UNION ALL

            SELECT 
                b.Id,
                b.Title,
                b.Author,
                b.ISBN,
                b.PublishDate,
                b.Price,
                b.Genre,
                b.Language,
                b.ImagePath,
                b.Stock,
                'PhysicalBook' AS BookType,
                NULL AS AudioLength,
                NULL AS FileSize,
                pb.Dimensions,
                pb.Pages,
                pb.CoverType
            FROM [Book] b
            INNER JOIN [PhysicalBook] pb ON b.Id = pb.Id;";

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
        }
        public void UpdateBook(int id, string title, string author, string isbn, DateTime publishDate, decimal price, string genre, string language, string imagePath, int stock, int sales, string bookType, TimeSpan? length = null, string fileSize = null, string dimensions = null, int? pages = null, string coverType = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Update general book information in Book table
                    string updateBookQuery = "UPDATE Book SET Title = @Title, Author = @Author, ISBN = @ISBN, PublishDate = @PublishDate, Price = @Price, " +
                                             "Genre = @Genre, Language = @Language, ImagePath = @ImagePath, Stock = @Stock, Sales = @Sales WHERE Id = @Id";

                    SqlCommand bookCommand = new SqlCommand(updateBookQuery, connection, transaction);
                    bookCommand.Parameters.AddWithValue("@Id", id);
                    bookCommand.Parameters.AddWithValue("@Title", title);
                    bookCommand.Parameters.AddWithValue("@Author", author);
                    bookCommand.Parameters.AddWithValue("@ISBN", isbn);
                    bookCommand.Parameters.AddWithValue("@PublishDate", publishDate);
                    bookCommand.Parameters.AddWithValue("@Price", price);
                    bookCommand.Parameters.AddWithValue("@Genre", genre);
                    bookCommand.Parameters.AddWithValue("@Language", language);
                    bookCommand.Parameters.AddWithValue("@ImagePath", imagePath);
                    bookCommand.Parameters.AddWithValue("@Stock", stock);
                    bookCommand.Parameters.AddWithValue("@Sales", sales);
                    bookCommand.ExecuteNonQuery();

                    // Update AudioBook details if the book type is AudioBook
                    if (bookType == "AudioBook" && length.HasValue && !string.IsNullOrEmpty(fileSize))
                    {
                        string updateAudioBookQuery = "UPDATE [AudioBook] SET Length = @Length, FileSize = @FileSize WHERE Id = @Id";
                        SqlCommand audioBookCommand = new SqlCommand(updateAudioBookQuery, connection, transaction);
                        audioBookCommand.Parameters.AddWithValue("@Id", id);
                        audioBookCommand.Parameters.AddWithValue("@Length", length.Value);
                        audioBookCommand.Parameters.AddWithValue("@FileSize", fileSize);
                        audioBookCommand.ExecuteNonQuery();
                    }
                    // Update PhysicalBook details if the book type is PhysicalBook
                    else if (bookType == "PhysicalBook" && !string.IsNullOrEmpty(dimensions) && pages.HasValue && !string.IsNullOrEmpty(coverType))
                    {
                        string updatePhysicalBookQuery = "UPDATE [PhysicalBook] SET Dimensions = @Dimensions, Pages = @Pages, CoverType = @CoverType WHERE Id = @Id";
                        SqlCommand physicalBookCommand = new SqlCommand(updatePhysicalBookQuery, connection, transaction);
                        physicalBookCommand.Parameters.AddWithValue("@Id", id);
                        physicalBookCommand.Parameters.AddWithValue("@Dimensions", dimensions);
                        physicalBookCommand.Parameters.AddWithValue("@Pages", pages.Value);
                        physicalBookCommand.Parameters.AddWithValue("@CoverType", coverType);
                        physicalBookCommand.ExecuteNonQuery();
                    }

                    // Commit transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback transaction if there is an error
                    transaction.Rollback();
                    throw new Exception("An error occurred while updating the book: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void DeleteBook(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // First, delete from AudioBook table if the book is an audiobook
                    string deleteAudioBookQuery = "DELETE FROM [AudioBook] WHERE Id = @Id";
                    SqlCommand audioBookCommand = new SqlCommand(deleteAudioBookQuery, connection, transaction);
                    audioBookCommand.Parameters.AddWithValue("@Id", id);
                    int audioBookRowsDeleted = audioBookCommand.ExecuteNonQuery();

                    // Then, delete from PhysicalBook table if the book is a physical book
                    string deletePhysicalBookQuery = "DELETE FROM [PhysicalBook] WHERE Id = @Id";
                    SqlCommand physicalBookCommand = new SqlCommand(deletePhysicalBookQuery, connection, transaction);
                    physicalBookCommand.Parameters.AddWithValue("@Id", id);
                    int physicalBookRowsDeleted = physicalBookCommand.ExecuteNonQuery();

                    // Finally, delete the book from the Book table
                    string deleteBookQuery = "DELETE FROM [Book] WHERE Id = @Id";
                    SqlCommand bookCommand = new SqlCommand(deleteBookQuery, connection, transaction);
                    bookCommand.Parameters.AddWithValue("@Id", id);
                    int bookRowsDeleted = bookCommand.ExecuteNonQuery();

                    // Check if any rows were deleted, commit if successful
                    if (audioBookRowsDeleted > 0 || physicalBookRowsDeleted > 0 || bookRowsDeleted > 0)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        throw new Exception("No matching book found to delete.");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while deleting the book: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }
        public DataTable GetBooksSummary()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Select basic details of books for summary display, include the book type.
                string query = @"
            SELECT b.Id, b.Title, b.Author, b.Price, b.Stock, b.Sales, b.ImagePath, 
                   CASE 
                       WHEN pb.Id IS NOT NULL THEN 'PhysicalBook' 
                       WHEN ab.Id IS NOT NULL THEN 'AudioBook' 
                       ELSE 'UnknownBookType' 
                   END AS BookType
            FROM [Book] b
            LEFT JOIN [PhysicalBook] pb ON b.Id = pb.Id
            LEFT JOIN [AudioBook] ab ON b.Id = ab.Id";

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
        }
        
        public DataTable GetBookDetails(int id)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to fetch all details of a specific book, including the book type and its specific attributes.
                string query = @"
            SELECT b.*, 
                   pb.Dimensions, pb.Pages, pb.CoverType, 
                   ab.Length AS AudioLength, ab.FileSize,
                   CASE 
                       WHEN pb.Id IS NOT NULL THEN 'PhysicalBook' 
                       WHEN ab.Id IS NOT NULL THEN 'AudioBook' 
                       ELSE 'UnknownBookType' 
                   END AS BookType
            FROM [Book] b
            LEFT JOIN [PhysicalBook] pb ON b.Id = pb.Id
            LEFT JOIN [AudioBook] ab ON b.Id = ab.Id
            WHERE b.Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
    }
}

