namespace BookHavenDesktop.Forms.MainPages
{
    partial class HomePage
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
            lblHomePage = new Label();
            pnlHome = new Panel();
            lblHome = new Label();
            pnlHome.SuspendLayout();
            SuspendLayout();
            // 
            // lblHomePage
            // 
            lblHomePage.AutoSize = true;
            lblHomePage.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHomePage.ForeColor = Color.FromArgb(130, 76, 113);
            lblHomePage.Location = new Point(46, 62);
            lblHomePage.Name = "lblHomePage";
            lblHomePage.Size = new Size(116, 46);
            lblHomePage.TabIndex = 0;
            lblHomePage.Text = "Home";
            // 
            // pnlHome
            // 
            pnlHome.BackColor = Color.White;
            pnlHome.Controls.Add(lblHome);
            pnlHome.Location = new Point(46, 121);
            pnlHome.Name = "pnlHome";
            pnlHome.Size = new Size(990, 534);
            pnlHome.TabIndex = 1;
            // 
            // lblHome
            // 
            lblHome.AutoSize = true;
            lblHome.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHome.ForeColor = Color.FromArgb(130, 76, 113);
            lblHome.Location = new Point(20, 45);
            lblHome.Name = "lblHome";
            lblHome.Size = new Size(455, 46);
            lblHome.TabIndex = 2;
            lblHome.Text = "BookHaven Welcomes you!";
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(233, 210, 224);
            ClientSize = new Size(1622, 907);
            Controls.Add(pnlHome);
            Controls.Add(lblHomePage);
            Name = "HomePage";
            Text = "HomePage";
            pnlHome.ResumeLayout(false);
            pnlHome.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHomePage;
        private Panel pnlHome;
        private Label lblHome;
    }
}