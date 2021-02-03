namespace Epoint.Systems.Customizes
{
	partial class ucCustomerInfo
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.lblDv_SuDung = new Epoint.Systems.Controls.lblControl();
            this.lblTen_Dvi = new Epoint.Systems.Controls.lblControl();
            this.lblDia_Chi = new Epoint.Systems.Controls.lblControl();
            this.picLogo_Customer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo_Customer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDv_SuDung
            // 
            this.lblDv_SuDung.AutoEllipsis = true;
            this.lblDv_SuDung.AutoSize = true;
            this.lblDv_SuDung.BackColor = System.Drawing.Color.Transparent;
            this.lblDv_SuDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDv_SuDung.ForeColor = System.Drawing.Color.Blue;
            this.lblDv_SuDung.Location = new System.Drawing.Point(14, 9);
            this.lblDv_SuDung.Name = "lblDv_SuDung";
            this.lblDv_SuDung.Size = new System.Drawing.Size(141, 13);
            this.lblDv_SuDung.TabIndex = 0;
            this.lblDv_SuDung.Tag = "Organization_Agreement";
            this.lblDv_SuDung.Text = "Đơn vị sử dụng chương trình";
            this.lblDv_SuDung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDv_SuDung.Visible = false;
            // 
            // lblTen_Dvi
            // 
            this.lblTen_Dvi.AutoEllipsis = true;
            this.lblTen_Dvi.AutoSize = true;
            this.lblTen_Dvi.BackColor = System.Drawing.Color.Transparent;
            this.lblTen_Dvi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen_Dvi.ForeColor = System.Drawing.Color.Maroon;
            this.lblTen_Dvi.Location = new System.Drawing.Point(11, 104);
            this.lblTen_Dvi.Name = "lblTen_Dvi";
            this.lblTen_Dvi.Size = new System.Drawing.Size(79, 13);
            this.lblTen_Dvi.TabIndex = 0;
            this.lblTen_Dvi.Text = "TÊN ĐƠN VỊ";
            this.lblTen_Dvi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDia_Chi
            // 
            this.lblDia_Chi.AutoEllipsis = true;
            this.lblDia_Chi.AutoSize = true;
            this.lblDia_Chi.BackColor = System.Drawing.Color.Transparent;
            this.lblDia_Chi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDia_Chi.ForeColor = System.Drawing.Color.Maroon;
            this.lblDia_Chi.Location = new System.Drawing.Point(11, 124);
            this.lblDia_Chi.Name = "lblDia_Chi";
            this.lblDia_Chi.Size = new System.Drawing.Size(40, 13);
            this.lblDia_Chi.TabIndex = 0;
            this.lblDia_Chi.Text = "Địa chỉ";
            this.lblDia_Chi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picLogo_Customer
            // 
            this.picLogo_Customer.BackColor = System.Drawing.Color.Transparent;
            this.picLogo_Customer.Location = new System.Drawing.Point(14, 3);
            this.picLogo_Customer.Name = "picLogo_Customer";
            this.picLogo_Customer.Size = new System.Drawing.Size(153, 98);
            this.picLogo_Customer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo_Customer.TabIndex = 1;
            this.picLogo_Customer.TabStop = false;
            // 
            // ucCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picLogo_Customer);
            this.Controls.Add(this.lblDia_Chi);
            this.Controls.Add(this.lblTen_Dvi);
            this.Controls.Add(this.lblDv_SuDung);
            this.Name = "ucCustomerInfo";
            this.Size = new System.Drawing.Size(194, 143);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo_Customer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Epoint.Systems.Controls.lblControl lblDv_SuDung;
        private System.Windows.Forms.PictureBox picLogo_Customer;
        public Controls.lblControl lblTen_Dvi;
        public Controls.lblControl lblDia_Chi;
	}
}
