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
            btnSearchOrder = new Button();
            txtOrderNo = new TextBox();
            lblOrderNo = new Label();
            lbl1 = new Label();
            panel1 = new Panel();
            cmbStatisticsTime = new ComboBox();
            lbl = new Label();
            lblOrdersFound = new Label();
            pnlOrder.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flpOrders
            // 
            flpOrders.AutoScroll = true;
            flpOrders.BackColor = Color.White;
            flpOrders.Location = new Point(427, -8);
            flpOrders.Name = "flpOrders";
            flpOrders.Size = new Size(1200, 924);
            flpOrders.TabIndex = 1;
            // 
            // lblOrders
            // 
            lblOrders.AutoSize = true;
            lblOrders.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrders.ForeColor = Color.FromArgb(220, 204, 163);
            lblOrders.Location = new Point(139, 94);
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
            pnlOrder.Location = new Point(29, 163);
            pnlOrder.Name = "pnlOrder";
            pnlOrder.Size = new Size(355, 272);
            pnlOrder.TabIndex = 6;
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
            btnSearchOrder.Click += btnSearchOrder_Click;
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
            panel1.Location = new Point(38, 485);
            panel1.Name = "panel1";
            panel1.Size = new Size(355, 176);
            panel1.TabIndex = 7;
            // 
            // cmbStatisticsTime
            // 
            cmbStatisticsTime.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatisticsTime.Font = new Font("Segoe UI", 13F);
            cmbStatisticsTime.FormattingEnabled = true;
            cmbStatisticsTime.Items.AddRange(new object[] { "Last 24 Hours", "Last Week", "Last Month", "Last Year" });
            cmbStatisticsTime.Location = new Point(27, 77);
            cmbStatisticsTime.Margin = new Padding(3, 4, 3, 4);
            cmbStatisticsTime.Name = "cmbStatisticsTime";
            cmbStatisticsTime.Size = new Size(283, 38);
            cmbStatisticsTime.TabIndex = 56;
            cmbStatisticsTime.SelectedIndexChanged += cmbStatisticsTime_SelectedIndexChanged;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl.ForeColor = Color.FromArgb(220, 204, 163);
            lbl.Location = new Point(60, 42);
            lbl.Name = "lbl";
            lbl.Size = new Size(209, 31);
            lbl.TabIndex = 4;
            lbl.Text = "Overview of Orders\r\n";
            // 
            // lblOrdersFound
            // 
            lblOrdersFound.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblOrdersFound.AutoSize = true;
            lblOrdersFound.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblOrdersFound.ForeColor = SystemColors.ActiveCaptionText;
            lblOrdersFound.Location = new Point(215, 18);
            lblOrdersFound.Name = "lblOrdersFound";
            lblOrdersFound.Size = new Size(107, 32);
            lblOrdersFound.TabIndex = 48;
            lblOrdersFound.Text = "0 Orders";
            // 
            // Orders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(144, 170, 134);
            ClientSize = new Size(1622, 907);
            Controls.Add(lblOrdersFound);
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
        private Label lblOrdersFound;
    }
}