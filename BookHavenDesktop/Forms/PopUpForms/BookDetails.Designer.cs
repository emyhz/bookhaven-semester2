namespace BookHavenDesktop.Forms.PopUpForms
{
    partial class BookDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookDetails));
            pbBookDetails = new PictureBox();
            lblTitle = new Label();
            btnEditBook = new Button();
            btnDeleteBook = new Button();
            panel1 = new Panel();
            lblGenreShow = new Label();
            label2 = new Label();
            lblPriceShow = new Label();
            lblAuthorShow = new Label();
            lblStockShow = new Label();
            lblPublishDateShow = new Label();
            pbMoney = new PictureBox();
            lblPrice = new Label();
            lblAuthor = new Label();
            lblStockQuant = new Label();
            lblPublishDate = new Label();
            ((System.ComponentModel.ISupportInitialize)pbBookDetails).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbMoney).BeginInit();
            SuspendLayout();
            // 
            // pbBookDetails
            // 
            pbBookDetails.Location = new Point(23, 12);
            pbBookDetails.Name = "pbBookDetails";
            pbBookDetails.Size = new Size(273, 340);
            pbBookDetails.TabIndex = 0;
            pbBookDetails.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(220, 204, 163);
            lblTitle.Location = new Point(12, 369);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(284, 125);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Book title";
            // 
            // btnEditBook
            // 
            btnEditBook.BackColor = Color.FromArgb(130, 76, 113);
            btnEditBook.FlatAppearance.BorderSize = 0;
            btnEditBook.FlatStyle = FlatStyle.Flat;
            btnEditBook.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditBook.ForeColor = Color.White;
            btnEditBook.Location = new Point(37, 497);
            btnEditBook.Name = "btnEditBook";
            btnEditBook.Size = new Size(229, 50);
            btnEditBook.TabIndex = 21;
            btnEditBook.Text = "Edit book";
            btnEditBook.UseVisualStyleBackColor = false;
            btnEditBook.Click += btnEditBook_Click;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.BackColor = Color.FromArgb(130, 76, 113);
            btnDeleteBook.FlatAppearance.BorderSize = 0;
            btnDeleteBook.FlatStyle = FlatStyle.Flat;
            btnDeleteBook.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteBook.ForeColor = Color.White;
            btnDeleteBook.Location = new Point(37, 578);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(229, 50);
            btnDeleteBook.TabIndex = 22;
            btnDeleteBook.Text = "Delete book";
            btnDeleteBook.UseVisualStyleBackColor = false;
            btnDeleteBook.Click += btnDeleteBook_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(220, 204, 163);
            panel1.Controls.Add(lblGenreShow);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblPriceShow);
            panel1.Controls.Add(lblAuthorShow);
            panel1.Controls.Add(lblStockShow);
            panel1.Controls.Add(lblPublishDateShow);
            panel1.Controls.Add(pbMoney);
            panel1.Controls.Add(lblPrice);
            panel1.Controls.Add(lblAuthor);
            panel1.Controls.Add(lblStockQuant);
            panel1.Controls.Add(lblPublishDate);
            panel1.Location = new Point(317, -6);
            panel1.Name = "panel1";
            panel1.Size = new Size(601, 654);
            panel1.TabIndex = 1;
            // 
            // lblGenreShow
            // 
            lblGenreShow.AutoSize = true;
            lblGenreShow.Font = new Font("Segoe UI", 16.2F);
            lblGenreShow.ForeColor = Color.Black;
            lblGenreShow.Location = new Point(311, 534);
            lblGenreShow.Name = "lblGenreShow";
            lblGenreShow.Size = new Size(98, 38);
            lblGenreShow.TabIndex = 98;
            lblGenreShow.Text = "Genre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(25, 534);
            label2.Name = "label2";
            label2.Size = new Size(100, 38);
            label2.TabIndex = 97;
            label2.Text = "Genre:";
            // 
            // lblPriceShow
            // 
            lblPriceShow.AutoSize = true;
            lblPriceShow.Font = new Font("Segoe UI", 16.2F);
            lblPriceShow.ForeColor = Color.Black;
            lblPriceShow.Location = new Point(311, 405);
            lblPriceShow.Name = "lblPriceShow";
            lblPriceShow.Size = new Size(84, 38);
            lblPriceShow.TabIndex = 96;
            lblPriceShow.Text = "Price:";
            // 
            // lblAuthorShow
            // 
            lblAuthorShow.AutoSize = true;
            lblAuthorShow.Font = new Font("Segoe UI", 16.2F);
            lblAuthorShow.ForeColor = Color.Black;
            lblAuthorShow.Location = new Point(311, 155);
            lblAuthorShow.Name = "lblAuthorShow";
            lblAuthorShow.Size = new Size(108, 38);
            lblAuthorShow.TabIndex = 95;
            lblAuthorShow.Text = "Author:";
            // 
            // lblStockShow
            // 
            lblStockShow.AutoSize = true;
            lblStockShow.Font = new Font("Segoe UI", 16.2F);
            lblStockShow.ForeColor = Color.Black;
            lblStockShow.Location = new Point(311, 271);
            lblStockShow.Name = "lblStockShow";
            lblStockShow.Size = new Size(89, 38);
            lblStockShow.TabIndex = 94;
            lblStockShow.Text = "Stock:";
            // 
            // lblPublishDateShow
            // 
            lblPublishDateShow.AutoSize = true;
            lblPublishDateShow.Font = new Font("Segoe UI", 16.2F);
            lblPublishDateShow.ForeColor = Color.Black;
            lblPublishDateShow.Location = new Point(311, 43);
            lblPublishDateShow.Name = "lblPublishDateShow";
            lblPublishDateShow.Size = new Size(175, 38);
            lblPublishDateShow.TabIndex = 93;
            lblPublishDateShow.Text = "Publish date:";
            // 
            // pbMoney
            // 
            pbMoney.Image = (Image)resources.GetObject("pbMoney.Image");
            pbMoney.Location = new Point(274, 417);
            pbMoney.Name = "pbMoney";
            pbMoney.Size = new Size(31, 26);
            pbMoney.TabIndex = 92;
            pbMoney.TabStop = false;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            lblPrice.ForeColor = Color.Black;
            lblPrice.Location = new Point(25, 405);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(85, 38);
            lblPrice.TabIndex = 25;
            lblPrice.Text = "Price:";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            lblAuthor.ForeColor = Color.Black;
            lblAuthor.Location = new Point(25, 155);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(113, 38);
            lblAuthor.TabIndex = 24;
            lblAuthor.Text = "Author:";
            // 
            // lblStockQuant
            // 
            lblStockQuant.AutoSize = true;
            lblStockQuant.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            lblStockQuant.ForeColor = Color.Black;
            lblStockQuant.Location = new Point(25, 271);
            lblStockQuant.Name = "lblStockQuant";
            lblStockQuant.Size = new Size(94, 38);
            lblStockQuant.TabIndex = 23;
            lblStockQuant.Text = "Stock:";
            // 
            // lblPublishDate
            // 
            lblPublishDate.AutoSize = true;
            lblPublishDate.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold);
            lblPublishDate.ForeColor = Color.Black;
            lblPublishDate.Location = new Point(25, 43);
            lblPublishDate.Name = "lblPublishDate";
            lblPublishDate.Size = new Size(180, 38);
            lblPublishDate.TabIndex = 21;
            lblPublishDate.Text = "Publish date:";
            // 
            // BookDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(915, 640);
            Controls.Add(btnDeleteBook);
            Controls.Add(btnEditBook);
            Controls.Add(lblTitle);
            Controls.Add(panel1);
            Controls.Add(pbBookDetails);
            Name = "BookDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BookDetails";
            ((System.ComponentModel.ISupportInitialize)pbBookDetails).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbMoney).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbBookDetails;
        private Label lblTitle;
        private Button btnEditBook;
        private Button btnDeleteBook;
        private Panel panel1;
        private Label lblPublishDate;
        private Label lblStockQuant;
        private Label lblAuthor;
        private Label lblPrice;
        private Label lblPriceShow;
        private Label lblAuthorShow;
        private Label lblStockShow;
        private Label lblPublishDateShow;
        private PictureBox pbMoney;
        private Label lblGenreShow;
        private Label label2;
    }
}