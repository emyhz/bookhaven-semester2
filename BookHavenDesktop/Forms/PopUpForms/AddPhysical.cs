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
    public partial class AddPhysical : Form
    {
        private BookManager bookManager;
        public AddPhysical()
        {
            InitializeComponent();
            bookManager = new BookManager();
            cmbGenre.DataSource = Enum.GetValues(typeof(Genre));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set the file filter for images
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string selectedFilePath = openFileDialog.FileName;

                        string projectDirectory = Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
                        string destinationFolder = Path.Combine(projectDirectory, "Resources");

                        string fileName = Path.GetFileName(selectedFilePath);
                        string destinationFilePath = Path.Combine(destinationFolder, fileName);

                        File.Copy(selectedFilePath, destinationFilePath, true);

                        string relativePath = Path.Combine("Resources", fileName);
                        txtFilePath.Text = relativePath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while selecting the image: " + ex.Message);
                    }
                }
            }
        }

        private void btnAddPhysicalBook_Click(object sender, EventArgs e)
        {
            try
            {
                BookManager bookManager = new BookManager();

                // Get the values from the form fields
                string title = txtTitle.Text;
                string author = txtAuthor.Text;
                long isbn = long.Parse(txtISBN.Text);
                DateTime publishDate = dtpPublish.Value;
                decimal price = numPrice.Value;
                string genre = cmbGenre.SelectedItem.ToString();
                string language = txtLanguage.Text;
                string imagePath = txtFilePath.Text;
                int stock = (int)numStock.Value;
                int sales = 0; // Initial sales

                // Get Physicalbook specific fields
                int pages = (int)numPageAmount.Value;
                string dimensions = txtDimensions.Text;
                string coverType = txtCoverType.Text;


                // BookType is AudioBook
                string bookType = "PhysicalBook";

                // Call the logic layer method to add the book
                int bookId = bookManager.AddBook(title, author, isbn, publishDate, price, genre, language, imagePath, stock, sales, bookType, null, null, dimensions, pages, coverType);


                MessageBox.Show($"Book added successfully!");
                this.Close();

                // Clear form fields after adding the book
                ClearFormFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the audiobook: " + ex.Message);
            }
        }
        private void ClearFormFields()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtISBN.Clear();
            txtLanguage.Clear();
            txtFilePath.Clear();
            numStock.Value = 0;
            numPrice.Value = 0;
            cmbGenre.SelectedIndex = 0;
            numPageAmount.Value = 0;
            txtDimensions.Clear();
            txtCoverType.Clear();
        }
    }
}
