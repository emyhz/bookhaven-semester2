namespace BookHavenDesktop.Forms.PopUpForms
{
    partial class EditDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDetails));
            pictureBox2 = new PictureBox();
            lblSlogan = new Label();
            lblUserDetailsChange = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtLName = new TextBox();
            lblLastName = new Label();
            txtFName = new TextBox();
            lblFirstName = new Label();
            btnChangeDetails = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(501, 36);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(104, 88);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 26;
            pictureBox2.TabStop = false;
            // 
            // lblSlogan
            // 
            lblSlogan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSlogan.ForeColor = Color.Black;
            lblSlogan.Location = new Point(45, 77);
            lblSlogan.Name = "lblSlogan";
            lblSlogan.Size = new Size(302, 28);
            lblSlogan.TabIndex = 25;
            lblSlogan.Text = "Change your name and email\r\n";
            // 
            // lblUserDetailsChange
            // 
            lblUserDetailsChange.AutoSize = true;
            lblUserDetailsChange.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserDetailsChange.ForeColor = Color.FromArgb(130, 76, 113);
            lblUserDetailsChange.Location = new Point(34, 36);
            lblUserDetailsChange.Name = "lblUserDetailsChange";
            lblUserDetailsChange.Size = new Size(298, 41);
            lblUserDetailsChange.TabIndex = 24;
            lblUserDetailsChange.Text = "Change your details";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.WhiteSmoke;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(216, 284);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(389, 41);
            txtEmail.TabIndex = 32;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(25, 297);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(63, 28);
            lblEmail.TabIndex = 31;
            lblEmail.Text = "Email:";
            // 
            // txtLName
            // 
            txtLName.BackColor = Color.WhiteSmoke;
            txtLName.BorderStyle = BorderStyle.None;
            txtLName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLName.Location = new Point(216, 213);
            txtLName.Multiline = true;
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(389, 41);
            txtLName.TabIndex = 30;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastName.ForeColor = Color.Black;
            lblLastName.Location = new Point(25, 226);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(103, 28);
            lblLastName.TabIndex = 29;
            lblLastName.Text = "Last name:";
            // 
            // txtFName
            // 
            txtFName.BackColor = Color.WhiteSmoke;
            txtFName.BorderStyle = BorderStyle.None;
            txtFName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFName.Location = new Point(216, 141);
            txtFName.Multiline = true;
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(389, 41);
            txtFName.TabIndex = 28;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFirstName.ForeColor = Color.Black;
            lblFirstName.Location = new Point(25, 154);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(106, 28);
            lblFirstName.TabIndex = 27;
            lblFirstName.Text = "First name:";
            // 
            // btnChangeDetails
            // 
            btnChangeDetails.BackColor = Color.FromArgb(130, 76, 113);
            btnChangeDetails.FlatAppearance.BorderSize = 0;
            btnChangeDetails.FlatStyle = FlatStyle.Flat;
            btnChangeDetails.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangeDetails.ForeColor = Color.White;
            btnChangeDetails.Location = new Point(126, 368);
            btnChangeDetails.Name = "btnChangeDetails";
            btnChangeDetails.Size = new Size(389, 50);
            btnChangeDetails.TabIndex = 33;
            btnChangeDetails.Text = "Change details";
            btnChangeDetails.UseVisualStyleBackColor = false;
            btnChangeDetails.Click += btnChangeDetails_Click;
            // 
            // EditDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(650, 430);
            Controls.Add(btnChangeDetails);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtLName);
            Controls.Add(lblLastName);
            Controls.Add(txtFName);
            Controls.Add(lblFirstName);
            Controls.Add(pictureBox2);
            Controls.Add(lblSlogan);
            Controls.Add(lblUserDetailsChange);
            Name = "EditDetails";
            Text = "EditDetails";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Label lblSlogan;
        private Label lblUserDetailsChange;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtLName;
        private Label lblLastName;
        private TextBox txtFName;
        private Label lblFirstName;
        private Button btnChangeDetails;
    }
}