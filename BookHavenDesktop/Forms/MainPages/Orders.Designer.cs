namespace BookHavenDesktop.Forms.MainPages
{
    partial class Orders
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
            flpOrders = new FlowLayoutPanel();
            lblOrders = new Label();
            pnlOrder = new Panel();
            lbl1 = new Label();
            panel1 = new Panel();
            lbl = new Label();
            cmbStatisticsTime = new ComboBox();
            lblOrderNo = new Label();
            txtOrderNo = new TextBox();
            btnSearchOrder = new Button();
            pnlOrder.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flpOrders
            // 
            flpOrders.AutoScroll = true;
            flpOrders.BackColor = Color.White;
            flpOrders.Location = new Point(427, -10);
            flpOrders.Name = "flpOrders";
            flpOrders.Size = new Size(1200, 926);
            flpOrders.TabIndex = 1;
            // 
            // lblOrders
            // 
            lblOrders.AutoSize = true;
            lblOrders.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrders.ForeColor = Color.FromArgb(220, 204, 163);
            lblOrders.Location = new Point(21, 21);
            lblOrders.Name = "lblOrders";
            lblOrders.Size = new Size(128, 46);
            lblOrders.TabIndex = 5;
            lblOrders.Text = "Orders";
            // 
            // pnlOrder
            // 
            pnlOrder.BackColor = Color.White;
            pnlOrder.Controls.Add(btnSearchOrder);
            pnlOrder.Controls.Add(txtOrderNo);
            pnlOrder.Controls.Add(lblOrderNo);
            pnlOrder.Controls.Add(lbl1);
            pnlOrder.Location = new Point(31, 85);
            pnlOrder.Name = "pnlOrder";
            pnlOrder.Size = new Size(355, 272);
            pnlOrder.TabIndex = 6;
            // 
            // lbl1
            // 
            lbl1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl1.ForeColor = Color.FromArgb(220, 204, 163);
            lbl1.Location = new Point(50, 15);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(253, 31);
            lbl1.TabIndex = 4;
            lbl1.Text = "Search for an order\r\n\r\n";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(cmbStatisticsTime);
            panel1.Controls.Add(lbl);
            panel1.Location = new Point(31, 398);
            panel1.Name = "panel1";
            panel1.Size = new Size(355, 176);
            panel1.TabIndex = 7;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl.ForeColor = Color.FromArgb(220, 204, 163);
            lbl.Location = new Point(41, 31);
            lbl.Name = "lbl";
            lbl.Size = new Size(250, 31);
            lbl.TabIndex = 4;
            lbl.Text = "Statistics of BookHaven";
            // 
            // cmbStatisticsTime
            // 
            cmbStatisticsTime.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatisticsTime.Font = new Font("Segoe UI", 13F);
            cmbStatisticsTime.FormattingEnabled = true;
            cmbStatisticsTime.Items.AddRange(new object[] { "Last 24 Hours", "Last Week", "Last Month", "Last Year", "All-time" });
            cmbStatisticsTime.Location = new Point(27, 77);
            cmbStatisticsTime.Margin = new Padding(3, 4, 3, 4);
            cmbStatisticsTime.Name = "cmbStatisticsTime";
            cmbStatisticsTime.Size = new Size(283, 38);
            cmbStatisticsTime.TabIndex = 56;
            // 
            // lblOrderNo
            // 
            lblOrderNo.AutoSize = true;
            lblOrderNo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrderNo.ForeColor = Color.Black;
            lblOrderNo.Location = new Point(27, 73);
            lblOrderNo.Name = "lblOrderNo";
            lblOrderNo.Size = new Size(140, 28);
            lblOrderNo.TabIndex = 13;
            lblOrderNo.Text = "Order number:";
            // 
            // txtOrderNo
            // 
            txtOrderNo.BackColor = Color.WhiteSmoke;
            txtOrderNo.BorderStyle = BorderStyle.None;
            txtOrderNo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOrderNo.Location = new Point(27, 104);
            txtOrderNo.Multiline = true;
            txtOrderNo.Name = "txtOrderNo";
            txtOrderNo.Size = new Size(298, 41);
            txtOrderNo.TabIndex = 14;
            // 
            // btnSearchOrder
            // 
            btnSearchOrder.BackColor = Color.FromArgb(220, 204, 163);
            btnSearchOrder.FlatAppearance.BorderSize = 0;
            btnSearchOrder.FlatStyle = FlatStyle.Flat;
            btnSearchOrder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearchOrder.ForeColor = Color.White;
            btnSearchOrder.Location = new Point(27, 185);
            btnSearchOrder.Name = "btnSearchOrder";
            btnSearchOrder.Size = new Size(298, 50);
            btnSearchOrder.TabIndex = 21;
            btnSearchOrder.Text = "Search order";
            btnSearchOrder.UseVisualStyleBackColor = false;
            // 
            // Orders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(144, 170, 134);
            ClientSize = new Size(1622, 907);
            Controls.Add(panel1);
            Controls.Add(pnlOrder);
            Controls.Add(lblOrders);
            Controls.Add(flpOrders);
            Name = "Orders";
            Text = "Orders";
            pnlOrder.ResumeLayout(false);
            pnlOrder.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpOrders;
        private Label lblOrders;
        private Panel pnlOrder;
        private Label lbl1;
        private Panel panel1;
        private ComboBox cmbStatisticsTime;
        private Label lbl;
        private Label lblOrderNo;
        private TextBox txtOrderNo;
        private Button btnSearchOrder;
    }
}