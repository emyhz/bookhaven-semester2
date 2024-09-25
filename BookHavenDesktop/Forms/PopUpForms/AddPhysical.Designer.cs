namespace BookHavenDesktop.Forms.PopUpForms
{
    partial class AddPhysical
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPhysical));
            pbPhysical = new PictureBox();
            lblPhysical2 = new Label();
            lblPhysical = new Label();
            pnlPhysical = new Panel();
            ((System.ComponentModel.ISupportInitialize)pbPhysical).BeginInit();
            SuspendLayout();
            // 
            // pbPhysical
            // 
            pbPhysical.Image = (Image)resources.GetObject("pbPhysical.Image");
            pbPhysical.Location = new Point(760, 36);
            pbPhysical.Name = "pbPhysical";
            pbPhysical.Size = new Size(68, 62);
            pbPhysical.TabIndex = 19;
            pbPhysical.TabStop = false;
            // 
            // lblPhysical2
            // 
            lblPhysical2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhysical2.ForeColor = Color.Black;
            lblPhysical2.Location = new Point(54, 70);
            lblPhysical2.Name = "lblPhysical2";
            lblPhysical2.Size = new Size(309, 28);
            lblPhysical2.TabIndex = 18;
            lblPhysical2.Text = "Enter the details of the book\r\n\r\n";
            // 
            // lblPhysical
            // 
            lblPhysical.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhysical.ForeColor = Color.FromArgb(220, 204, 163);
            lblPhysical.Location = new Point(54, 24);
            lblPhysical.Name = "lblPhysical";
            lblPhysical.Size = new Size(385, 46);
            lblPhysical.TabIndex = 17;
            lblPhysical.Text = "Add a new physical book\r\n\r\n";
            // 
            // pnlPhysical
            // 
            pnlPhysical.BackColor = Color.White;
            pnlPhysical.Location = new Point(54, 112);
            pnlPhysical.Name = "pnlPhysical";
            pnlPhysical.Size = new Size(774, 371);
            pnlPhysical.TabIndex = 16;
            // 
            // AddPhysical
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 510);
            Controls.Add(pbPhysical);
            Controls.Add(lblPhysical2);
            Controls.Add(lblPhysical);
            Controls.Add(pnlPhysical);
            Name = "AddPhysical";
            Text = "AddPhysical";
            ((System.ComponentModel.ISupportInitialize)pbPhysical).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbPhysical;
        private Label lblPhysical2;
        private Label lblPhysical;
        private Panel pnlPhysical;
    }
}