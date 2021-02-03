namespace Epoint.Controllers
{
	partial class frmTyGia_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTyGia_Edit));
            this.lbTy_Gia = new Epoint.Systems.Controls.lblControl();
            this.numTy_Gia = new Epoint.Systems.Controls.numControl();
            this.dteNgay_Ap = new Epoint.Systems.Controls.txtDateTime();
            this.lbNgay_Ap = new Epoint.Systems.Controls.lblControl();
            this.enuMa_Tte = new Epoint.Systems.Controls.txtEnum();
            this.lbMa_Tte = new Epoint.Systems.Controls.lblControl();
            this.btgAccept = new Epoint.Systems.Customizes.btgAccept();
            this.SuspendLayout();
            // 
            // lbTy_Gia
            // 
            this.lbTy_Gia.AutoEllipsis = true;
            this.lbTy_Gia.AutoSize = true;
            this.lbTy_Gia.BackColor = System.Drawing.Color.Transparent;
            this.lbTy_Gia.Location = new System.Drawing.Point(16, 73);
            this.lbTy_Gia.Name = "lbTy_Gia";
            this.lbTy_Gia.Size = new System.Drawing.Size(36, 13);
            this.lbTy_Gia.TabIndex = 46;
            this.lbTy_Gia.Tag = "TY_GIA";
            this.lbTy_Gia.Text = "Tỷ giá";
            this.lbTy_Gia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTy_Gia
            // 
            this.numTy_Gia.bEnabled = true;
            this.numTy_Gia.bFormat = true;
            this.numTy_Gia.bIsLookup = false;
            this.numTy_Gia.bReadOnly = false;
            this.numTy_Gia.bRequire = false;
            this.numTy_Gia.KeyFilter = "";
            this.numTy_Gia.Location = new System.Drawing.Point(115, 74);
            this.numTy_Gia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.numTy_Gia.Name = "numTy_Gia";
            this.numTy_Gia.Scale = 2;
            this.numTy_Gia.Size = new System.Drawing.Size(100, 20);
            this.numTy_Gia.TabIndex = 2;
            this.numTy_Gia.Text = "0.00";
            this.numTy_Gia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTy_Gia.UseAutoFilter = false;
            this.numTy_Gia.Value = 0D;
            // 
            // dteNgay_Ap
            // 
            this.dteNgay_Ap.bAllowEmpty = true;
            this.dteNgay_Ap.bRequire = false;
            this.dteNgay_Ap.bSelectOnFocus = false;
            this.dteNgay_Ap.bShowDateTimePicker = true;
            this.dteNgay_Ap.Culture = new System.Globalization.CultureInfo("fr-FR");
            this.dteNgay_Ap.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dteNgay_Ap.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dteNgay_Ap.Location = new System.Drawing.Point(115, 51);
            this.dteNgay_Ap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.dteNgay_Ap.Mask = "00/00/0000";
            this.dteNgay_Ap.Name = "dteNgay_Ap";
            this.dteNgay_Ap.Size = new System.Drawing.Size(66, 20);
            this.dteNgay_Ap.TabIndex = 1;
            // 
            // lbNgay_Ap
            // 
            this.lbNgay_Ap.AutoEllipsis = true;
            this.lbNgay_Ap.AutoSize = true;
            this.lbNgay_Ap.BackColor = System.Drawing.Color.Transparent;
            this.lbNgay_Ap.Location = new System.Drawing.Point(16, 50);
            this.lbNgay_Ap.Name = "lbNgay_Ap";
            this.lbNgay_Ap.Size = new System.Drawing.Size(47, 13);
            this.lbNgay_Ap.TabIndex = 45;
            this.lbNgay_Ap.Tag = "NGAY_AP";
            this.lbNgay_Ap.Text = "Ngày áp";
            this.lbNgay_Ap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // enuMa_Tte
            // 
            this.enuMa_Tte.bEnabled = true;
            this.enuMa_Tte.bIsLookup = false;
            this.enuMa_Tte.bReadOnly = false;
            this.enuMa_Tte.bRequire = false;
            this.enuMa_Tte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.enuMa_Tte.InputMask = "";
            this.enuMa_Tte.KeyFilter = "";
            this.enuMa_Tte.Location = new System.Drawing.Point(115, 28);
            this.enuMa_Tte.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.enuMa_Tte.MaxLength = 20;
            this.enuMa_Tte.Name = "enuMa_Tte";
            this.enuMa_Tte.Size = new System.Drawing.Size(66, 20);
            this.enuMa_Tte.TabIndex = 0;
            this.enuMa_Tte.UseAutoFilter = false;
            // 
            // lbMa_Tte
            // 
            this.lbMa_Tte.AutoEllipsis = true;
            this.lbMa_Tte.AutoSize = true;
            this.lbMa_Tte.BackColor = System.Drawing.Color.Transparent;
            this.lbMa_Tte.Location = new System.Drawing.Point(16, 28);
            this.lbMa_Tte.Name = "lbMa_Tte";
            this.lbMa_Tte.Size = new System.Drawing.Size(54, 13);
            this.lbMa_Tte.TabIndex = 44;
            this.lbMa_Tte.Tag = "MA_TTE";
            this.lbMa_Tte.Text = "Mã tiền tệ";
            this.lbMa_Tte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btgAccept
            // 
            this.btgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btgAccept.Location = new System.Drawing.Point(286, 117);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new System.Drawing.Size(169, 33);
            this.btgAccept.TabIndex = 3;
            // 
            // frmTyGia_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 166);
            this.Controls.Add(this.btgAccept);
            this.Controls.Add(this.lbMa_Tte);
            this.Controls.Add(this.enuMa_Tte);
            this.Controls.Add(this.lbTy_Gia);
            this.Controls.Add(this.numTy_Gia);
            this.Controls.Add(this.lbNgay_Ap);
            this.Controls.Add(this.dteNgay_Ap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTyGia_Edit";
            this.Object_ID = "DMTYGIA";
            this.Tag = "frmDmTyGia_Edit";
            this.Text = "frmDmTyGia_Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Epoint.Systems.Controls.lblControl lbTy_Gia;
		private Epoint.Systems.Controls.numControl numTy_Gia;
		private Epoint.Systems.Controls.txtDateTime dteNgay_Ap;
		private Epoint.Systems.Controls.lblControl lbNgay_Ap;
		private Epoint.Systems.Controls.txtEnum enuMa_Tte;
		private Epoint.Systems.Controls.lblControl lbMa_Tte;
		private Epoint.Systems.Customizes.btgAccept btgAccept;

	}
}