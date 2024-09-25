namespace BookHavenDesktop.Forms.PopUpForms
{
    partial class AddAudio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAudio));
            lblAudio = new Label();
            lblAudio2 = new Label();
            pbAudio = new PictureBox();
            lblTitle = new Label();
            lblISBN = new Label();
            lblPrice = new Label();
            lblLanuage = new Label();
            lblImage = new Label();
            lblAuthor = new Label();
            txtTitle = new TextBox();
            lblPublishDate = new Label();
            lblGenre = new Label();
            lblStockQuant = new Label();
            lblAudioLength = new Label();
            txtAuthor = new TextBox();
            txtISBN = new TextBox();
            txtLanguage = new TextBox();
            txtFilePath = new TextBox();
            AudioLength = new TextBox();
            lblFileSize = new Label();
            txtFileSize = new TextBox();
            numStock = new NumericUpDown();
            numPrice = new NumericUpDown();
            cmbGenre = new ComboBox();
            dtpPublish = new DateTimePicker();
            btnSelectImg = new Button();
            btnAddAudioBook = new Button();
            pnlAudio = new Panel();
            pbMoney = new PictureBox();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)pbAudio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            pnlAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbMoney).BeginInit();
            SuspendLayout();
            // 
            // lblAudio
            // 
            lblAudio.AutoSize = true;
            lblAudio.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAudio.ForeColor = Color.FromArgb(220, 204, 163);
            lblAudio.Location = new Point(59, 24);
            lblAudio.Name = "lblAudio";
            lblAudio.Size = new Size(370, 46);
            lblAudio.TabIndex = 5;
            lblAudio.Text = "Add a new audiobook\r\n";
            // 
            // lblAudio2
            // 
            lblAudio2.AutoSize = true;
            lblAudio2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAudio2.ForeColor = Color.Black;
            lblAudio2.Location = new Point(59, 70);
            lblAudio2.Name = "lblAudio2";
            lblAudio2.Size = new Size(309, 28);
            lblAudio2.TabIndex = 14;
            lblAudio2.Text = "Enter the details of the audiobook\r\n";
            // 
            // pbAudio
            // 
            pbAudio.Image = (Image)resources.GetObject("pbAudio.Image");
            pbAudio.Location = new Point(1046, 36);
            pbAudio.Name = "pbAudio";
            pbAudio.Size = new Size(68, 62);
            pbAudio.TabIndex = 15;
            pbAudio.TabStop = false;
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
            // lblAudioLength
            // 
            lblAudioLength.AutoSize = true;
            lblAudioLength.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAudioLength.ForeColor = Color.Black;
            lblAudioLength.Location = new Point(533, 458);
            lblAudioLength.Name = "lblAudioLength";
            lblAudioLength.Size = new Size(130, 28);
            lblAudioLength.TabIndex = 23;
            lblAudioLength.Text = "Audio length:";
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
            // txtFilePath
            // 
            txtFilePath.BackColor = Color.WhiteSmoke;
            txtFilePath.BorderStyle = BorderStyle.None;
            txtFilePath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilePath.Location = new Point(139, 551);
            txtFilePath.Multiline = true;
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(359, 41);
            txtFilePath.TabIndex = 31;
            // 
            // AudioLength
            // 
            AudioLength.BackColor = Color.WhiteSmoke;
            AudioLength.BorderStyle = BorderStyle.None;
            AudioLength.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AudioLength.Location = new Point(663, 445);
            AudioLength.Multiline = true;
            AudioLength.Name = "AudioLength";
            AudioLength.Size = new Size(341, 41);
            AudioLength.TabIndex = 32;
            // 
            // lblFileSize
            // 
            lblFileSize.AutoSize = true;
            lblFileSize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFileSize.ForeColor = Color.Black;
            lblFileSize.Location = new Point(27, 458);
            lblFileSize.Name = "lblFileSize";
            lblFileSize.Size = new Size(83, 28);
            lblFileSize.TabIndex = 33;
            lblFileSize.Text = "File size:";
            // 
            // txtFileSize
            // 
            txtFileSize.BackColor = Color.WhiteSmoke;
            txtFileSize.BorderStyle = BorderStyle.None;
            txtFileSize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFileSize.Location = new Point(139, 445);
            txtFileSize.Multiline = true;
            txtFileSize.Name = "txtFileSize";
            txtFileSize.Size = new Size(359, 41);
            txtFileSize.TabIndex = 34;
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
            // dtpPublish
            // 
            dtpPublish.CalendarFont = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpPublish.Font = new Font("Segoe UI", 11.25F);
            dtpPublish.Location = new Point(663, 163);
            dtpPublish.Name = "dtpPublish";
            dtpPublish.Size = new Size(341, 32);
            dtpPublish.TabIndex = 88;
            // 
            // btnSelectImg
            // 
            btnSelectImg.BackColor = Color.FromArgb(130, 76, 113);
            btnSelectImg.FlatAppearance.BorderSize = 0;
            btnSelectImg.FlatStyle = FlatStyle.Flat;
            btnSelectImg.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSelectImg.ForeColor = Color.White;
            btnSelectImg.Location = new Point(504, 551);
            btnSelectImg.Name = "btnSelectImg";
            btnSelectImg.Size = new Size(140, 41);
            btnSelectImg.TabIndex = 89;
            btnSelectImg.Text = "Select image";
            btnSelectImg.UseVisualStyleBackColor = false;
            btnSelectImg.Click += btnSelectImg_Click;
            // 
            // btnAddAudioBook
            // 
            btnAddAudioBook.BackColor = Color.FromArgb(144, 170, 134);
            btnAddAudioBook.FlatAppearance.BorderSize = 0;
            btnAddAudioBook.FlatStyle = FlatStyle.Flat;
            btnAddAudioBook.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddAudioBook.ForeColor = Color.White;
            btnAddAudioBook.Location = new Point(27, 645);
            btnAddAudioBook.Name = "btnAddAudioBook";
            btnAddAudioBook.Size = new Size(977, 41);
            btnAddAudioBook.TabIndex = 90;
            btnAddAudioBook.Text = "Add audiobook";
            btnAddAudioBook.UseVisualStyleBackColor = false;
            btnAddAudioBook.Click += btnAddAudioBook_Click;
            // 
            // pnlAudio
            // 
            pnlAudio.BackColor = Color.White;
            pnlAudio.Controls.Add(pbMoney);
            pnlAudio.Controls.Add(btnAddAudioBook);
            pnlAudio.Controls.Add(btnSelectImg);
            pnlAudio.Controls.Add(dtpPublish);
            pnlAudio.Controls.Add(cmbGenre);
            pnlAudio.Controls.Add(numPrice);
            pnlAudio.Controls.Add(numStock);
            pnlAudio.Controls.Add(txtFileSize);
            pnlAudio.Controls.Add(lblFileSize);
            pnlAudio.Controls.Add(AudioLength);
            pnlAudio.Controls.Add(txtFilePath);
            pnlAudio.Controls.Add(txtLanguage);
            pnlAudio.Controls.Add(txtISBN);
            pnlAudio.Controls.Add(txtAuthor);
            pnlAudio.Controls.Add(lblAudioLength);
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
            pnlAudio.Location = new Point(59, 112);
            pnlAudio.Name = "pnlAudio";
            pnlAudio.Size = new Size(1064, 715);
            pnlAudio.TabIndex = 0;
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
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(130, 76, 113);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(911, 57);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 41);
            btnClose.TabIndex = 90;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // AddAudio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1187, 859);
            Controls.Add(btnClose);
            Controls.Add(pbAudio);
            Controls.Add(lblAudio2);
            Controls.Add(lblAudio);
            Controls.Add(pnlAudio);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddAudio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddAudio";
            ((System.ComponentModel.ISupportInitialize)pbAudio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            pnlAudio.ResumeLayout(false);
            pnlAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbMoney).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblAudio;
        private Label lblAudio2;
        private PictureBox pbAudio;
        private Label lblTitle;
        private Label lblISBN;
        private Label lblPrice;
        private Label lblLanuage;
        private Label lblImage;
        private Label lblAuthor;
        private TextBox txtTitle;
        private Label lblPublishDate;
        private Label lblGenre;
        private Label lblStockQuant;
        private Label lblAudioLength;
        private TextBox txtAuthor;
        private TextBox txtISBN;
        private TextBox txtLanguage;
        private TextBox txtFilePath;
        private TextBox AudioLength;
        private Label lblFileSize;
        private TextBox txtFileSize;
        private NumericUpDown numStock;
        private NumericUpDown numPrice;
        private ComboBox cmbGenre;
        private DateTimePicker dtpPublish;
        private Button btnSelectImg;
        private Button btnAddAudioBook;
        private Panel pnlAudio;
        private PictureBox pbMoney;
        private Button btnClose;
        private TextBox textBox7;
        private TextBox textBox5;
        private TextBox textBox4;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}