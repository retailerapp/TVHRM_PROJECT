namespace Epoint.Modules.HRM
{
	partial class frmSelectHDPL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectHDPL));
            this.btSave = new Epoint.Systems.Controls.btControl();
            this.lblControl2 = new Epoint.Systems.Controls.lblControl();
            this.cboFile_Id = new Epoint.Systems.Controls.cboMultiControl();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Enabled = false;
            this.btSave.Image = global::Epoint.Modules.HRM.Properties.Resources.tick;
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.Location = new System.Drawing.Point(377, 132);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(113, 31);
            this.btSave.TabIndex = 1;
            this.btSave.Tag = "Select";
            this.btSave.Text = "&Chọn";
            this.btSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // lblControl2
            // 
            this.lblControl2.AutoEllipsis = true;
            this.lblControl2.AutoSize = true;
            this.lblControl2.BackColor = System.Drawing.Color.Transparent;
            this.lblControl2.Location = new System.Drawing.Point(27, 42);
            this.lblControl2.Name = "lblControl2";
            this.lblControl2.Size = new System.Drawing.Size(65, 13);
            this.lblControl2.TabIndex = 100;
            this.lblControl2.Tag = "";
            this.lblControl2.Text = "Loại phụ lục";
            this.lblControl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboFile_Id
            // 
            this.cboFile_Id.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFile_Id.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboFile_Id.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboFile_Id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFile_Id.InitValue = null;
            this.cboFile_Id.Location = new System.Drawing.Point(116, 34);
            this.cboFile_Id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboFile_Id.MaxLength = 20;
            this.cboFile_Id.Name = "cboFile_Id";
            this.cboFile_Id.Size = new System.Drawing.Size(374, 21);
            this.cboFile_Id.strValueList = null;
            this.cboFile_Id.TabIndex = 153;
            this.cboFile_Id.UpperCase = false;
            this.cboFile_Id.UseAutoComplete = false;
            this.cboFile_Id.UseBindingValue = false;
            // 
            // frmSelectHDPL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 180);
            this.Controls.Add(this.cboFile_Id);
            this.Controls.Add(this.lblControl2);
            this.Controls.Add(this.btSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectHDPL";
            this.Tag = "";
            this.Text = "Xác nhận gửi tin ";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Controls.btControl btSave;
        private Systems.Controls.lblControl lblControl2;
        private Systems.Controls.cboMultiControl cboFile_Id;
    }
}