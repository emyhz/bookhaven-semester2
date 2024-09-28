namespace BookHavenDesktop.Forms.PopUpForms
{
    partial class AddPhysical
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPhysical));
            pbPhysical = new PictureBox();
            lblPhysical2 = new Label();
            lblPhysical = new Label();
            pnlAudio = new Panel();
            txtCoverType = new TextBox();
            lblCoverType = new Label();
            pbMoney = new PictureBox();
            btnAddPhysicalBook = new Button();
            btnSelectImg = new Button();
            dtpPublish = new DateTimePicker();
            cmbGenre = new ComboBox();
            numPrice = new NumericUpDown();
            numStock = new NumericUpDown();
            lblDimensions = new Label();
            txtDimensions = new TextBox();
            txtFilePath = new TextBox();
            txtLanguage = new TextBox();
            txtISBN = new TextBox();
            txtAuthor = new TextBox();
            lblPages = new Label();
            lblStockQuant = new Label();
            lblGenre = new Label();
            lblPublishDate = new Label();
            txtTitle = new TextBox();
            lblAuthor = new Label();
            lblImage = new Label();
            lblLanuage = new Label();
            lblPrice = new Label();
            lblISBN = new Label();
            lblTitle = new Label();
            btnClose = new Button();
            numPageAmount = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pbPhysical).BeginInit();
            pnlAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbMoney).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPageAmount).BeginInit();
            SuspendLayout();
            // 
            // pbPhysical
            // 
            pbPhysical.Image = (Image)resources.GetObject("pbPhysical.Image");
            pbPhysical.Location = new Point(1047, 21);
            pbPhysical.Name = "pbPhysical";
            pbPhysical.Size = new Size(68, 62);
            pbPhysical.TabIndex = 19;
            pbPhysical.TabStop = false;
            // 
            // lblPhysical2
            // 
            lblPhysical2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhysical2.ForeColor = Color.Black;
            lblPhysical2.Location = new Point(54, 55);
            lblPhysical2.Name = "lblPhysical2";
            lblPhysical2.Size = new Size(309, 28);
            lblPhysical2.TabIndex = 18;
            lblPhysical2.Text = "Enter the details of the book\r\n\r\n";
            // 
            // lblPhysical
            // 
            lblPhysical.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhysical.ForeColor = Color.FromArgb(220, 204, 163);
            lblPhysical.Location = new Point(54, 9);
            lblPhysical.Name = "lblPhysical";
            lblPhysical.Size = new Size(385, 46);
            lblPhysical.TabIndex = 17;
            lblPhysical.Text = "Add a new physical book\r\n\r\n";
            // 
            // pnlAudio
            // 
            pnlAudio.BackColor = Color.White;
            pnlAudio.Controls.Add(numPageAmount);
            pnlAudio.Controls.Add(txtCoverType);
            pnlAudio.Controls.Add(lblCoverType);
            pnlAudio.Controls.Add(pbMoney);
            pnlAudio.Controls.Add(btnAddPhysicalBook);
            pnlAudio.Controls.Add(btnSelectImg);
            pnlAudio.Controls.Add(dtpPublish);
            pnlAudio.Controls.Add(cmbGenre);
            pnlAudio.Controls.Add(numPrice);
            pnlAudio.Controls.Add(numStock);
            pnlAudio.Controls.Add(lblDimensions);
            pnlAudio.Controls.Add(txtDimensions);
            pnlAudio.Controls.Add(txtFilePath);
            pnlAudio.Controls.Add(txtLanguage);
            pnlAudio.Controls.Add(txtISBN);
            pnlAudio.Controls.Add(txtAuthor);
            pnlAudio.Controls.Add(lblPages);
            pnlAudio.Controls.Add(lblStockQuant);
            pnlAudio.Controls.Add(lblGenre);
            pnlAudio.Controls.Add(lblPublishDate);
            pnlAudio.Controls.Add(txtTitle);
            pnlAudio.Controls.Add(lblAuthor);
            pnlAudio.Controls.Add(lblImage);
            pnlAudio.Controls.Add(lblLanuage);
            pnlAudio.Controls.Add(lblPrice);
            pnlAudio.Controls.Add(lblISBN);
            pnlAudio.Controls.Add(lblTitle);
            pnlAudio.Location = new Point(54, 86);
            pnlAudio.Name = "pnlAudio";
            pnlAudio.Size = new Size(1064, 715);
            pnlAudio.TabIndex = 20;
            // 
            // txtCoverType
            // 
            txtCoverType.BackColor = Color.WhiteSmoke;
            txtCoverType.BorderStyle = BorderStyle.None;
            txtCoverType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCoverType.Location = new Point(663, 538);
            txtCoverType.Multiline = true;
            txtCoverType.Name = "txtCoverType";
            txtCoverType.Size = new Size(341, 41);
            txtCoverType.TabIndex = 93;
            // 
            // lblCoverType
            // 
            lblCoverType.AutoSize = true;
            lblCoverType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCoverType.ForeColor = Color.Black;
            lblCoverType.Location = new Point(542, 551);
            lblCoverType.Name = "lblCoverType";
            lblCoverType.Size = new Size(111, 28);
            lblCoverType.TabIndex = 92;
            lblCoverType.Text = "Cover type:";
            // 
            // pbMoney
            // 
            pbMoney.Image = (Image)resources.GetObject("pbMoney.Image");
            pbMoney.Location = new Point(101, 261);
            pbMoney.Name = "pbMoney";
            pbMoney.Size = new Size(32, 25);
            pbMoney.TabIndex = 91;
            pbMoney.TabStop = false;
            // 
            // btnAddPhysicalBook
            // 
            btnAddPhysicalBook.BackColor = Color.FromArgb(144, 170, 134);
            btnAddPhysicalBook.FlatAppearance.BorderSize = 0;
            btnAddPhysicalBook.FlatStyle = FlatStyle.Flat;
            btnAddPhysicalBook.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddPhysicalBook.ForeColor = Color.White;
            btnAddPhysicalBook.Location = new Point(27, 645);
            btnAddPhysicalBook.Name = "btnAddPhysicalBook";
            btnAddPhysicalBook.Size = new Size(977, 41);
            btnAddPhysicalBook.TabIndex = 90;
            btnAddPhysicalBook.Text = "Add physical book";
            btnAddPhysicalBook.UseVisualStyleBackColor = false;
            btnAddPhysicalBook.Click += btnAddPhysicalBook_Click;
            // 
            // btnSelectImg
            // 
            btnSelectImg.BackColor = Color.FromArgb(130, 76, 113);
            btnSelectImg.FlatAppearance.BorderSize = 0;
            btnSelectImg.FlatStyle = FlatStyle.Flat;
            btnSelectImg.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSelectImg.ForeColor = Color.White;
            btnSelectImg.Location = new Point(367, 551);
            btnSelectImg.Name = "btnSelectImg";
            btnSelectImg.Size = new Size(140, 41);
            btnSelectImg.TabIndex = 89;
            btnSelectImg.Text = "Select image";
            btnSelectImg.UseVisualStyleBackColor = false;
            btnSelectImg.Click += btnSelectImg_Click;
            // 
            // dtpPublish
            // 
            dtpPublish.CalendarFont = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpPublish.Font = new Font("Segoe UI", 11.25F);
            dtpPublish.Location = new Point(663, 163);
            dtpPublish.Name = "dtpPublish";
            dtpPublish.Size = new Size(341, 32);
            dtpPublish.TabIndex = 88;
            // 
            // cmbGenre
            // 
            cmbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenre.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(663, 249);
            cmbGenre.Margin = new Padding(3, 4, 3, 4);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(341, 40);
            cmbGenre.TabIndex = 87;
            // 
            // numPrice
            // 
            numPrice.BackColor = Color.WhiteSmoke;
            numPrice.BorderStyle = BorderStyle.None;
            numPrice.DecimalPlaces = 2;
            numPrice.Font = new Font("Segoe UI", 12F);
            numPrice.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            numPrice.Location = new Point(139, 256);
            numPrice.Margin = new Padding(3, 4, 3, 4);
            numPrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(359, 30);
            numPrice.TabIndex = 86;
            numPrice.ThousandsSeparator = true;
            // 
            // numStock
            // 
            numStock.BackColor = Color.WhiteSmoke;
            numStock.BorderStyle = BorderStyle.None;
            numStock.Font = new Font("Segoe UI", 12F);
            numStock.Location = new Point(663, 363);
            numStock.Margin = new Padding(3, 4, 3, 4);
            numStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(341, 30);
            numStock.TabIndex = 85;
            numStock.ThousandsSeparator = true;
            // 
            // lblDimensions
            // 
            lblDimensions.AutoSize = true;
            lblDimensions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDimensions.ForeColor = Color.Black;
            lblDimensions.Location = new Point(533, 458);
            lblDimensions.Name = "lblDimensions";
            lblDimensions.Size = new Size(117, 28);
            lblDimensions.TabIndex = 33;
            lblDimensions.Text = "Dimensions:";
            // 
            // txtDimensions
            // 
            txtDimensions.BackColor = Color.WhiteSmoke;
            txtDimensions.BorderStyle = BorderStyle.None;
            txtDimensions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDimensions.Location = new Point(663, 445);
            txtDimensions.Multiline = true;
            txtDimensions.Name = "txtDimensions";
            txtDimensions.Size = new Size(341, 41);
            txtDimensions.TabIndex = 32;
            // 
            // txtFilePath
            // 
            txtFilePath.BackColor = Color.WhiteSmoke;
            txtFilePath.BorderStyle = BorderStyle.None;
            txtFilePath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilePath.Location = new Point(139, 551);
            txtFilePath.Multiline = true;
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(222, 41);
            txtFilePath.TabIndex = 31;
            // 
            // txtLanguage
            // 
            txtLanguage.BackColor = Color.WhiteSmoke;
            txtLanguage.BorderStyle = BorderStyle.None;
            txtLanguage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLanguage.Location = new Point(139, 349);
            txtLanguage.Multiline = true;
            txtLanguage.Name = "txtLanguage";
            txtLanguage.Size = new Size(359, 41);
            txtLanguage.TabIndex = 29;
            // 
            // txtISBN
            // 
            txtISBN.BackColor = Color.WhiteSmoke;
            txtISBN.BorderStyle = BorderStyle.None;
            txtISBN.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtISBN.Location = new Point(139, 150);
            txtISBN.Multiline = true;
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(359, 41);
            txtISBN.TabIndex = 25;
            // 
            // txtAuthor
            // 
            txtAuthor.BackColor = Color.WhiteSmoke;
            txtAuthor.BorderStyle = BorderStyle.None;
            txtAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAuthor.Location = new Point(663, 53);
            txtAuthor.Multiline = true;
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(341, 41);
            txtAuthor.TabIndex = 24;
            // 
            // lblPages
            // 
            lblPages.AutoSize = true;
            lblPages.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPages.ForeColor = Color.Black;
            lblPages.Location = new Point(27, 458);
            lblPages.Name = "lblPages";
            lblPages.Size = new Size(66, 28);
            lblPages.TabIndex = 23;
            lblPages.Text = "Pages:";
            // 
            // lblStockQuant
            // 
            lblStockQuant.AutoSize = true;
            lblStockQuant.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStockQuant.ForeColor = Color.Black;
            lblStockQuant.Location = new Point(533, 362);
            lblStockQuant.Name = "lblStockQuant";
            lblStockQuant.Size = new Size(64, 28);
            lblStockQuant.TabIndex = 22;
            lblStockQuant.Text = "Stock:";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGenre.ForeColor = Color.Black;
            lblGenre.Location = new Point(542, 255);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(68, 28);
            lblGenre.TabIndex = 21;
            lblGenre.Text = "Genre:";
            // 
            // lblPublishDate
            // 
            lblPublishDate.AutoSize = true;
            lblPublishDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPublishDate.ForeColor = Color.Black;
            lblPublishDate.Location = new Point(516, 162);
            lblPublishDate.Name = "lblPublishDate";
            lblPublishDate.Size = new Size(123, 28);
            lblPublishDate.TabIndex = 20;
            lblPublishDate.Text = "Publish date:";
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.WhiteSmoke;
            txtTitle.BorderStyle = BorderStyle.None;
            txtTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(139, 49);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(359, 41);
            txtTitle.TabIndex = 14;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuthor.ForeColor = Color.Black;
            lblAuthor.Location = new Point(533, 66);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(77, 28);
            lblAuthor.TabIndex = 19;
            lblAuthor.Text = "Author:";
            // 
            // lblImage
            // 
            lblImage.AutoSize = true;
            lblImage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblImage.ForeColor = Color.Black;
            lblImage.Location = new Point(27, 564);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(70, 28);
            lblImage.TabIndex = 18;
            lblImage.Text = "Image:";
            // 
            // lblLanuage
            // 
            lblLanuage.AutoSize = true;
            lblLanuage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLanuage.ForeColor = Color.Black;
            lblLanuage.Location = new Point(27, 362);
            lblLanuage.Name = "lblLanuage";
            lblLanuage.Size = new Size(101, 28);
            lblLanuage.TabIndex = 17;
            lblLanuage.Text = "Language:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.Black;
            lblPrice.Location = new Point(27, 255);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(58, 28);
            lblPrice.TabIndex = 16;
            lblPrice.Text = "Price:";
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblISBN.ForeColor = Color.Black;
            lblISBN.Location = new Point(27, 163);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(58, 28);
            lblISBN.TabIndex = 15;
            lblISBN.Text = "ISBN:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(27, 62);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(53, 28);
            lblTitle.TabIndex = 13;
            lblTitle.Text = "Title:";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(130, 76, 113);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(918, 39);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 41);
            btnClose.TabIndex = 91;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // numPageAmount
            // 
            numPageAmount.BackColor = Color.WhiteSmoke;
            numPageAmount.BorderStyle = BorderStyle.None;
            numPageAmount.Font = new Font("Segoe UI", 12F);
            numPageAmount.Location = new Point(139, 468);
            numPageAmount.Margin = new Padding(3, 4, 3, 4);
            numPageAmount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPageAmount.Name = "numPageAmount";
            numPageAmount.Size = new Size(359, 30);
            numPageAmount.TabIndex = 94;
            numPageAmount.ThousandsSeparator = true;
            // 
            // AddPhysical
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 812);
            Controls.Add(btnClose);
            Controls.Add(pnlAudio);
            Controls.Add(pbPhysical);
            Controls.Add(lblPhysical2);
            Controls.Add(lblPhysical);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddPhysical";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddPhysical";
            ((System.ComponentModel.ISupportInitialize)pbPhysical).EndInit();
            pnlAudio.ResumeLayout(false);
            pnlAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbMoney).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPageAmount).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbPhysical;
        private Label lblPhysical2;
        private Label lblPhysical;
        private Panel pnlAudio;
        private PictureBox pbMoney;
        private Button btnAddPhysicalBook;
        private Button btnSelectImg;
        private DateTimePicker dtpPublish;
        private ComboBox cmbGenre;
        private NumericUpDown numPrice;
        private NumericUpDown numStock;
        private Label lblDimensions;
        private TextBox txtDimensions;
        private TextBox txtFilePath;
        private TextBox txtLanguage;
        private TextBox txtISBN;
        private TextBox txtAuthor;
        private Label lblPages;
        private Label lblStockQuant;
        private Label lblGenre;
        private Label lblPublishDate;
        private TextBox txtTitle;
        private Label lblAuthor;
        private Label lblImage;
        private Label lblLanuage;
        private Label lblPrice;
        private Label lblISBN;
        private Label lblTitle;
        private Button btnClose;
        private Label lblCoverType;
        private TextBox txtCoverType;
        private NumericUpDown numPageAmount;
    }
}