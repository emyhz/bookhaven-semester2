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
        public Products()
        {
            InitializeComponent();
            DisplayAudioBooks();
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
        private void DisplayAudioBooks()
        {
            BookManager bookManager = new BookManager();

            List<AudioBook> audioBooks = bookManager.GetAllAudioBooks();
            List<PhysicalBook> physicalBooks = bookManager.GetAllPhysicalBooks();

            flpProducts.Controls.Clear();

            foreach (AudioBook audioBook in audioBooks)
            {
                BookList bookControl = new BookList
                {
                    Title = audioBook.Title,
                    Author = audioBook.Author,
                    Price = (double)audioBook.Price,
                    Image = audioBook.ImagePath
                };

                flpProducts.Controls.Add(bookControl);
            }

            foreach (PhysicalBook physicalBook in physicalBooks)
            {
                BookList bookControl = new BookList
                {
                    Title = physicalBook.Title,
                    Author = physicalBook.Author,
                    Price = (double)physicalBook.Price,
                    Image = physicalBook.ImagePath 
                };

                flpProducts.Controls.Add(bookControl);
            }
        }
    }
}
