using LogicLayer.Enums;
using LogicLayer.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHavenDesktop.Forms.PopUpForms
{
    public partial class AddAudio : Form
    {
        private BookManager _bookManager;
        public AddAudio(BookManager bookManager)
        {
            InitializeComponent();
            cmbGenre.DataSource = Enum.GetValues(typeof(Genre));
            _bookManager = bookManager;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAudioBook_Click(object sender, EventArgs e)
        {
            try
            {

                // Get the values from the form fields
                string title = txtTitle.Text;
                string author = txtAuthor.Text;
                long isbn = long.Parse(txtISBN.Text);
                DateTime publishDate = dtpPublish.Value;
                decimal price = numPrice.Value;
                string genre = cmbGenre.SelectedItem.ToString(); // Get selected genre from combo box
                string language = txtLanguage.Text;
                string imagePath = txtFilePath.Text; 
                int stock = (int)numStock.Value;
                int sales = 0; // Initial sales

                // Get AudioBook specific fields
                TimeSpan audioLength;
                if (!TimeSpan.TryParse(AudioLength.Text, out audioLength))
                {
                    MessageBox.Show("Invalid audio length. Please enter a valid time format (hh:mm:ss).");
                    return;
                }
                string fileSize = txtFileSize.Text;

                // BookType is AudioBook
                string bookType = "AudioBook";


                int bookId = _bookManager.AddBook(title, author, isbn, publishDate, price, genre, language, imagePath, stock, sales, bookType, audioLength, fileSize);

                MessageBox.Show($"AudioBook added successfully!");

                this.Close();
                ClearFormFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the audiobook: " + ex.Message);
            }
        }
        private bool ValidateTimeInput(string timeInput)
        {
            // Regex for valid time format (HH:mm:ss )
            string timePattern = @"^([01]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9](\.\d{1,7})?$";

            if (!Regex.IsMatch(timeInput, timePattern))
            {
                MessageBox.Show("Invalid time format. Please enter in HH:mm:ss or HH:mm:ss.fffffff format.");
                return false;
            }

            return true;
        }
        private void ClearFormFields()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtISBN.Clear();
            txtLanguage.Clear();
            txtFilePath.Clear();
            AudioLength.Clear();
            txtFileSize.Clear();
            numStock.Value = 0;
            numPrice.Value = 0;
            cmbGenre.SelectedIndex = 0; // Reset genre
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
