namespace SportBooking
{
    partial class frmMain
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
            this.btnViewProfile = new System.Windows.Forms.Button();
            this.btnCourt = new System.Windows.Forms.Button();
            this.btnSlot = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnViewOrder = new System.Windows.Forms.Button();
            this.dgvCourtList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCourtID = new System.Windows.Forms.TextBox();
            this.txtCourtName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourtList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnViewProfile
            // 
            this.btnViewProfile.Location = new System.Drawing.Point(653, 210);
            this.btnViewProfile.Name = "btnViewProfile";
            this.btnViewProfile.Size = new System.Drawing.Size(148, 29);
            this.btnViewProfile.TabIndex = 0;
            this.btnViewProfile.Text = "View Profile";
            this.btnViewProfile.UseVisualStyleBackColor = true;
            this.btnViewProfile.Click += new System.EventHandler(this.btnViewProfile_Click);
            // 
            // btnCourt
            // 
            this.btnCourt.Location = new System.Drawing.Point(653, 310);
            this.btnCourt.Name = "btnCourt";
            this.btnCourt.Size = new System.Drawing.Size(148, 29);
            this.btnCourt.TabIndex = 0;
            this.btnCourt.Text = "Court management";
            this.btnCourt.UseVisualStyleBackColor = true;
            this.btnCourt.Click += new System.EventHandler(this.btnCourt_Click);
            // 
            // btnSlot
            // 
            this.btnSlot.Location = new System.Drawing.Point(653, 367);
            this.btnSlot.Name = "btnSlot";
            this.btnSlot.Size = new System.Drawing.Size(148, 29);
            this.btnSlot.TabIndex = 0;
            this.btnSlot.Text = "Slot management";
            this.btnSlot.UseVisualStyleBackColor = true;
            this.btnSlot.Click += new System.EventHandler(this.btnSlot_Click);
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(653, 423);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(148, 29);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "User management";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnViewOrder
            // 
            this.btnViewOrder.Location = new System.Drawing.Point(653, 261);
            this.btnViewOrder.Name = "btnViewOrder";
            this.btnViewOrder.Size = new System.Drawing.Size(148, 29);
            this.btnViewOrder.TabIndex = 0;
            this.btnViewOrder.Text = "View Orders";
            this.btnViewOrder.UseVisualStyleBackColor = true;
            // 
            // dgvCourtList
            // 
            this.dgvCourtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourtList.Location = new System.Drawing.Point(12, 210);
            this.dgvCourtList.Name = "dgvCourtList";
            this.dgvCourtList.RowHeadersWidth = 51;
            this.dgvCourtList.RowTemplate.Height = 29;
            this.dgvCourtList.Size = new System.Drawing.Size(614, 311);
            this.dgvCourtList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(182, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sport Court Application";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "CourtID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Court Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Category";
            // 
            // txtCourtID
            // 
            this.txtCourtID.Location = new System.Drawing.Point(82, 83);
            this.txtCourtID.Name = "txtCourtID";
            this.txtCourtID.Size = new System.Drawing.Size(125, 27);
            this.txtCourtID.TabIndex = 4;
            // 
            // txtCourtName
            // 
            this.txtCourtName.Location = new System.Drawing.Point(327, 81);
            this.txtCourtName.Name = "txtCourtName";
            this.txtCourtName.Size = new System.Drawing.Size(256, 27);
            this.txtCourtName.TabIndex = 4;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(82, 129);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(125, 27);
            this.txtPrice.TabIndex = 4;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(327, 132);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(256, 27);
            this.txtCategory.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Filter by category";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "Football",
            "Basketball",
            "Volleyball",
            "Tennis",
            "Badminton"});
            this.cbCategory.Location = new System.Drawing.Point(142, 171);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(151, 28);
            this.cbCategory.TabIndex = 5;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(327, 551);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 29);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(653, 478);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(148, 29);
            this.btnOrder.TabIndex = 7;
            this.btnOrder.Text = "Order management";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 592);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtCourtName);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtCourtID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCourtList);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.btnSlot);
            this.Controls.Add(this.btnCourt);
            this.Controls.Add(this.btnViewOrder);
            this.Controls.Add(this.btnViewProfile);
            this.Name = "frmMain";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourtList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnViewProfile;
        private System.Windows.Forms.Button btnCourt;
        private System.Windows.Forms.Button btnSlot;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnViewOrder;
        private System.Windows.Forms.DataGridView dgvCourtList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCourtID;
        private System.Windows.Forms.TextBox txtCourtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOrder;
    }
}