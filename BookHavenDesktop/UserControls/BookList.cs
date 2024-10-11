using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHavenDesktop.Forms.PopUpForms;
using LogicLayer.EntityClasses;

namespace BookHavenDesktop.UserControls
{
    public partial class BookList : UserControl
    {
        private string image;
        private string title;
        private string author;
        private double price;
        private Book bookData;
        public BookList()
        {
            InitializeComponent();
            //this.Click += BookList_Click;
        }

        



        public string Image
        {
            get { return image; }
            set { image = value; pbBook.ImageLocation = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; lblTitle.Text = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; lblAuthor.Text = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; lblPrice.Text = value.ToString(); }
        }
        public Book BookData
        {
            get { return bookData; }
            set { bookData = value; }
        }

        private void BookList_Click(object sender, EventArgs e)
        {
            BookDetails details = new BookDetails(bookData);
            details.ShowDialog();
        }

       
    }
}
