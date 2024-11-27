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
            lblOrderDate = new Label();
            lblCustomer = new Label();
            lblTotalPrice = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
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
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderDate.Location = new Point(242, 20);
            lblOrderDate.MaximumSize = new Size(286, 0);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.RightToLeft = RightToLeft.Yes;
            lblOrderDate.Size = new Size(257, 32);
            lblOrderDate.TabIndex = 19;
            lblOrderDate.Text = "Placed on: 00/00/0000";
            // 
            // lblCustomer
            // 
            lblCustomer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomer.ForeColor = Color.Gray;
            lblCustomer.Location = new Point(3, 19);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(285, 56);
            lblCustomer.TabIndex = 20;
            lblCustomer.Text = "Placed by: janedoe@gmail.com";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPrice.ForeColor = Color.ForestGreen;
            lblTotalPrice.Location = new Point(294, 19);
            lblTotalPrice.MaximumSize = new Size(286, 0);
            lblTotalPrice.MinimumSize = new Size(171, 0);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.RightToLeft = RightToLeft.Yes;
            lblTotalPrice.Size = new Size(171, 31);
            lblTotalPrice.TabIndex = 21;
            lblTotalPrice.Text = "€0.00";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblCustomer);
            panel1.Controls.Add(lblTotalPrice);
            panel1.Location = new Point(0, 71);
            panel1.Name = "panel1";
            panel1.Size = new Size(514, 87);
            panel1.TabIndex = 22;
            // 
            // OrderList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(panel1);
            Controls.Add(lblOrderDate);
            Controls.Add(lblOrderNo);
            Name = "OrderList";
            Size = new Size(514, 159);
            Click += OrderList_Click;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOrderNo;
        private Label lblOrderDate;
        private Label lblCustomer;
        private Label lblTotalPrice;
        private Panel panel1;
    }
}
