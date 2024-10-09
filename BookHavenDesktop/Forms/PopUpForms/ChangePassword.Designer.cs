namespace BookHavenDesktop.Forms.PopUpForms
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            lblSlogan = new Label();
            lblChangePass = new Label();
            lblOldPass = new Label();
            txtOldPassword = new TextBox();
            txtNewPassword = new TextBox();
            lblNewPass = new Label();
            txtConfirmPass = new TextBox();
            lblConfirmPAss = new Label();
            btnChangePassword = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblSlogan
            // 
            lblSlogan.AutoSize = true;
            lblSlogan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSlogan.ForeColor = Color.Black;
            lblSlogan.Location = new Point(43, 67);
            lblSlogan.Name = "lblSlogan";
            lblSlogan.Size = new Size(254, 28);
            lblSlogan.TabIndex = 6;
            lblSlogan.Text = "Change your password here";
            // 
            // lblChangePass
            // 
            lblChangePass.AutoSize = true;
            lblChangePass.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChangePass.ForeColor = Color.FromArgb(130, 76, 113);
            lblChangePass.Location = new Point(32, 26);
            lblChangePass.Name = "lblChangePass";
            lblChangePass.Size = new Size(338, 41);
            lblChangePass.TabIndex = 5;
            lblChangePass.Text = "Change your password";
            // 
            // lblOldPass
            // 
            lblOldPass.AutoSize = true;
            lblOldPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOldPass.ForeColor = Color.Black;
            lblOldPass.Location = new Point(23, 178);
            lblOldPass.Name = "lblOldPass";
            lblOldPass.Size = new Size(136, 28);
            lblOldPass.TabIndex = 13;
            lblOldPass.Text = "Old password:";
            // 
            // txtOldPassword
            // 
            txtOldPassword.BackColor = Color.WhiteSmoke;
            txtOldPassword.BorderStyle = BorderStyle.None;
            txtOldPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOldPassword.Location = new Point(214, 165);
            txtOldPassword.Multiline = true;
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(389, 41);
            txtOldPassword.TabIndex = 14;
            // 
            // txtNewPassword
            // 
            txtNewPassword.BackColor = Color.WhiteSmoke;
            txtNewPassword.BorderStyle = BorderStyle.None;
            txtNewPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewPassword.Location = new Point(214, 237);
            txtNewPassword.Multiline = true;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(389, 41);
            txtNewPassword.TabIndex = 16;
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewPass.ForeColor = Color.Black;
            lblNewPass.Location = new Point(23, 250);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(143, 28);
            lblNewPass.TabIndex = 15;
            lblNewPass.Text = "New password:";
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.BackColor = Color.WhiteSmoke;
            txtConfirmPass.BorderStyle = BorderStyle.None;
            txtConfirmPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPass.Location = new Point(214, 308);
            txtConfirmPass.Multiline = true;
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.Size = new Size(389, 41);
            txtConfirmPass.TabIndex = 18;
            // 
            // lblConfirmPAss
            // 
            lblConfirmPAss.AutoSize = true;
            lblConfirmPAss.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmPAss.ForeColor = Color.Black;
            lblConfirmPAss.Location = new Point(23, 321);
            lblConfirmPAss.Name = "lblConfirmPAss";
            lblConfirmPAss.Size = new Size(174, 28);
            lblConfirmPAss.TabIndex = 17;
            lblConfirmPAss.Text = "Confirm password:";
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.FromArgb(130, 76, 113);
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Location = new Point(160, 388);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(298, 50);
            btnChangePassword.TabIndex = 19;
            btnChangePassword.Text = "Change password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(499, 26);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(104, 88);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(650, 450);
            Controls.Add(pictureBox2);
            Controls.Add(btnChangePassword);
            Controls.Add(txtConfirmPass);
            Controls.Add(lblConfirmPAss);
            Controls.Add(txtNewPassword);
            Controls.Add(lblNewPass);
            Controls.Add(txtOldPassword);
            Controls.Add(lblOldPass);
            Controls.Add(lblSlogan);
            Controls.Add(lblChangePass);
            Name = "ChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChangePassword";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSlogan;
        private Label lblChangePass;
        private Label lblOldPass;
        private TextBox txtOldPassword;
        private TextBox txtNewPassword;
        private Label lblNewPass;
        private TextBox txtConfirmPass;
        private Label lblConfirmPAss;
        private Button btnChangePassword;
        private PictureBox pictureBox2;
    }
}