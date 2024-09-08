namespace BookHavenDesktop.Forms.MainPages
{
    partial class Employees
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            lblEmail = new Label();
            lblLName = new Label();
            lblFname = new Label();
            txtEmailSearch = new TextBox();
            txtLNameSearch = new TextBox();
            txtFNameSearch = new TextBox();
            btnSearchEmployee = new Button();
            lbl1 = new Label();
            lblEmployees = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Location = new Point(432, -4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1194, 916);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(lblLName);
            panel1.Controls.Add(lblFname);
            panel1.Controls.Add(txtEmailSearch);
            panel1.Controls.Add(txtLNameSearch);
            panel1.Controls.Add(txtFNameSearch);
            panel1.Controls.Add(btnSearchEmployee);
            panel1.Controls.Add(lbl1);
            panel1.Location = new Point(37, 72);
            panel1.Name = "panel1";
            panel1.Size = new Size(355, 460);
            panel1.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(28, 282);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(63, 28);
            lblEmail.TabIndex = 16;
            lblEmail.Text = "Email:";
            // 
            // lblLName
            // 
            lblLName.AutoSize = true;
            lblLName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLName.ForeColor = Color.Black;
            lblLName.Location = new Point(28, 179);
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
            lblFname.Location = new Point(28, 92);
            lblFname.Name = "lblFname";
            lblFname.Size = new Size(106, 28);
            lblFname.TabIndex = 13;
            lblFname.Text = "First name:";
            // 
            // txtEmailSearch
            // 
            txtEmailSearch.BackColor = Color.WhiteSmoke;
            txtEmailSearch.BorderStyle = BorderStyle.None;
            txtEmailSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmailSearch.Location = new Point(28, 313);
            txtEmailSearch.Multiline = true;
            txtEmailSearch.Name = "txtEmailSearch";
            txtEmailSearch.Size = new Size(298, 41);
            txtEmailSearch.TabIndex = 14;
            // 
            // txtLNameSearch
            // 
            txtLNameSearch.BackColor = Color.WhiteSmoke;
            txtLNameSearch.BorderStyle = BorderStyle.None;
            txtLNameSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLNameSearch.Location = new Point(28, 210);
            txtLNameSearch.Multiline = true;
            txtLNameSearch.Name = "txtLNameSearch";
            txtLNameSearch.Size = new Size(298, 41);
            txtLNameSearch.TabIndex = 13;
            // 
            // txtFNameSearch
            // 
            txtFNameSearch.BackColor = Color.WhiteSmoke;
            txtFNameSearch.BorderStyle = BorderStyle.None;
            txtFNameSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFNameSearch.Location = new Point(28, 123);
            txtFNameSearch.Multiline = true;
            txtFNameSearch.Name = "txtFNameSearch";
            txtFNameSearch.Size = new Size(298, 41);
            txtFNameSearch.TabIndex = 10;
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.BackColor = Color.FromArgb(130, 76, 113);
            btnSearchEmployee.FlatAppearance.BorderSize = 0;
            btnSearchEmployee.FlatStyle = FlatStyle.Flat;
            btnSearchEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearchEmployee.ForeColor = Color.White;
            btnSearchEmployee.Location = new Point(28, 381);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Size = new Size(298, 50);
            btnSearchEmployee.TabIndex = 12;
            btnSearchEmployee.Text = "Search employee";
            btnSearchEmployee.UseVisualStyleBackColor = false;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl1.ForeColor = Color.FromArgb(220, 204, 163);
            lbl1.Location = new Point(15, 26);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(253, 31);
            lbl1.TabIndex = 3;
            lbl1.Text = "Search for an employee";
            // 
            // lblEmployees
            // 
            lblEmployees.AutoSize = true;
            lblEmployees.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmployees.ForeColor = Color.FromArgb(130, 76, 113);
            lblEmployees.Location = new Point(37, 9);
            lblEmployees.Name = "lblEmployees";
            lblEmployees.Size = new Size(190, 46);
            lblEmployees.TabIndex = 2;
            lblEmployees.Text = "Employees";
            // 
            // Employees
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(233, 210, 224);
            ClientSize = new Size(1622, 907);
            Controls.Add(lblEmployees);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            Name = "Employees";
            Text = "Employees";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Label lbl1;
        private Label lblEmployees;
        private Button btnSearchEmployee;
        private TextBox txtEmailSearch;
        private TextBox txtLNameSearch;
        private TextBox txtFNameSearch;
        private Label lblFname;
        private Label lblEmail;
        private Label lblLName;
    }
}