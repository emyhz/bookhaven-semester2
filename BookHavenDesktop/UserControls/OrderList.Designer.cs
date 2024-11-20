namespace BookHavenDesktop.UserControls
{
    partial class OrderList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblOrderNo = new Label();
            SuspendLayout();
            // 
            // lblOrderNo
            // 
            lblOrderNo.AutoSize = true;
            lblOrderNo.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderNo.Location = new Point(19, 20);
            lblOrderNo.MaximumSize = new Size(286, 0);
            lblOrderNo.Name = "lblOrderNo";
            lblOrderNo.Size = new Size(111, 32);
            lblOrderNo.TabIndex = 17;
            lblOrderNo.Text = "Order #0";
            // 
            // OrderList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(lblOrderNo);
            Name = "OrderList";
            Size = new Size(614, 405);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOrderNo;
    }
}
