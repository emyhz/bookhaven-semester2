namespace BookHavenDesktop.Forms.MainPages
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            btnLogOut = new Button();
            lblAccessHead = new Label();
            pictureBox1 = new PictureBox();
            flpMainPage = new FlowLayoutPanel();
            btnHome = new Button();
            btnProducts = new Button();
            btnOrders = new Button();
            btnEmployees = new Button();
            btnClients = new Button();
            btnMyAccount = new Button();
            pnlMainForm = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flpMainPage.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnLogOut);
            panel1.Controls.Add(lblAccessHead);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1930, 110);
            panel1.TabIndex = 0;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(130, 76, 113);
            btnLogOut.FlatAppearance.BorderSize = 0;
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogOut.ForeColor = Color.White;
            btnLogOut.Location = new Point(1692, 24);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(200, 58);
            btnLogOut.TabIndex = 4;
            btnLogOut.Text = "Log out";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // lblAccessHead
            // 
            lblAccessHead.AutoSize = true;
            lblAccessHead.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAccessHead.ForeColor = Color.FromArgb(130, 76, 113);
            lblAccessHead.Location = new Point(124, 36);
            lblAccessHead.Name = "lblAccessHead";
            lblAccessHead.Size = new Size(204, 46);
            lblAccessHead.TabIndex = 3;
            lblAccessHead.Text = "BookHaven";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(112, 92);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // flpMainPage
            // 
            flpMainPage.BackColor = Color.FromArgb(130, 76, 113);
            flpMainPage.Controls.Add(btnHome);
            flpMainPage.Controls.Add(btnProducts);
            flpMainPage.Controls.Add(btnOrders);
            flpMainPage.Controls.Add(btnEmployees);
            flpMainPage.Controls.Add(btnClients);
            flpMainPage.Controls.Add(btnMyAccount);
            flpMainPage.Location = new Point(0, 110);
            flpMainPage.Name = "flpMainPage";
            flpMainPage.Size = new Size(293, 954);
            flpMainPage.TabIndex = 1;
            // 
            // btnHome
            // 
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.White;
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.Location = new Point(0, 0);
            btnHome.Margin = new Padding(0);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(290, 70);
            btnHome.TabIndex = 0;
            btnHome.Text = "Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnProducts
            // 
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProducts.ForeColor = Color.White;
            btnProducts.Image = (Image)resources.GetObject("btnProducts.Image");
            btnProducts.ImageAlign = ContentAlignment.MiddleLeft;
            btnProducts.Location = new Point(0, 70);
            btnProducts.Margin = new Padding(0);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(290, 70);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "Books";
            btnProducts.TextAlign = ContentAlignment.MiddleLeft;
            btnProducts.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnOrders
            // 
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOrders.ForeColor = Color.White;
            btnOrders.Image = (Image)resources.GetObject("btnOrders.Image");
            btnOrders.ImageAlign = ContentAlignment.MiddleLeft;
            btnOrders.Location = new Point(0, 140);
            btnOrders.Margin = new Padding(0);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(290, 70);
            btnOrders.TabIndex = 2;
            btnOrders.Text = "Orders";
            btnOrders.TextAlign = ContentAlignment.MiddleLeft;
            btnOrders.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += btnOrders_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.FlatAppearance.BorderSize = 0;
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEmployees.ForeColor = Color.White;
            btnEmployees.Image = (Image)resources.GetObject("btnEmployees.Image");
            btnEmployees.ImageAlign = ContentAlignment.MiddleLeft;
            btnEmployees.Location = new Point(0, 210);
            btnEmployees.Margin = new Padding(0);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(290, 70);
            btnEmployees.TabIndex = 3;
            btnEmployees.Text = "Employees";
            btnEmployees.TextAlign = ContentAlignment.MiddleLeft;
            btnEmployees.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmployees.UseVisualStyleBackColor = true;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // btnClients
            // 
            btnClients.FlatAppearance.BorderSize = 0;
            btnClients.FlatStyle = FlatStyle.Flat;
            btnClients.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClients.ForeColor = Color.White;
            btnClients.Image = (Image)resources.GetObject("btnClients.Image");
            btnClients.ImageAlign = ContentAlignment.MiddleLeft;
            btnClients.Location = new Point(0, 280);
            btnClients.Margin = new Padding(0);
            btnClients.Name = "btnClients";
            btnClients.Size = new Size(290, 70);
            btnClients.TabIndex = 4;
            btnClients.Text = "Clients";
            btnClients.TextAlign = ContentAlignment.MiddleLeft;
            btnClients.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClients.UseVisualStyleBackColor = true;
            btnClients.Click += btnClients_Click;
            // 
            // btnMyAccount
            // 
            btnMyAccount.FlatAppearance.BorderSize = 0;
            btnMyAccount.FlatStyle = FlatStyle.Flat;
            btnMyAccount.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMyAccount.ForeColor = Color.White;
            btnMyAccount.Image = (Image)resources.GetObject("btnMyAccount.Image");
            btnMyAccount.ImageAlign = ContentAlignment.MiddleLeft;
            btnMyAccount.Location = new Point(0, 350);
            btnMyAccount.Margin = new Padding(0);
            btnMyAccount.Name = "btnMyAccount";
            btnMyAccount.Size = new Size(290, 70);
            btnMyAccount.TabIndex = 5;
            btnMyAccount.Text = "My Account";
            btnMyAccount.TextAlign = ContentAlignment.MiddleLeft;
            btnMyAccount.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMyAccount.UseVisualStyleBackColor = true;
            btnMyAccount.Click += btnMyAccount_Click;
            // 
            // pnlMainForm
            // 
            pnlMainForm.BackColor = Color.FromArgb(233, 210, 224);
            pnlMainForm.Location = new Point(290, 110);
            pnlMainForm.Name = "pnlMainForm";
            pnlMainForm.Size = new Size(1640, 954);
            pnlMainForm.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(pnlMainForm);
            Controls.Add(flpMainPage);
            Controls.Add(panel1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flpMainPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label lblAccessHead;
        private FlowLayoutPanel flpMainPage;
        private Button btnHome;
        private Panel pnlMainForm;
        private Button btnProducts;
        private Button btnOrders;
        private Button btnEmployees;
        private Button btnClients;
        private Button btnMyAccount;
        private Button btnLogOut;
    }
}