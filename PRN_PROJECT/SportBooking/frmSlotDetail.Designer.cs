namespace SportBooking
{
    partial class frmSlotDetail
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mskStart = new System.Windows.Forms.MaskedTextBox();
            this.mskEnd = new System.Windows.Forms.MaskedTextBox();
            this.cbCourtID = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(72, 285);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "CourtID";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(28, 211);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(49, 20);
            this.Status.TabIndex = 1;
            this.Status.Text = "Status";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbStatus.Location = new System.Drawing.Point(145, 203);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(151, 28);
            this.cbStatus.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "End at";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Start at";
            // 
            // mskStart
            // 
            this.mskStart.Location = new System.Drawing.Point(145, 91);
            this.mskStart.Mask = "00:00:00";
            this.mskStart.Name = "mskStart";
            this.mskStart.Size = new System.Drawing.Size(125, 27);
            this.mskStart.TabIndex = 4;
            // 
            // mskEnd
            // 
            this.mskEnd.Location = new System.Drawing.Point(145, 147);
            this.mskEnd.Mask = "00:00:00";
            this.mskEnd.Name = "mskEnd";
            this.mskEnd.Size = new System.Drawing.Size(125, 27);
            this.mskEnd.TabIndex = 4;
            // 
            // cbCourtID
            // 
            this.cbCourtID.FormattingEnabled = true;
            this.cbCourtID.Location = new System.Drawing.Point(145, 27);
            this.cbCourtID.Name = "cbCourtID";
            this.cbCourtID.Size = new System.Drawing.Size(230, 28);
            this.cbCourtID.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(221, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmSlotDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 366);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbCourtID);
            this.Controls.Add(this.mskEnd);
            this.Controls.Add(this.mskStart);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Name = "frmSlotDetail";
            this.Text = "Slot Detail";
            this.Load += new System.EventHandler(this.frmSlotDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mskStart;
        private System.Windows.Forms.MaskedTextBox mskEnd;
        private System.Windows.Forms.ComboBox cbCourtID;
        private System.Windows.Forms.Button btnCancel;
    }
}