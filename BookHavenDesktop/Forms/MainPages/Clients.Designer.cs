namespace BookHavenDesktop.Forms.MainPages
{
    partial class Clients
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
            flpCustomer = new FlowLayoutPanel();
            pnlClient = new Panel();
            btnSearchClient = new Button();
            txtEmailSearch = new TextBox();
            txtLNameSearch = new TextBox();
            txtFNameSearch = new TextBox();
            lblEMail = new Label();
            lblLName = new Label();
            lblFname = new Label();
            lbl1 = new Label();
            lblCLients = new Label();
            pnlClient.SuspendLayout();
            SuspendLayout();
            // 
            // flpCustomer
            // 
            flpCustomer.AutoScroll = true;
            flpCustomer.BackColor = Color.White;
            flpCustomer.Location = new Point(426, -1);
            flpCustomer.Name = "flpCustomer";
            flpCustomer.Size = new Size(1201, 867);
            flpCustomer.TabIndex = 0;
            // 
            // pnlClient
            // 
            pnlClient.BackColor = Color.White;
            pnlClient.Controls.Add(btnSearchClient);
            pnlClient.Controls.Add(txtEmailSearch);
            pnlClient.Controls.Add(txtLNameSearch);
            pnlClient.Controls.Add(txtFNameSearch);
            pnlClient.Controls.Add(lblEMail);
            pnlClient.Controls.Add(lblLName);
            pnlClient.Controls.Add(lblFname);
            pnlClient.Controls.Add(lbl1);
            pnlClient.Location = new Point(24, 70);
            pnlClient.Name = "pnlClient";
            pnlClient.Size = new Size(355, 460);
            pnlClient.TabIndex = 1;
            // 
            // btnSearchClient
            // 
            btnSearchClient.BackColor = Color.FromArgb(130, 76, 113);
            btnSearchClient.FlatAppearance.BorderSize = 0;
            btnSearchClient.FlatStyle = FlatStyle.Flat;
            btnSearchClient.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearchClient.ForeColor = Color.White;
            btnSearchClient.Location = new Point(22, 389);
            btnSearchClient.Name = "btnSearchClient";
            btnSearchClient.Size = new Size(298, 50);
            btnSearchClient.TabIndex = 20;
            btnSearchClient.Text = "Search customer";
            btnSearchClient.UseVisualStyleBackColor = false;
            btnSearchClient.Click += btnSearchClient_Click;
            // 
            // txtEmailSearch
            // 
            txtEmailSearch.BackColor = Color.WhiteSmoke;
            txtEmailSearch.BorderStyle = BorderStyle.None;
            txtEmailSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmailSearch.Location = new Point(22, 318);
            txtEmailSearch.Multiline = true;
            txtEmailSearch.Name = "txtEmailSearch";
            txtEmailSearch.Size = new Size(298, 41);
            txtEmailSearch.TabIndex = 19;
            // 
            // txtLNameSearch
            // 
            txtLNameSearch.BackColor = Color.WhiteSmoke;
            txtLNameSearch.BorderStyle = BorderStyle.None;
            txtLNameSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLNameSearch.Location = new Point(21, 206);
            txtLNameSearch.Multiline = true;
            txtLNameSearch.Name = "txtLNameSearch";
            txtLNameSearch.Size = new Size(298, 41);
            txtLNameSearch.TabIndex = 18;
            // 
            // txtFNameSearch
            // 
            txtFNameSearch.BackColor = Color.WhiteSmoke;
            txtFNameSearch.BorderStyle = BorderStyle.None;
            txtFNameSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFNameSearch.Location = new Point(21, 110);
            txtFNameSearch.Multiline = true;
            txtFNameSearch.Name = "txtFNameSearch";
            txtFNameSearch.Size = new Size(298, 41);
            txtFNameSearch.TabIndex = 17;
            // 
            // lblEMail
            // 
            lblEMail.AutoSize = true;
            lblEMail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEMail.ForeColor = Color.Black;
            lblEMail.Location = new Point(22, 287);
            lblEMail.Name = "lblEMail";
            lblEMail.Size = new Size(63, 28);
            lblEMail.TabIndex = 16;
            lblEMail.Text = "Email:";
            // 
            // lblLName
            // 
            lblLName.AutoSize = true;
            lblLName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLName.ForeColor = Color.Black;
            lblLName.Location = new Point(22, 175);
            lblLName.Name = "lblLName";
            lblLName.Size = new Size(103, 28);
            lblLName.TabIndex = 15;
            lblLName.Text = "Last name:";
            // 
            // lblFname
            // 
            lblFname.AutoSize = true;
            lblFname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFname.ForeColor = Color.Black;
            lblFname.Location = new Point(22, 79);
            lblFname.Name = "lblFname";
            lblFname.Size = new Size(106, 28);
            lblFname.TabIndex = 14;
            lblFname.Text = "First name:";
            // 
            // lbl1
            // 
            lbl1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl1.ForeColor = Color.FromArgb(220, 204, 163);
            lbl1.Location = new Point(21, 23);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(235, 39);
            lbl1.TabIndex = 4;
            lbl1.Text = "Search for a customer\r\n\r\n";
            // 
            // lblCLients
            // 
            lblCLients.AutoSize = true;
            lblCLients.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCLients.ForeColor = Color.FromArgb(130, 76, 113);
            lblCLients.Location = new Point(24, 9);
            lblCLients.Name = "lblCLients";
            lblCLients.Size = new Size(174, 46);
            lblCLients.TabIndex = 3;
            lblCLients.Text = "Customer";
            // 
            // Clients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(233, 210, 224);
            ClientSize = new Size(1622, 907);
            Controls.Add(lblCLients);
            Controls.Add(pnlClient);
            Controls.Add(flpCustomer);
            Name = "Clients";
            Text = "Clients";
            pnlClient.ResumeLayout(false);
            pnlClient.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpCustomer;
        private Panel pnlClient;
        private Label lblCLients;
        private Label lbl1;
        private Label lblEMail;
        private Label lblLName;
        private Label lblFname;
        private TextBox txtEmailSearch;
        private TextBox txtLNameSearch;
        private TextBox txtFNameSearch;
        private Button btnSearchClient;
    }
}