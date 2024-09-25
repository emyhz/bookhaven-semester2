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
            // Create an instance of the logic layer class
            BookManager bookManager = new BookManager(); // Assuming BookManager is your logic layer class

            // Get the list of audiobooks from the logic layer
            List<AudioBook> audioBooks = bookManager.GetAllAudioBooks();

            // Clear existing controls in the FlowLayoutPanel
            flpProducts.Controls.Clear();

            // Iterate through the list of audiobooks
            foreach (AudioBook audioBook in audioBooks)
            {
                // Create a new BookList control and set its properties
                BookList bookControl = new BookList
                {
                    Title = audioBook.Title,
                    Author = audioBook.Author,
                    Price = (double)audioBook.Price,
                    Image = audioBook.ImagePath 
                };

                // Add the BookList control to the FlowLayoutPanel
                flpProducts.Controls.Add(bookControl);
            }
        }
    }
}
