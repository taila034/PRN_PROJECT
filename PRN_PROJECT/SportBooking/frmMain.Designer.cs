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
            this.btnOrder = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnViewProfile
            // 
            this.btnViewProfile.Location = new System.Drawing.Point(640, 114);
            this.btnViewProfile.Name = "btnViewProfile";
            this.btnViewProfile.Size = new System.Drawing.Size(148, 29);
            this.btnViewProfile.TabIndex = 0;
            this.btnViewProfile.Text = "View Profile";
            this.btnViewProfile.UseVisualStyleBackColor = true;
            // 
            // btnCourt
            // 
            this.btnCourt.Location = new System.Drawing.Point(640, 214);
            this.btnCourt.Name = "btnCourt";
            this.btnCourt.Size = new System.Drawing.Size(148, 29);
            this.btnCourt.TabIndex = 0;
            this.btnCourt.Text = "Court management";
            this.btnCourt.UseVisualStyleBackColor = true;
            // 
            // btnSlot
            // 
            this.btnSlot.Location = new System.Drawing.Point(640, 271);
            this.btnSlot.Name = "btnSlot";
            this.btnSlot.Size = new System.Drawing.Size(148, 29);
            this.btnSlot.TabIndex = 0;
            this.btnSlot.Text = "Slot management";
            this.btnSlot.UseVisualStyleBackColor = true;
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(640, 327);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(148, 29);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "User management";
            this.btnUser.UseVisualStyleBackColor = true;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(640, 165);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(148, 29);
            this.btnOrder.TabIndex = 0;
            this.btnOrder.Text = "View Orders";
            this.btnOrder.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(622, 311);
            this.dataGridView1.TabIndex = 1;
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.btnSlot);
            this.Controls.Add(this.btnCourt);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnViewProfile);
            this.Name = "frmMain";
            this.Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnViewProfile;
        private System.Windows.Forms.Button btnCourt;
        private System.Windows.Forms.Button btnSlot;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
    }
}