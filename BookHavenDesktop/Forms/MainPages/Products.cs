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
        private BookManager _bookManager;
        private List<Book> searchBooks;
        private List<Book> books;
        public Products(BookManager bookManager)
        {
            InitializeComponent();
            _bookManager = bookManager;
            DisplayBooks(books);
        }

        private void btnAddPhysical_Click(object sender, EventArgs e)
        {
            AddPhysical addPhysical = new AddPhysical(_bookManager);
            addPhysical.ShowDialog();
        }

        private void btnAddNewAudio_Click(object sender, EventArgs e)
        {
            AddAudio addAudio = new AddAudio(_bookManager);
            addAudio.ShowDialog();
        }
        private void DisplayBooks(List<Book> books)
        {

            if (books == null)
            {
                books = new List<Book>();

                books.AddRange(_bookManager.GetAllBooks());
            }

            flpProducts.Controls.Clear();

            foreach (Book book in books)
            {
                BookList bookControl = new BookList(_bookManager)
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

           
            searchBooks = _bookManager.SearchBook(title, author);
            DisplayBooks(searchBooks);
        }
    }
}
