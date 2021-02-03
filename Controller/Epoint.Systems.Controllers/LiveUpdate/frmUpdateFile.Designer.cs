namespace Epoint.Controllers
{
    partial class frmUpdateFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateFile));
            this.btOk = new Epoint.Systems.Controls.btControl();
            this.btCancel = new Epoint.Systems.Controls.btControl();
            this.lblDongY = new Epoint.Systems.Controls.lblControl();
            this.lblHuyBo = new Epoint.Systems.Controls.lblControl();
            this.SuspendLayout();
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOk.ForeColor = System.Drawing.Color.Blue;
            this.btOk.Image = ((System.Drawing.Image)(resources.GetObject("btOk.Image")));
            this.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOk.Location = new System.Drawing.Point(481, 332);
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
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.Blue;
            this.btCancel.Image = ((System.Drawing.Image)(resources.GetObject("btCancel.Image")));
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(563, 332);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(76, 33);
            this.btCancel.TabIndex = 6;
            this.btCancel.Tag = "Cancel";
            this.btCancel.Text = "&Hủy bỏ";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // lblDongY
            // 
            this.lblDongY.AutoEllipsis = true;
            this.lblDongY.AutoSize = true;
            this.lblDongY.BackColor = System.Drawing.Color.Transparent;
            this.lblDongY.Location = new System.Drawing.Point(31, 39);
            this.lblDongY.Name = "lblDongY";
            this.lblDongY.Size = new System.Drawing.Size(418, 13);
            this.lblDongY.TabIndex = 8;
            this.lblDongY.Tag = "";
            this.lblDongY.Text = "Nhấn \'Đồng ý\' để tiếp tục cập nhật phiên bản mới nhất. Vui lòng chờ " +
    "đợi trong giây lát !";
            this.lblDongY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHuyBo
            // 
            this.lblHuyBo.AutoEllipsis = true;
            this.lblHuyBo.AutoSize = true;
            this.lblHuyBo.BackColor = System.Drawing.Color.Transparent;
            this.lblHuyBo.Location = new System.Drawing.Point(31, 62);
            this.lblHuyBo.Name = "lblHuyBo";
            this.lblHuyBo.Size = new System.Drawing.Size(218, 13);
            this.lblHuyBo.TabIndex = 9;
            this.lblHuyBo.Tag = "";
            this.lblHuyBo.Text = "Nhấn \'Hủy bỏ\' để ngưng quá trình cập nhật !";
            this.lblHuyBo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmUpdateFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(663, 388);
            this.Controls.Add(this.lblHuyBo);
            this.Controls.Add(this.lblDongY);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Name = "frmUpdateFile";
            this.Tag = "";
            this.Text = "frmUpdateFile";
            //this.Load += new System.EventHandler(this.frmUpdateFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.btControl btOk;
        private Epoint.Systems.Controls.btControl btCancel;
        private Systems.Controls.lblControl lblDongY;
        private Systems.Controls.lblControl lblHuyBo;
	}
}