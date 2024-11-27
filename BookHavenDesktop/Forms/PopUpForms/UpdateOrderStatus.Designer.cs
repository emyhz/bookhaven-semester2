namespace BookHavenDesktop.Forms.PopUpForms
{
    partial class UpdateOrderStatus
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
            panel1 = new Panel();
            cmbStatus = new ComboBox();
            lblOrderStatus = new Label();
            lblOrderNo = new Label();
            lblOrderDate = new Label();
            btnSubmitNewOrderStatus = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(cmbStatus);
            panel1.Controls.Add(lblOrderStatus);
            panel1.Location = new Point(-2, 83);
            panel1.Name = "panel1";
            panel1.Size = new Size(571, 146);
            panel1.TabIndex = 0;
            // 
            // cmbStatus
            // 
            cmbStatus.BackColor = Color.WhiteSmoke;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(14, 57);
            cmbStatus.Margin = new Padding(3, 4, 3, 4);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(359, 40);
            cmbStatus.TabIndex = 61;
            // 
            // lblOrderStatus
            // 
            lblOrderStatus.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrderStatus.ForeColor = Color.FromArgb(144, 170, 134);
            lblOrderStatus.Location = new Point(14, 16);
            lblOrderStatus.Name = "lblOrderStatus";
            lblOrderStatus.Size = new Size(381, 37);
            lblOrderStatus.TabIndex = 60;
            lblOrderStatus.Text = "Change customers' current order status\r\n\r\n";
            // 
            // lblOrderNo
            // 
            lblOrderNo.AutoSize = true;
            lblOrderNo.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderNo.Location = new Point(22, 29);
            lblOrderNo.MaximumSize = new Size(286, 0);
            lblOrderNo.Name = "lblOrderNo";
            lblOrderNo.Size = new Size(111, 32);
            lblOrderNo.TabIndex = 18;
            lblOrderNo.Text = "Order #0";
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderDate.Location = new Point(312, 29);
            lblOrderDate.MaximumSize = new Size(286, 0);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.RightToLeft = RightToLeft.Yes;
            lblOrderDate.Size = new Size(257, 32);
            lblOrderDate.TabIndex = 20;
            lblOrderDate.Text = "Placed on: 00/00/0000";
            // 
            // btnSubmitNewOrderStatus
            // 
            btnSubmitNewOrderStatus.BackColor = Color.FromArgb(220, 204, 163);
            btnSubmitNewOrderStatus.FlatAppearance.BorderSize = 0;
            btnSubmitNewOrderStatus.FlatStyle = FlatStyle.Flat;
            btnSubmitNewOrderStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSubmitNewOrderStatus.ForeColor = Color.White;
            btnSubmitNewOrderStatus.Location = new Point(130, 245);
            btnSubmitNewOrderStatus.Name = "btnSubmitNewOrderStatus";
            btnSubmitNewOrderStatus.Size = new Size(298, 50);
            btnSubmitNewOrderStatus.TabIndex = 22;
            btnSubmitNewOrderStatus.Text = "Submit";
            btnSubmitNewOrderStatus.UseVisualStyleBackColor = false;
            btnSubmitNewOrderStatus.Click += btnSubmitNewOrderStatus_Click;
            // 
            // UpdateOrderStatus
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 307);
            Controls.Add(btnSubmitNewOrderStatus);
            Controls.Add(lblOrderDate);
            Controls.Add(lblOrderNo);
            Controls.Add(panel1);
            Name = "UpdateOrderStatus";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpdateOrderStatus";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblOrderNo;
        private Label lblOrderDate;
        private Label lblOrderStatus;
        private ComboBox cmbStatus;
        private Button btnSubmitNewOrderStatus;
    }
}