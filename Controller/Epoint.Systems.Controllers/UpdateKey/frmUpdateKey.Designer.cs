namespace Epoint.Controllers
{
    partial class frmUpdateKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateKey));
            this.btOk = new Epoint.Systems.Controls.btControl();
            this.btCancel = new Epoint.Systems.Controls.btControl();
            this.lblFile_Name = new Epoint.Systems.Controls.lblControl();
            this.txtFile_Name = new Epoint.Systems.Controls.txtTextBox();
            this.btFile = new Epoint.Systems.Controls.btControl();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Image = ((System.Drawing.Image)(resources.GetObject("btOk.Image")));
            this.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOk.Location = new System.Drawing.Point(390, 95);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(76, 33);
            this.btOk.TabIndex = 4;
            this.btOk.Tag = "ACCEPT";
            this.btOk.Text = "&Đồng ý";
            this.btOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOk.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(472, 95);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(76, 33);
            this.btCancel.TabIndex = 6;
            this.btCancel.Tag = "Cancel";
            this.btCancel.Text = "&Hủy bỏ";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // lblFile_Name
            // 
            this.lblFile_Name.AutoEllipsis = true;
            this.lblFile_Name.AutoSize = true;
            this.lblFile_Name.BackColor = System.Drawing.Color.Transparent;
            this.lblFile_Name.Location = new System.Drawing.Point(31, 39);
            this.lblFile_Name.Name = "lblFile_Name";
            this.lblFile_Name.Size = new System.Drawing.Size(43, 13);
            this.lblFile_Name.TabIndex = 8;
            this.lblFile_Name.Tag = "";
            this.lblFile_Name.Text = "File key";
            this.lblFile_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFile_Name
            // 
            this.txtFile_Name.bEnabled = true;
            this.txtFile_Name.bIsLookup = false;
            this.txtFile_Name.bReadOnly = false;
            this.txtFile_Name.bRequire = false;
            this.txtFile_Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFile_Name.KeyFilter = "";
            this.txtFile_Name.Location = new System.Drawing.Point(93, 37);
            this.txtFile_Name.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtFile_Name.Name = "txtFile_Name";
            this.txtFile_Name.Size = new System.Drawing.Size(415, 20);
            this.txtFile_Name.TabIndex = 0;
            this.txtFile_Name.UseAutoFilter = false;
            // 
            // btFile
            // 
            this.btFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFile.Image = ((System.Drawing.Image)(resources.GetObject("btFile.Image")));
            this.btFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFile.Location = new System.Drawing.Point(516, 36);
            this.btFile.Name = "btFile";
            this.btFile.Size = new System.Drawing.Size(41, 22);
            this.btFile.TabIndex = 5;
            this.btFile.Tag = "";
            this.btFile.Text = "...";
            this.btFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFile.UseVisualStyleBackColor = true;
            // 
            // frmUpdateKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(573, 141);
            this.Controls.Add(this.lblFile_Name);
            this.Controls.Add(this.txtFile_Name);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btFile);
            this.Controls.Add(this.btOk);
            this.Name = "frmUpdateKey";
            this.Tag = "frmKey";
            this.Text = "frmKey";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.btControl btOk;
        private Epoint.Systems.Controls.btControl btCancel;
        private Systems.Controls.lblControl lblFile_Name;
        private Systems.Controls.txtTextBox txtFile_Name;
        private Systems.Controls.btControl btFile;
	}
}