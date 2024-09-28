using LogicLayer.EntityClasses;
using LogicLayer.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHavenDesktop.Forms.PopUpForms
{
    public partial class BookDetails : Form
    {
        private Book book;
        private Book _selectedBook;
        private int _bookId;
        private BookManager bookManager;
        public BookDetails(Book book)
        {
            InitializeComponent();
            this.book = book;
            bookManager = new BookManager();


            lblPublishDateShow.Text = book.PublishYear.ToString("dd/MM/yyyy");
            lblTitle.Text = book.Title;
            lblAuthorShow.Text = book.Author;
            lblPriceShow.Text = book.Price.ToString();
            lblStockShow.Text = book.Stock.ToString();
            pbBookDetails.ImageLocation = book.ImagePath;

        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            EditBook editBook = new EditBook(book);
            editBook.ShowDialog();
            this.Close();
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_selectedBook is PhysicalBook)
                    {
                        bookManager.DeleteBook(_selectedBook.Id);
                    }
                    else if (_selectedBook is AudioBook)
                    {
                        bookManager.DeleteBook(_selectedBook.Id);
                    }

                    MessageBox.Show("Book deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
