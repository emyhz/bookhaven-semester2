namespace BookHavenDesktop.Forms.MainPages
{
    partial class Products
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
            flpProducts = new FlowLayoutPanel();
            label3 = new Label();
            cmbGenre = new ComboBox();
            lblProducts = new Label();
            pnlClient = new Panel();
            btnSearchProduct = new Button();
            txtISBNSearch = new TextBox();
            txtAuthorSearch = new TextBox();
            txtTitleSearch = new TextBox();
            lblISBNSearch = new Label();
            lblAuthorSearch = new Label();
            lblTitleSearch = new Label();
            lbl1 = new Label();
            btnAddNewAudio = new Button();
            panel1 = new Panel();
            label2 = new Label();
            btnAddPhysical = new Button();
            label1 = new Label();
            flpProducts.SuspendLayout();
            pnlClient.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flpProducts
            // 
            flpProducts.AutoScroll = true;
            flpProducts.BackColor = Color.White;
            flpProducts.Controls.Add(label3);
            flpProducts.Controls.Add(cmbGenre);
            flpProducts.Location = new Point(423, -2);
            flpProducts.Name = "flpProducts";
            flpProducts.Size = new Size(1201, 922);
            flpProducts.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(220, 204, 163);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(97, 46);
            label3.TabIndex = 89;
            label3.Text = "Sort:";
            // 
            // cmbGenre
            // 
            cmbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenre.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(106, 4);
            cmbGenre.Margin = new Padding(3, 4, 3, 4);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(341, 40);
            cmbGenre.TabIndex = 88;
            // 
            // lblProducts
            // 
            lblProducts.AutoSize = true;
            lblProducts.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProducts.ForeColor = Color.FromArgb(220, 204, 163);
            lblProducts.Location = new Point(26, 21);
            lblProducts.Name = "lblProducts";
            lblProducts.Size = new Size(118, 46);
            lblProducts.TabIndex = 4;
            lblProducts.Text = "Books";
            // 
            // pnlClient
            // 
            pnlClient.BackColor = Color.White;
            pnlClient.Controls.Add(btnSearchProduct);
            pnlClient.Controls.Add(txtISBNSearch);
            pnlClient.Controls.Add(txtAuthorSearch);
            pnlClient.Controls.Add(txtTitleSearch);
            pnlClient.Controls.Add(lblISBNSearch);
            pnlClient.Controls.Add(lblAuthorSearch);
            pnlClient.Controls.Add(lblTitleSearch);
            pnlClient.Controls.Add(lbl1);
            pnlClient.Location = new Point(26, 85);
            pnlClient.Name = "pnlClient";
            pnlClient.Size = new Size(355, 512);
            pnlClient.TabIndex = 5;
            // 
            // btnSearchProduct
            // 
            btnSearchProduct.BackColor = Color.FromArgb(220, 204, 163);
            btnSearchProduct.FlatAppearance.BorderSize = 0;
            btnSearchProduct.FlatStyle = FlatStyle.Flat;
            btnSearchProduct.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearchProduct.ForeColor = Color.White;
            btnSearchProduct.Location = new Point(22, 407);
            btnSearchProduct.Name = "btnSearchProduct";
            btnSearchProduct.Size = new Size(298, 50);
            btnSearchProduct.TabIndex = 20;
            btnSearchProduct.Text = "Search book";
            btnSearchProduct.UseVisualStyleBackColor = false;
            btnSearchProduct.Click += btnSearchProduct_Click;
            // 
            // txtISBNSearch
            // 
            txtISBNSearch.BackColor = Color.WhiteSmoke;
            txtISBNSearch.BorderStyle = BorderStyle.None;
            txtISBNSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtISBNSearch.Location = new Point(22, 318);
            txtISBNSearch.Multiline = true;
            txtISBNSearch.Name = "txtISBNSearch";
            txtISBNSearch.Size = new Size(298, 41);
            txtISBNSearch.TabIndex = 19;
            // 
            // txtAuthorSearch
            // 
            txtAuthorSearch.BackColor = Color.WhiteSmoke;
            txtAuthorSearch.BorderStyle = BorderStyle.None;
            txtAuthorSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAuthorSearch.Location = new Point(21, 206);
            txtAuthorSearch.Multiline = true;
            txtAuthorSearch.Name = "txtAuthorSearch";
            txtAuthorSearch.Size = new Size(298, 41);
            txtAuthorSearch.TabIndex = 18;
            // 
            // txtTitleSearch
            // 
            txtTitleSearch.BackColor = Color.WhiteSmoke;
            txtTitleSearch.BorderStyle = BorderStyle.None;
            txtTitleSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitleSearch.Location = new Point(21, 110);
            txtTitleSearch.Multiline = true;
            txtTitleSearch.Name = "txtTitleSearch";
            txtTitleSearch.Size = new Size(298, 41);
            txtTitleSearch.TabIndex = 17;
            // 
            // lblISBNSearch
            // 
            lblISBNSearch.AutoSize = true;
            lblISBNSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblISBNSearch.ForeColor = Color.Black;
            lblISBNSearch.Location = new Point(22, 287);
            lblISBNSearch.Name = "lblISBNSearch";
            lblISBNSearch.Size = new Size(58, 28);
            lblISBNSearch.TabIndex = 16;
            lblISBNSearch.Text = "ISBN:";
            // 
            // lblAuthorSearch
            // 
            lblAuthorSearch.AutoSize = true;
            lblAuthorSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuthorSearch.ForeColor = Color.Black;
            lblAuthorSearch.Location = new Point(22, 175);
            lblAuthorSearch.Name = "lblAuthorSearch";
            lblAuthorSearch.Size = new Size(77, 28);
            lblAuthorSearch.TabIndex = 15;
            lblAuthorSearch.Text = "Author:";
            // 
            // lblTitleSearch
            // 
            lblTitleSearch.AutoSize = true;
            lblTitleSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleSearch.ForeColor = Color.Black;
            lblTitleSearch.Location = new Point(22, 79);
            lblTitleSearch.Name = "lblTitleSearch";
            lblTitleSearch.Size = new Size(53, 28);
            lblTitleSearch.TabIndex = 14;
            lblTitleSearch.Text = "Title:";
            // 
            // lbl1
            // 
            lbl1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl1.ForeColor = Color.FromArgb(220, 204, 163);
            lbl1.Location = new Point(21, 23);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(191, 38);
            lbl1.TabIndex = 4;
            lbl1.Text = "Search for a book\r\n\r\n\r\n";
            // 
            // btnAddNewAudio
            // 
            btnAddNewAudio.BackColor = Color.FromArgb(220, 204, 163);
            btnAddNewAudio.FlatAppearance.BorderSize = 0;
            btnAddNewAudio.FlatStyle = FlatStyle.Flat;
            btnAddNewAudio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddNewAudio.ForeColor = Color.White;
            btnAddNewAudio.Location = new Point(22, 177);
            btnAddNewAudio.Name = "btnAddNewAudio";
            btnAddNewAudio.Size = new Size(298, 50);
            btnAddNewAudio.TabIndex = 21;
            btnAddNewAudio.Text = "Add new audiobook";
            btnAddNewAudio.UseVisualStyleBackColor = false;
            btnAddNewAudio.Click += btnAddNewAudio_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnAddPhysical);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnAddNewAudio);
            panel1.Location = new Point(26, 627);
            panel1.Name = "panel1";
            panel1.Size = new Size(355, 258);
            panel1.TabIndex = 22;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(144, 170, 134);
            label2.Location = new Point(33, 55);
            label2.Name = "label2";
            label2.Size = new Size(277, 38);
            label2.TabIndex = 24;
            label2.Text = "Select the type of book:";
            // 
            // btnAddPhysical
            // 
            btnAddPhysical.BackColor = Color.FromArgb(220, 204, 163);
            btnAddPhysical.FlatAppearance.BorderSize = 0;
            btnAddPhysical.FlatStyle = FlatStyle.Flat;
            btnAddPhysical.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddPhysical.ForeColor = Color.White;
            btnAddPhysical.Location = new Point(21, 111);
            btnAddPhysical.Name = "btnAddPhysical";
            btnAddPhysical.Size = new Size(298, 50);
            btnAddPhysical.TabIndex = 23;
            btnAddPhysical.Text = "Add new physical book";
            btnAddPhysical.UseVisualStyleBackColor = false;
            btnAddPhysical.Click += btnAddPhysical_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(220, 204, 163);
            label1.Location = new Point(33, 17);
            label1.Name = "label1";
            label1.Size = new Size(298, 38);
            label1.TabIndex = 22;
            label1.Text = "Want to add a new book?";
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(144, 170, 134);
            ClientSize = new Size(1622, 907);
            Controls.Add(panel1);
            Controls.Add(pnlClient);
            Controls.Add(lblProducts);
            Controls.Add(flpProducts);
            Name = "Products";
            Text = "Products";
            flpProducts.ResumeLayout(false);
            flpProducts.PerformLayout();
            pnlClient.ResumeLayout(false);
            pnlClient.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpProducts;
        private Label lblProducts;
        private Panel pnlClient;
        private Button btnSearchProduct;
        private TextBox txtISBNSearch;
        private TextBox txtAuthorSearch;
        private TextBox txtTitleSearch;
        private Label lblISBNSearch;
        private Label lblAuthorSearch;
        private Label lblTitleSearch;
        private Label lbl1;
        private Button btnAddNewAudio;
        private Panel panel1;
        private Label label1;
        private Button btnAddPhysical;
        private Label label2;
        private ComboBox cmbGenre;
        private Label label3;
    }
}