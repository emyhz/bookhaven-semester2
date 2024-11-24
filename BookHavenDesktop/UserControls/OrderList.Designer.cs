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
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblOrderDate = new Label();
            lblCustomer = new Label();
            lblTotalPrice = new Label();
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Location = new Point(0, 74);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(514, 245);
            flowLayoutPanel1.TabIndex = 18;
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
            lblCustomer.Location = new Point(3, 329);
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
            lblTotalPrice.Location = new Point(294, 327);
            lblTotalPrice.MaximumSize = new Size(286, 0);
            lblTotalPrice.MinimumSize = new Size(171, 0);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.RightToLeft = RightToLeft.Yes;
            lblTotalPrice.Size = new Size(171, 31);
            lblTotalPrice.TabIndex = 21;
            lblTotalPrice.Text = "€0.00";
            // 
            // OrderList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(lblTotalPrice);
            Controls.Add(lblCustomer);
            Controls.Add(lblOrderDate);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblOrderNo);
            Name = "OrderList";
            Size = new Size(514, 397);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOrderNo;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblOrderDate;
        private Label lblCustomer;
        private Label lblTotalPrice;
    }
}
