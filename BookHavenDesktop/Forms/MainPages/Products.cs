using BookHavenDesktop.Forms.PopUpForms;
using BookHavenDesktop.UserControls;
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

namespace BookHavenDesktop.Forms.MainPages
{
    public partial class Products : Form
    {
        private BookManager bookManager;
        private List<Book> searchBooks;
        private List<Book> books;
        public Products()
        {
            InitializeComponent();
            bookManager = new BookManager();
            DisplayBooks(books);
        }

        private void btnAddPhysical_Click(object sender, EventArgs e)
        {
            AddPhysical addPhysical = new AddPhysical();
            addPhysical.ShowDialog();
        }

        private void btnAddNewAudio_Click(object sender, EventArgs e)
        {
            AddAudio addAudio = new AddAudio();
            addAudio.ShowDialog();
        }
        private void DisplayBooks(List<Book> books)
        {
            BookManager bookManager = new BookManager();

            // If no books list is provided, get all books
            if (books == null)
            {
                books = new List<Book>();

                books.AddRange(bookManager.GetAllAudioBooks());
                books.AddRange(bookManager.GetAllPhysicalBooks());
            }

            flpProducts.Controls.Clear();

            foreach (Book book in books)
            {
                BookList bookControl = new BookList
                {
                    Title = book.Title,
                    Author = book.Author,
                    Price = (double)book.Price,
                    Image = book.ImagePath,
                    BookData = book
                };

                flpProducts.Controls.Add(bookControl);
            }

        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            string title = txtTitleSearch.Text.Trim();
            string author = txtAuthorSearch.Text.Trim();

            // Validate and parse the ISBN number
            long isbn = 0;
            if (!long.TryParse(txtISBNSearch.Text.Trim(), out isbn))
            {
                MessageBox.Show("Invalid ISBN. Please enter a valid numeric ISBN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            searchBooks = bookManager.SearchBook(title, author, isbn);
            DisplayBooks(searchBooks);
        }
    }
}
