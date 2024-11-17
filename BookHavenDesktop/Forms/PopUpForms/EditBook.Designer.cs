namespace BookHavenDesktop.Forms.PopUpForms
{
    partial class EditBook
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
            lblTitle = new Label();
            lblProducts = new Label();
            lblAuthor = new Label();
            lblISBN = new Label();
            lblPublishDate = new Label();
            txtTitleEdit = new TextBox();
            txtAuthorEdit = new TextBox();
            txtISBNEdit = new TextBox();
            lblLanguageEdit = new TextBox();
            cmbGenreEdit = new ComboBox();
            lblGenre = new Label();
            pbBookDetails = new PictureBox();
            lblPrice = new Label();
            lblStock = new Label();
            numPriceEdit = new NumericUpDown();
            numStockEdit = new NumericUpDown();
            btnSave = new Button();
            dtpPublishEdit = new DateTimePicker();
            lblLanguage = new Label();
            txtAudioLengthEdit = new TextBox();
            txtFileSizeEdit = new TextBox();
            lblAudioLength = new Label();
            lblFileSize = new Label();
            txtDimensionsEdit = new TextBox();
            txtCovertypeEdit = new TextBox();
            lblDimensions = new Label();
            lblCovertype = new Label();
            lblPages = new Label();
            numPagesEdit = new NumericUpDown();
            btnSelectImg = new Button();
            txtFilePath = new TextBox();
            lblImage = new Label();
            ((System.ComponentModel.ISupportInitialize)pbBookDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPriceEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPagesEdit).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10.8F);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(42, 165);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(48, 25);
            lblTitle.TabIndex = 15;
            lblTitle.Text = "Title:";
            // 
            // lblProducts
            // 
            lblProducts.AutoSize = true;
            lblProducts.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProducts.ForeColor = Color.FromArgb(220, 204, 163);
            lblProducts.Location = new Point(42, 42);
            lblProducts.Name = "lblProducts";
            lblProducts.Size = new Size(174, 46);
            lblProducts.TabIndex = 16;
            lblProducts.Text = "Edit Book";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 10.8F);
            lblAuthor.ForeColor = Color.Black;
            lblAuthor.Location = new Point(42, 237);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(71, 25);
            lblAuthor.TabIndex = 17;
            lblAuthor.Text = "Author:";
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Font = new Font("Segoe UI", 10.8F);
            lblISBN.ForeColor = Color.Black;
            lblISBN.Location = new Point(42, 314);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(54, 25);
            lblISBN.TabIndex = 18;
            lblISBN.Text = "ISBN:";
            // 
            // lblPublishDate
            // 
            lblPublishDate.AutoSize = true;
            lblPublishDate.Font = new Font("Segoe UI", 10.8F);
            lblPublishDate.ForeColor = Color.Black;
            lblPublishDate.Location = new Point(33, 376);
            lblPublishDate.Name = "lblPublishDate";
            lblPublishDate.Size = new Size(115, 25);
            lblPublishDate.TabIndex = 19;
            lblPublishDate.Text = "Publish Date:";
            // 
            // txtTitleEdit
            // 
            txtTitleEdit.BackColor = Color.WhiteSmoke;
            txtTitleEdit.BorderStyle = BorderStyle.None;
            txtTitleEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitleEdit.Location = new Point(154, 149);
            txtTitleEdit.Multiline = true;
            txtTitleEdit.Name = "txtTitleEdit";
            txtTitleEdit.Size = new Size(298, 41);
            txtTitleEdit.TabIndex = 20;
            // 
            // txtAuthorEdit
            // 
            txtAuthorEdit.BackColor = Color.WhiteSmoke;
            txtAuthorEdit.BorderStyle = BorderStyle.None;
            txtAuthorEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAuthorEdit.Location = new Point(154, 221);
            txtAuthorEdit.Multiline = true;
            txtAuthorEdit.Name = "txtAuthorEdit";
            txtAuthorEdit.Size = new Size(298, 41);
            txtAuthorEdit.TabIndex = 21;
            // 
            // txtISBNEdit
            // 
            txtISBNEdit.BackColor = Color.WhiteSmoke;
            txtISBNEdit.BorderStyle = BorderStyle.None;
            txtISBNEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtISBNEdit.Location = new Point(154, 298);
            txtISBNEdit.Multiline = true;
            txtISBNEdit.Name = "txtISBNEdit";
            txtISBNEdit.Size = new Size(298, 41);
            txtISBNEdit.TabIndex = 22;
            // 
            // lblLanguageEdit
            // 
            lblLanguageEdit.BackColor = Color.WhiteSmoke;
            lblLanguageEdit.BorderStyle = BorderStyle.None;
            lblLanguageEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLanguageEdit.Location = new Point(154, 514);
            lblLanguageEdit.Multiline = true;
            lblLanguageEdit.Name = "lblLanguageEdit";
            lblLanguageEdit.Size = new Size(298, 41);
            lblLanguageEdit.TabIndex = 23;
            // 
            // cmbGenreEdit
            // 
            cmbGenreEdit.BackColor = Color.WhiteSmoke;
            cmbGenreEdit.FlatStyle = FlatStyle.Flat;
            cmbGenreEdit.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbGenreEdit.FormattingEnabled = true;
            cmbGenreEdit.Location = new Point(154, 443);
            cmbGenreEdit.Margin = new Padding(3, 4, 3, 4);
            cmbGenreEdit.Name = "cmbGenreEdit";
            cmbGenreEdit.Size = new Size(298, 40);
            cmbGenreEdit.TabIndex = 57;
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Segoe UI", 10.8F);
            lblGenre.ForeColor = Color.Black;
            lblGenre.Location = new Point(42, 455);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(62, 25);
            lblGenre.TabIndex = 58;
            lblGenre.Text = "Genre:";
            // 
            // pbBookDetails
            // 
            pbBookDetails.Location = new Point(573, 12);
            pbBookDetails.Name = "pbBookDetails";
            pbBookDetails.Size = new Size(310, 369);
            pbBookDetails.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBookDetails.TabIndex = 59;
            pbBookDetails.TabStop = false;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10.8F);
            lblPrice.ForeColor = Color.Black;
            lblPrice.Location = new Point(500, 535);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(53, 25);
            lblPrice.TabIndex = 61;
            lblPrice.Text = "Price:";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI", 10.8F);
            lblStock.ForeColor = Color.Black;
            lblStock.Location = new Point(500, 478);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(59, 25);
            lblStock.TabIndex = 60;
            lblStock.Text = "Stock:";
            // 
            // numPriceEdit
            // 
            numPriceEdit.BackColor = Color.WhiteSmoke;
            numPriceEdit.BorderStyle = BorderStyle.None;
            numPriceEdit.DecimalPlaces = 2;
            numPriceEdit.Font = new Font("Segoe UI", 12F);
            numPriceEdit.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numPriceEdit.Location = new Point(621, 530);
            numPriceEdit.Margin = new Padding(3, 4, 3, 4);
            numPriceEdit.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numPriceEdit.Name = "numPriceEdit";
            numPriceEdit.Size = new Size(262, 30);
            numPriceEdit.TabIndex = 87;
            numPriceEdit.ThousandsSeparator = true;
            // 
            // numStockEdit
            // 
            numStockEdit.BackColor = Color.WhiteSmoke;
            numStockEdit.BorderStyle = BorderStyle.None;
            numStockEdit.Font = new Font("Segoe UI", 12F);
            numStockEdit.Location = new Point(621, 478);
            numStockEdit.Margin = new Padding(3, 4, 3, 4);
            numStockEdit.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numStockEdit.Name = "numStockEdit";
            numStockEdit.Size = new Size(262, 30);
            numStockEdit.TabIndex = 88;
            numStockEdit.ThousandsSeparator = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(130, 76, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(29, 794);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(854, 50);
            btnSave.TabIndex = 89;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // dtpPublishEdit
            // 
            dtpPublishEdit.CalendarFont = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpPublishEdit.Font = new Font("Segoe UI", 11.25F);
            dtpPublishEdit.Location = new Point(154, 376);
            dtpPublishEdit.Name = "dtpPublishEdit";
            dtpPublishEdit.Size = new Size(298, 32);
            dtpPublishEdit.TabIndex = 90;
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Font = new Font("Segoe UI", 10.8F);
            lblLanguage.ForeColor = Color.Black;
            lblLanguage.Location = new Point(42, 530);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(93, 25);
            lblLanguage.TabIndex = 91;
            lblLanguage.Text = "Language:";
            // 
            // txtAudioLengthEdit
            // 
            txtAudioLengthEdit.BackColor = Color.WhiteSmoke;
            txtAudioLengthEdit.BorderStyle = BorderStyle.None;
            txtAudioLengthEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAudioLengthEdit.Location = new Point(154, 657);
            txtAudioLengthEdit.Multiline = true;
            txtAudioLengthEdit.Name = "txtAudioLengthEdit";
            txtAudioLengthEdit.Size = new Size(298, 41);
            txtAudioLengthEdit.TabIndex = 96;
            // 
            // txtFileSizeEdit
            // 
            txtFileSizeEdit.BackColor = Color.WhiteSmoke;
            txtFileSizeEdit.BorderStyle = BorderStyle.None;
            txtFileSizeEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFileSizeEdit.Location = new Point(154, 585);
            txtFileSizeEdit.Multiline = true;
            txtFileSizeEdit.Name = "txtFileSizeEdit";
            txtFileSizeEdit.Size = new Size(298, 41);
            txtFileSizeEdit.TabIndex = 95;
            // 
            // lblAudioLength
            // 
            lblAudioLength.AutoSize = true;
            lblAudioLength.Font = new Font("Segoe UI", 10.8F);
            lblAudioLength.ForeColor = Color.Black;
            lblAudioLength.Location = new Point(29, 673);
            lblAudioLength.Name = "lblAudioLength";
            lblAudioLength.Size = new Size(119, 25);
            lblAudioLength.TabIndex = 93;
            lblAudioLength.Text = "Audio length:";
            // 
            // lblFileSize
            // 
            lblFileSize.AutoSize = true;
            lblFileSize.Font = new Font("Segoe UI", 10.8F);
            lblFileSize.ForeColor = Color.Black;
            lblFileSize.Location = new Point(42, 601);
            lblFileSize.Name = "lblFileSize";
            lblFileSize.Size = new Size(76, 25);
            lblFileSize.TabIndex = 92;
            lblFileSize.Text = "File size:";
            // 
            // txtDimensionsEdit
            // 
            txtDimensionsEdit.BackColor = Color.WhiteSmoke;
            txtDimensionsEdit.BorderStyle = BorderStyle.None;
            txtDimensionsEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDimensionsEdit.Location = new Point(585, 719);
            txtDimensionsEdit.Multiline = true;
            txtDimensionsEdit.Name = "txtDimensionsEdit";
            txtDimensionsEdit.Size = new Size(298, 41);
            txtDimensionsEdit.TabIndex = 102;
            // 
            // txtCovertypeEdit
            // 
            txtCovertypeEdit.BackColor = Color.WhiteSmoke;
            txtCovertypeEdit.BorderStyle = BorderStyle.None;
            txtCovertypeEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCovertypeEdit.Location = new Point(585, 654);
            txtCovertypeEdit.Multiline = true;
            txtCovertypeEdit.Name = "txtCovertypeEdit";
            txtCovertypeEdit.Size = new Size(298, 41);
            txtCovertypeEdit.TabIndex = 101;
            // 
            // lblDimensions
            // 
            lblDimensions.AutoSize = true;
            lblDimensions.Font = new Font("Segoe UI", 10.8F);
            lblDimensions.ForeColor = Color.Black;
            lblDimensions.Location = new Point(460, 735);
            lblDimensions.Name = "lblDimensions";
            lblDimensions.Size = new Size(109, 25);
            lblDimensions.TabIndex = 100;
            lblDimensions.Text = "Dimensions:";
            lblDimensions.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblCovertype
            // 
            lblCovertype.AutoSize = true;
            lblCovertype.Font = new Font("Segoe UI", 10.8F);
            lblCovertype.ForeColor = Color.Black;
            lblCovertype.Location = new Point(482, 670);
            lblCovertype.Name = "lblCovertype";
            lblCovertype.Size = new Size(97, 25);
            lblCovertype.TabIndex = 99;
            lblCovertype.Text = "Covertype:";
            // 
            // lblPages
            // 
            lblPages.AutoSize = true;
            lblPages.Font = new Font("Segoe UI", 10.8F);
            lblPages.ForeColor = Color.Black;
            lblPages.Location = new Point(500, 601);
            lblPages.Name = "lblPages";
            lblPages.Size = new Size(62, 25);
            lblPages.TabIndex = 98;
            lblPages.Text = "Pages:";
            // 
            // numPagesEdit
            // 
            numPagesEdit.BackColor = Color.WhiteSmoke;
            numPagesEdit.BorderStyle = BorderStyle.None;
            numPagesEdit.Font = new Font("Segoe UI", 12F);
            numPagesEdit.Location = new Point(621, 599);
            numPagesEdit.Margin = new Padding(3, 4, 3, 4);
            numPagesEdit.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPagesEdit.Name = "numPagesEdit";
            numPagesEdit.Size = new Size(262, 30);
            numPagesEdit.TabIndex = 103;
            numPagesEdit.ThousandsSeparator = true;
            // 
            // btnSelectImg
            // 
            btnSelectImg.BackColor = Color.FromArgb(130, 76, 113);
            btnSelectImg.FlatAppearance.BorderSize = 0;
            btnSelectImg.FlatStyle = FlatStyle.Flat;
            btnSelectImg.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSelectImg.ForeColor = Color.White;
            btnSelectImg.Location = new Point(743, 408);
            btnSelectImg.Name = "btnSelectImg";
            btnSelectImg.Size = new Size(140, 41);
            btnSelectImg.TabIndex = 106;
            btnSelectImg.Text = "Select image";
            btnSelectImg.UseVisualStyleBackColor = false;
            btnSelectImg.Click += btnSelectImg_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.BackColor = Color.WhiteSmoke;
            txtFilePath.BorderStyle = BorderStyle.None;
            txtFilePath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilePath.Location = new Point(585, 408);
            txtFilePath.Multiline = true;
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(152, 41);
            txtFilePath.TabIndex = 105;
            // 
            // lblImage
            // 
            lblImage.AutoSize = true;
            lblImage.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblImage.ForeColor = Color.Black;
            lblImage.Location = new Point(499, 414);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(62, 23);
            lblImage.TabIndex = 104;
            lblImage.Text = "Image:";
            // 
            // EditBook
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(915, 856);
            Controls.Add(btnSelectImg);
            Controls.Add(txtFilePath);
            Controls.Add(lblImage);
            Controls.Add(numPagesEdit);
            Controls.Add(txtDimensionsEdit);
            Controls.Add(txtCovertypeEdit);
            Controls.Add(lblDimensions);
            Controls.Add(lblCovertype);
            Controls.Add(lblPages);
            Controls.Add(txtAudioLengthEdit);
            Controls.Add(txtFileSizeEdit);
            Controls.Add(lblAudioLength);
            Controls.Add(lblFileSize);
            Controls.Add(lblLanguage);
            Controls.Add(dtpPublishEdit);
            Controls.Add(btnSave);
            Controls.Add(numStockEdit);
            Controls.Add(numPriceEdit);
            Controls.Add(lblPrice);
            Controls.Add(lblStock);
            Controls.Add(pbBookDetails);
            Controls.Add(lblGenre);
            Controls.Add(cmbGenreEdit);
            Controls.Add(lblLanguageEdit);
            Controls.Add(txtISBNEdit);
            Controls.Add(txtAuthorEdit);
            Controls.Add(txtTitleEdit);
            Controls.Add(lblPublishDate);
            Controls.Add(lblISBN);
            Controls.Add(lblAuthor);
            Controls.Add(lblProducts);
            Controls.Add(lblTitle);
            Name = "EditBook";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditBook";
            ((System.ComponentModel.ISupportInitialize)pbBookDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPriceEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPagesEdit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblProducts;
        private Label lblAuthor;
        private Label lblISBN;
        private Label lblPublishDate;
        private TextBox txtTitleEdit;
        private TextBox txtAuthorEdit;
        private TextBox txtISBNEdit;
        private TextBox lblLanguageEdit;
        private ComboBox cmbGenreEdit;
        private Label lblGenre;
        private PictureBox pbBookDetails;
        private Label lblPrice;
        private Label lblStock;
        private NumericUpDown numPriceEdit;
        private NumericUpDown numStockEdit;
        private Button btnSave;
        private DateTimePicker dtpPublishEdit;
        private Label lblLanguage;
        private TextBox txtAudioLengthEdit;
        private TextBox txtFileSizeEdit;
        private Label lblAudioLength;
        private Label lblFileSize;
        private TextBox txtDimensionsEdit;
        private TextBox txtCovertypeEdit;
        private Label lblDimensions;
        private Label lblCovertype;
        private Label lblPages;
        private NumericUpDown numPagesEdit;
        private Button btnSelectImg;
        private TextBox txtFilePath;
        private Label lblImage;
    }
}