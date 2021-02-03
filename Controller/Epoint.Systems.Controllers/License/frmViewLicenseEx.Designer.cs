namespace Epoint.Controllers
{
    partial class frmViewLicenseEx
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbControl1 = new Epoint.Systems.Controls.grbControl();
            this.dgvListCustomerLics = new Epoint.Systems.Controls.dgvControl();
            this.chkConfirm = new Epoint.Systems.Controls.chkControl();
            this.grbControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCustomerLics)).BeginInit();
            this.SuspendLayout();
            // 
            // grbControl1
            // 
            this.grbControl1.Controls.Add(this.dgvListCustomerLics);
            this.grbControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbControl1.Location = new System.Drawing.Point(0, 29);
            this.grbControl1.Name = "grbControl1";
            this.grbControl1.Size = new System.Drawing.Size(792, 537);
            this.grbControl1.TabIndex = 2;
            this.grbControl1.TabStop = false;
            // 
            // dgvListCustomerLics
            // 
            this.dgvListCustomerLics.AllowUserToAddRows = false;
            this.dgvListCustomerLics.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvListCustomerLics.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListCustomerLics.BackgroundColor = System.Drawing.Color.White;
            this.dgvListCustomerLics.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListCustomerLics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListCustomerLics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListCustomerLics.EnableHeadersVisualStyles = false;
            this.dgvListCustomerLics.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvListCustomerLics.Location = new System.Drawing.Point(3, 16);
            this.dgvListCustomerLics.MultiSelect = false;
            this.dgvListCustomerLics.Name = "dgvListCustomerLics";
            this.dgvListCustomerLics.ReadOnly = true;
            this.dgvListCustomerLics.Size = new System.Drawing.Size(786, 518);
            this.dgvListCustomerLics.strZone = "";
            this.dgvListCustomerLics.TabIndex = 3;
            // 
            // chkConfirm
            // 
            this.chkConfirm.AutoSize = true;
            this.chkConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConfirm.Location = new System.Drawing.Point(12, 14);
            this.chkConfirm.Name = "chkConfirm";
            this.chkConfirm.Size = new System.Drawing.Size(84, 17);
            this.chkConfirm.TabIndex = 7;
            this.chkConfirm.Tag = "Confirm";
            this.chkConfirm.Text = "Xác nhận ";
            this.chkConfirm.UseVisualStyleBackColor = true;
            // 
            // frmViewLicenseEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.chkConfirm);
            this.Controls.Add(this.grbControl1);
            this.Name = "frmViewLicenseEx";
            this.Tag = "frmViewLicense,F2,F3,F8,ESC";
            this.Text = "frmViewLicense";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.grbControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCustomerLics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Systems.Controls.grbControl grbControl1;
        private Systems.Controls.dgvControl dgvListCustomerLics;
        private Systems.Controls.chkControl chkConfirm;
    }
}