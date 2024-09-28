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
            flpEmployees = new FlowLayoutPanel();
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
            panel2 = new Panel();
            lblEmailPending = new Label();
            btnDeny = new Button();
            btnApprove = new Button();
            cmbPendingEmployee = new ComboBox();
            lblApprove = new Label();
            label1 = new Label();
            cmbEmployeesFilter = new ComboBox();
            flpEmployees.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // flpEmployees
            // 
            flpEmployees.AutoScroll = true;
            flpEmployees.BackColor = Color.White;
            flpEmployees.Controls.Add(label1);
            flpEmployees.Controls.Add(cmbEmployeesFilter);
            flpEmployees.Location = new Point(432, -4);
            flpEmployees.Name = "flpEmployees";
            flpEmployees.Size = new Size(1194, 916);
            flpEmployees.TabIndex = 0;
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
            panel1.Location = new Point(37, 45);
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
            btnSearchEmployee.Click += btnSearchEmployee_Click;
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
            lblEmployees.Location = new Point(37, -4);
            lblEmployees.Name = "lblEmployees";
            lblEmployees.Size = new Size(190, 46);
            lblEmployees.TabIndex = 2;
            lblEmployees.Text = "Employees";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblEmailPending);
            panel2.Controls.Add(btnDeny);
            panel2.Controls.Add(btnApprove);
            panel2.Controls.Add(cmbPendingEmployee);
            panel2.Controls.Add(lblApprove);
            panel2.Location = new Point(37, 525);
            panel2.Name = "panel2";
            panel2.Size = new Size(355, 341);
            panel2.TabIndex = 3;
            // 
            // lblEmailPending
            // 
            lblEmailPending.AutoSize = true;
            lblEmailPending.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmailPending.ForeColor = Color.Black;
            lblEmailPending.Location = new Point(28, 142);
            lblEmailPending.Name = "lblEmailPending";
            lblEmailPending.Size = new Size(0, 28);
            lblEmailPending.TabIndex = 17;
            // 
            // btnDeny
            // 
            btnDeny.BackColor = Color.FromArgb(220, 204, 163);
            btnDeny.FlatAppearance.BorderSize = 0;
            btnDeny.FlatStyle = FlatStyle.Flat;
            btnDeny.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeny.ForeColor = Color.White;
            btnDeny.Location = new Point(28, 275);
            btnDeny.Name = "btnDeny";
            btnDeny.Size = new Size(298, 50);
            btnDeny.TabIndex = 47;
            btnDeny.Text = "Deny";
            btnDeny.UseVisualStyleBackColor = false;
            btnDeny.Click += btnDeny_Click;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.FromArgb(144, 170, 134);
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnApprove.ForeColor = Color.White;
            btnApprove.Location = new Point(28, 207);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(298, 50);
            btnApprove.TabIndex = 17;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // cmbPendingEmployee
            // 
            cmbPendingEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPendingEmployee.Font = new Font("Segoe UI", 13F);
            cmbPendingEmployee.FormattingEnabled = true;
            cmbPendingEmployee.Location = new Point(15, 79);
            cmbPendingEmployee.Margin = new Padding(3, 4, 3, 4);
            cmbPendingEmployee.Name = "cmbPendingEmployee";
            cmbPendingEmployee.Size = new Size(325, 38);
            cmbPendingEmployee.TabIndex = 46;
            cmbPendingEmployee.SelectedIndexChanged += cmbPendingEmployee_SelectedIndexChanged;
            // 
            // lblApprove
            // 
            lblApprove.AutoSize = true;
            lblApprove.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblApprove.ForeColor = Color.FromArgb(220, 204, 163);
            lblApprove.Location = new Point(15, 27);
            lblApprove.Name = "lblApprove";
            lblApprove.Size = new Size(317, 31);
            lblApprove.TabIndex = 4;
            lblApprove.Text = "Approve a pending employee\r\n";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(130, 76, 113);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(113, 46);
            label1.TabIndex = 4;
            label1.Text = "Filter:";
            // 
            // cmbEmployeesFilter
            // 
            cmbEmployeesFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployeesFilter.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEmployeesFilter.FormattingEnabled = true;
            cmbEmployeesFilter.Location = new Point(122, 4);
            cmbEmployeesFilter.Margin = new Padding(3, 4, 3, 4);
            cmbEmployeesFilter.Name = "cmbEmployeesFilter";
            cmbEmployeesFilter.Size = new Size(341, 40);
            cmbEmployeesFilter.TabIndex = 89;
            // 
            // Employees
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(233, 210, 224);
            ClientSize = new Size(1622, 907);
            Controls.Add(panel2);
            Controls.Add(lblEmployees);
            Controls.Add(panel1);
            Controls.Add(flpEmployees);
            Name = "Employees";
            Text = "Employees";
            flpEmployees.ResumeLayout(false);
            flpEmployees.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpEmployees;
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
        private Panel panel2;
        private ComboBox cmbPendingEmployee;
        private Label lblApprove;
        private Label lblEmailPending;
        private Button btnDeny;
        private Button btnApprove;
        private Label label1;
        private ComboBox cmbEmployeesFilter;
    }
}