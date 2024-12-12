namespace BookHavenDesktop.Forms.PopUpForms
{
    partial class ChangeUserType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeUserType));
            pictureBox2 = new PictureBox();
            lblSlogan = new Label();
            lblUserDetailsChange = new Label();
            lblNewPass = new Label();
            btnChangeDetails = new Button();
            cmbPosition = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(501, 30);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(104, 88);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 23;
            pictureBox2.TabStop = false;
            // 
            // lblSlogan
            // 
            lblSlogan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSlogan.ForeColor = Color.Black;
            lblSlogan.Location = new Point(45, 71);
            lblSlogan.Name = "lblSlogan";
            lblSlogan.Size = new Size(254, 28);
            lblSlogan.TabIndex = 22;
            lblSlogan.Text = "Change your position";
            // 
            // lblUserDetailsChange
            // 
            lblUserDetailsChange.AutoSize = true;
            lblUserDetailsChange.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserDetailsChange.ForeColor = Color.FromArgb(130, 76, 113);
            lblUserDetailsChange.Location = new Point(34, 30);
            lblUserDetailsChange.Name = "lblUserDetailsChange";
            lblUserDetailsChange.Size = new Size(298, 41);
            lblUserDetailsChange.TabIndex = 21;
            lblUserDetailsChange.Text = "Change your details";
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewPass.ForeColor = Color.Black;
            lblNewPass.Location = new Point(34, 172);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(86, 28);
            lblNewPass.TabIndex = 26;
            lblNewPass.Text = "Position:";
            // 
            // btnChangeDetails
            // 
            btnChangeDetails.BackColor = Color.FromArgb(130, 76, 113);
            btnChangeDetails.FlatAppearance.BorderSize = 0;
            btnChangeDetails.FlatStyle = FlatStyle.Flat;
            btnChangeDetails.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangeDetails.ForeColor = Color.White;
            btnChangeDetails.Location = new Point(132, 266);
            btnChangeDetails.Name = "btnChangeDetails";
            btnChangeDetails.Size = new Size(389, 50);
            btnChangeDetails.TabIndex = 28;
            btnChangeDetails.Text = "Change details";
            btnChangeDetails.UseVisualStyleBackColor = false;
            btnChangeDetails.Click += btnChangeDetails_Click;
            // 
            // cmbPosition
            // 
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Location = new Point(195, 166);
            cmbPosition.Margin = new Padding(3, 4, 3, 4);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(389, 40);
            cmbPosition.TabIndex = 88;
            // 
            // ChangeUserType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(650, 346);
            Controls.Add(cmbPosition);
            Controls.Add(btnChangeDetails);
            Controls.Add(lblNewPass);
            Controls.Add(pictureBox2);
            Controls.Add(lblSlogan);
            Controls.Add(lblUserDetailsChange);
            Name = "ChangeUserType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChangeNameUserType";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Label lblSlogan;
        private Label lblUserDetailsChange;
        private Label lblNewPass;
        private Button btnChangeDetails;
        private ComboBox cmbPosition;
    }
}