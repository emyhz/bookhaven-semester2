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
       
        //new method to add book
        public int AddBook(string title, string author, long isbn, DateTime publishDate, decimal price, string genre, string language, string imagePath, int stock, int sales,
    TimeSpan? audioLength = null, string fileSize = null, string dimensions = null, int? pages = null, string coverType = null)
        {
            int bookId = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Insert into Book table and get the generated ID
                    string insertBookQuery = @"INSERT INTO [Book] (Title, Author, ISBN, PublishDate, Price, Genre, Language, ImagePath, Stock, Sales) 
                                       OUTPUT INSERTED.Id 
                                       VALUES (@Title, @Author, @ISBN, @PublishDate, @Price, @Genre, @Language, @ImagePath, @Stock, @Sales)";

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

                    bookId = (int)bookCommand.ExecuteScalar();

                    // If AudioBook-specific fields are provided, insert into AudioBook table
                    if (audioLength.HasValue && !string.IsNullOrEmpty(fileSize))
                    {
                        string insertAudioBookQuery = "INSERT INTO [AudioBook] (Id, Length, FileSize) VALUES (@Id, @Length, @FileSize)";
                        SqlCommand audioBookCommand = new SqlCommand(insertAudioBookQuery, connection, transaction);
                        audioBookCommand.Parameters.AddWithValue("@Id", bookId);
                        audioBookCommand.Parameters.AddWithValue("@Length", audioLength.Value);
                        audioBookCommand.Parameters.AddWithValue("@FileSize", fileSize);
                        audioBookCommand.ExecuteNonQuery();
                    }
                    // If PhysicalBook-specific fields are provided, insert into PhysicalBook table
                    else if (!string.IsNullOrEmpty(dimensions) && pages.HasValue && !string.IsNullOrEmpty(coverType))
                    {
                        string insertPhysicalBookQuery = "INSERT INTO [PhysicalBook] (Id, Dimensions, Pages, CoverType) VALUES (@Id, @Dimensions, @Pages, @CoverType)";
                        SqlCommand physicalBookCommand = new SqlCommand(insertPhysicalBookQuery, connection, transaction);
                        physicalBookCommand.Parameters.AddWithValue("@Id", bookId);
                        physicalBookCommand.Parameters.AddWithValue("@Dimensions", dimensions);
                        physicalBookCommand.Parameters.AddWithValue("@Pages", pages.Value);
                        physicalBookCommand.Parameters.AddWithValue("@CoverType", coverType);
                        physicalBookCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred while adding the book: " + ex.Message);
                }
            }

            return bookId;
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
       
        //new method to get all books
        public DataTable GetBooks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL query to fetch books and join them with their respective specific tables
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
                ab.Length AS AudioLength,
                ab.FileSize,
                pb.Dimensions,
                pb.Pages,
                pb.CoverType
            FROM [Book] b
            LEFT JOIN [AudioBook] ab ON b.Id = ab.Id
            LEFT JOIN [PhysicalBook] pb ON b.Id = pb.Id;";

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

        public void UpdateBook(int id, string title, string author, long isbn, DateTime publishDate, decimal price, string genre, string language, string imagePath, int stock, int sales,
    TimeSpan? length = null, string fileSize = null, string dimensions = null, int? pages = null, string coverType = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Update general book information in Book table
                    string updateBookQuery = @"
                UPDATE Book 
                SET Title = @Title, Author = @Author, ISBN = @ISBN, PublishDate = @PublishDate, 
                    Price = @Price, Genre = @Genre, Language = @Language, 
                    ImagePath = @ImagePath, Stock = @Stock, Sales = @Sales 
                WHERE Id = @Id";

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

                    // Update AudioBook details if `length` and `fileSize` are provided
                    if (length.HasValue && !string.IsNullOrEmpty(fileSize))
                    {
                        string updateAudioBookQuery = @"
                    UPDATE AudioBook 
                    SET Length = @Length, FileSize = @FileSize 
                    WHERE Id = @Id";

                        SqlCommand audioBookCommand = new SqlCommand(updateAudioBookQuery, connection, transaction);
                        audioBookCommand.Parameters.AddWithValue("@Id", id);
                        audioBookCommand.Parameters.AddWithValue("@Length", length.Value);
                        audioBookCommand.Parameters.AddWithValue("@FileSize", fileSize);
                        audioBookCommand.ExecuteNonQuery();
                    }

                    // Update PhysicalBook details if `dimensions`, `pages`, and `coverType` are provided
                    if (!string.IsNullOrEmpty(dimensions) && pages.HasValue && !string.IsNullOrEmpty(coverType))
                    {
                        string updatePhysicalBookQuery = @"
                    UPDATE PhysicalBook 
                    SET Dimensions = @Dimensions, Pages = @Pages, CoverType = @CoverType 
                    WHERE Id = @Id";

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
        public void BuyBook(int bookId, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Decrease the stock for physical books
                    string updateStockQuery = @"
            UPDATE [Book] 
            SET Stock = Stock - @Quantity 
            WHERE Id = @Id AND Stock >= @Quantity 
            AND Id IN (SELECT Id FROM [PhysicalBook])";

                    SqlCommand updateStockCommand = new SqlCommand(updateStockQuery, connection, transaction);
                    updateStockCommand.Parameters.AddWithValue("@Id", bookId);
                    updateStockCommand.Parameters.AddWithValue("@Quantity", quantity);

                    int rowsAffected = updateStockCommand.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Insufficient stock available or the book is not a PhysicalBook.");
                    }

                    // Increment the sales count
                    string updateSalesQuery = @"
            UPDATE [Book] 
            SET Sales = Sales + @Quantity 
            WHERE Id = @Id";

                    SqlCommand updateSalesCommand = new SqlCommand(updateSalesQuery, connection, transaction);
                    updateSalesCommand.Parameters.AddWithValue("@Id", bookId);
                    updateSalesCommand.Parameters.AddWithValue("@Quantity", quantity);
                    updateSalesCommand.ExecuteNonQuery();

                    // Commit the transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if there is any error
                    transaction.Rollback();
                    throw new Exception($"An error occurred while buying the book: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}

