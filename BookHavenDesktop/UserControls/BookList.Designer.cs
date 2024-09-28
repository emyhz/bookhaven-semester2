namespace BookHavenDesktop.UserControls
{
    partial class BookList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookList));
            pbBook = new PictureBox();
            lblTitle = new Label();
            lblAuthor = new Label();
            lblPrice = new Label();
            pnlBook = new Panel();
            pbMoney = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbBook).BeginInit();
            pnlBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbMoney).BeginInit();
            SuspendLayout();
            // 
            // pbBook
            // 
            pbBook.Location = new Point(37, 0);
            pbBook.Name = "pbBook";
            pbBook.Size = new Size(218, 282);
            pbBook.SizeMode = PictureBoxSizeMode.CenterImage;
            pbBook.TabIndex = 0;
            pbBook.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(17, 285);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(262, 73);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Title";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuthor.ForeColor = Color.Black;
            lblAuthor.Location = new Point(17, 358);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(73, 28);
            lblAuthor.TabIndex = 8;
            lblAuthor.Text = "Author";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.Black;
            lblPrice.Location = new Point(52, 412);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(54, 28);
            lblPrice.TabIndex = 9;
            lblPrice.Text = "Price";
            // 
            // pnlBook
            // 
            pnlBook.BackColor = Color.WhiteSmoke;
            pnlBook.Controls.Add(pbBook);
            pnlBook.Location = new Point(0, 0);
            pnlBook.Name = "pnlBook";
            pnlBook.Size = new Size(304, 282);
            pnlBook.TabIndex = 11;
            // 
            // pbMoney
            // 
            pbMoney.Image = (Image)resources.GetObject("pbMoney.Image");
            pbMoney.Location = new Point(17, 415);
            pbMoney.Name = "pbMoney";
            pbMoney.Size = new Size(32, 25);
            pbMoney.TabIndex = 92;
            pbMoney.TabStop = false;
            // 
            // BookList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(pbMoney);
            Controls.Add(pnlBook);
            Controls.Add(lblPrice);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            Name = "BookList";
            Size = new Size(304, 461);
            Click += BookList_Click;
            ((System.ComponentModel.ISupportInitialize)pbBook).EndInit();
            pnlBook.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbMoney).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbBook;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblPrice;
        private Panel pnlBook;
        private PictureBox pbMoney;
    }
}
