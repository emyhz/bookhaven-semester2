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
            pbBook = new PictureBox();
            lblTitle = new Label();
            lblAuthor = new Label();
            lblPrice = new Label();
            pnlBook = new Panel();
            ((System.ComponentModel.ISupportInitialize)pbBook).BeginInit();
            pnlBook.SuspendLayout();
            SuspendLayout();
            // 
            // pbBook
            // 
            pbBook.Location = new Point(57, 27);
            pbBook.Name = "pbBook";
            pbBook.Size = new Size(218, 184);
            pbBook.TabIndex = 0;
            pbBook.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(22, 239);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(62, 31);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Title";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuthor.ForeColor = Color.Black;
            lblAuthor.Location = new Point(22, 292);
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
            lblPrice.Location = new Point(22, 346);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(54, 28);
            lblPrice.TabIndex = 9;
            lblPrice.Text = "Price";
            // 
            // pnlBook
            // 
            pnlBook.BackColor = SystemColors.Control;
            pnlBook.Controls.Add(pbBook);
            pnlBook.Location = new Point(0, 0);
            pnlBook.Name = "pnlBook";
            pnlBook.Size = new Size(350, 227);
            pnlBook.TabIndex = 11;
            // 
            // BookList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlBook);
            Controls.Add(lblPrice);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            Name = "BookList";
            Size = new Size(350, 461);
            ((System.ComponentModel.ISupportInitialize)pbBook).EndInit();
            pnlBook.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbBook;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblPrice;
        private Panel pnlBook;
    }
}
