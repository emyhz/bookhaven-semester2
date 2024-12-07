namespace BookHavenDesktop.UserControls
{
    partial class BestSellerBooks
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
            pnlDetails = new Panel();
            lblSold = new Label();
            lblAuthor = new Label();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)pbBook).BeginInit();
            pnlDetails.SuspendLayout();
            SuspendLayout();
            // 
            // pbBook
            // 
            pbBook.Location = new Point(0, -10);
            pbBook.Name = "pbBook";
            pbBook.Size = new Size(224, 302);
            pbBook.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBook.TabIndex = 0;
            pbBook.TabStop = false;
            // 
            // pnlDetails
            // 
            pnlDetails.BackColor = Color.White;
            pnlDetails.Controls.Add(lblSold);
            pnlDetails.Controls.Add(lblAuthor);
            pnlDetails.Controls.Add(lblTitle);
            pnlDetails.Location = new Point(227, 50);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(216, 201);
            pnlDetails.TabIndex = 1;
            // 
            // lblSold
            // 
            lblSold.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSold.AutoSize = true;
            lblSold.Font = new Font("Segoe UI", 12F);
            lblSold.ForeColor = Color.Gray;
            lblSold.Location = new Point(3, 116);
            lblSold.MaximumSize = new Size(229, 0);
            lblSold.Name = "lblSold";
            lblSold.Size = new Size(76, 28);
            lblSold.TabIndex = 43;
            lblSold.Text = "30 sold";
            // 
            // lblAuthor
            // 
            lblAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuthor.ForeColor = Color.Black;
            lblAuthor.Location = new Point(3, 68);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(210, 39);
            lblAuthor.TabIndex = 23;
            lblAuthor.Text = "Author";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(3, 15);
            lblTitle.MaximumSize = new Size(286, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(210, 53);
            lblTitle.TabIndex = 18;
            lblTitle.Text = "Title";
            // 
            // BestSellerBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlDetails);
            Controls.Add(pbBook);
            Name = "BestSellerBooks";
            Size = new Size(446, 293);
            ((System.ComponentModel.ISupportInitialize)pbBook).EndInit();
            pnlDetails.ResumeLayout(false);
            pnlDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbBook;
        private Panel pnlDetails;
        private Label lblTitle;
        private Label lblSold;
        private Label lblAuthor;
    }
}
