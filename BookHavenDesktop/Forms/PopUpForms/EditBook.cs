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
        private BookManager _bookManager;
        private Book book;
        public EditBook(Book book, BookManager bookManager)
        {
            InitializeComponent();
            PopulateGenreComboBox();
            this.book = book;
            _bookManager = bookManager;


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
                txtDummyLink.Text = audioBook.Link;

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
                lblDummyLink.Visible = false;
                txtDummyLink.Visible = false;
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
            string title = txtTitleEdit.Text;
            string author = txtAuthorEdit.Text;
            long isbn = long.Parse(txtISBNEdit.Text);
            DateTime publishYear = dtpPublishEdit.Value;
            decimal price = numPriceEdit.Value;
            string genre = cmbGenreEdit.SelectedItem.ToString();
            string language = lblLanguageEdit.Text;
            string imagePath = pbBookDetails.ImageLocation;
            int stock = (int)numStockEdit.Value;

            // Additional fields for specific book types
            TimeSpan? audioLength = null;
            string fileSize = null;
            string link = null;
            string dimensions = null;
            int? pages = null;
            string coverType = null;

            string bookType = book is AudioBook ? "AudioBook" : "PhysicalBook";

            if (book is AudioBook)
            {
                audioLength = TimeSpan.Parse(txtAudioLengthEdit.Text);
                fileSize = txtFileSizeEdit.Text;
                link = txtDummyLink.Text;

            }
            else if (book is PhysicalBook)
            {
                dimensions = txtDimensionsEdit.Text;
                pages = (int)numPagesEdit.Value;
                coverType = txtCovertypeEdit.Text;
            }

            DialogResult result = MessageBox.Show("Are you sure you would like to save these changes?", "Saving Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {

                _bookManager.UpdateBook(book.Id, title, author, isbn, publishYear, price, genre, language, imagePath, stock, audioLength, fileSize, link, dimensions, pages, coverType);


                MessageBox.Show("Book has been successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnSelectImg_Click(object sender, EventArgs e)
        {
            try
            {
                // Open file dialog to select an image from the Resources folder
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Set the initial directory to the Resources folder
                    string resourcesPath = Path.Combine(Application.StartupPath, "Resources");
                    openFileDialog.InitialDirectory = resourcesPath;
                    openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                    openFileDialog.Title = "Select an Image";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get the full path of the selected file
                        string selectedFilePath = openFileDialog.FileName;

                        // Get the relative path starting from the "Resources" folder
                        string relativePath = Path.GetRelativePath(Application.StartupPath, selectedFilePath);

                        // Set the relative path to the txtFilePath TextBox (or store it in the database)
                        txtFilePath.Text = relativePath;


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while selecting the image: " + ex.Message);
            }
        }
    }
}
