using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHavenDesktop.UserControls
{
    public partial class BookList : UserControl
    {
        private string title;
        private string author;
        private double price;
        public BookList()
        {
            InitializeComponent();
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
    }
}
