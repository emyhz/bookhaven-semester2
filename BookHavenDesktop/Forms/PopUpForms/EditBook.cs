using LogicLayer.EntityClasses;
using LogicLayer.Enums;
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
    public partial class EditBook : Form
    {
        private Book book;
        public EditBook(Book book)
        {
            InitializeComponent();
            PopulateGenreComboBox();
            this.book = book;

            txtTitleEdit.Text = book.Title;
            txtAuthorEdit.Text = book.Author;
            txtISBNEdit.Text = book.ISBN1.ToString();
            dtpPublishEdit.Value = book.PublishYear;
            numPriceEdit.Value = book.Price;
            numStockEdit.Value = book.Stock;
            lblLanguageEdit.Text = book.Language;
            cmbGenreEdit.SelectedItem = book.Genre.ToString();
            pbBookDetails.ImageLocation = book.ImagePath;

            if (book is AudioBook audioBook)
            {
                txtAudioLengthEdit.Text = audioBook.AudioLength.ToString();
                txtFileSizeEdit.Text = audioBook.FileSize;

                // Hide physical book specific controls
                lblDimensions.Visible = false;
                txtDimensionsEdit.Visible = false;
                lblCovertype.Visible = false;
                txtCovertypeEdit.Visible = false;
                lblPages.Visible = false;
                numPagesEdit.Visible = false;
            }
            else if (book is PhysicalBook physicalBook)
            {
                // Set additional details for PhysicalBook
                txtDimensionsEdit.Text = physicalBook.Dimensions;
                txtCovertypeEdit.Text = physicalBook.CoverType;
                numPagesEdit.Value = physicalBook.Pages;

                // Hide audiobook specific controls
                lblAudioLength.Visible = false;
                txtAudioLengthEdit.Visible = false;
                lblFileSize.Visible = false;
                txtFileSizeEdit.Visible = false;
            }
        }
        private void PopulateGenreComboBox()
        {
            cmbGenreEdit.Items.Clear();

            foreach (Genre genre in Enum.GetValues(typeof(Genre)))
            {
                cmbGenreEdit.Items.Add(genre.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Update the book object with the new values from the form controls
                book.Title = txtTitleEdit.Text;
                book.Author = txtAuthorEdit.Text;
                book.ISBN1 = long.Parse(txtISBNEdit.Text);
                book.PublishYear = dtpPublishEdit.Value;
                book.Price = numPriceEdit.Value;
                book.Stock = (int)numStockEdit.Value;
                book.Language = lblLanguageEdit.Text;
                book.Genre = (Genre)Enum.Parse(typeof(Genre), cmbGenreEdit.SelectedItem.ToString());
                book.ImagePath = pbBookDetails.ImageLocation;

                if (book is AudioBook audioBook)
                {
                    audioBook.AudioLength = TimeSpan.Parse(txtAudioLengthEdit.Text);
                    audioBook.FileSize = txtFileSizeEdit.Text;
                }
                else if (book is PhysicalBook physicalBook)
                {
                    physicalBook.Dimensions = txtDimensionsEdit.Text;
                    physicalBook.Pages = (int)numPagesEdit.Value;
                    physicalBook.CoverType = txtCovertypeEdit.Text;
                }

                BookManager bookManager = new BookManager();
                bookManager.UpdateBook(book);

                MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
