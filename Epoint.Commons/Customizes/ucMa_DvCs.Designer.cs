namespace Epoint.Systems.Customizes
{
	partial class ucMa_DvCs
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
			this.lbtTen_DvCs = new Epoint.Systems.Controls.lblControl();
			this.cboMa_DvCs = new Epoint.Systems.Controls.cboMultiControl();
			this.SuspendLayout();
			// 
			// lbtTen_DvCs
			// 
			this.lbtTen_DvCs.AutoEllipsis = true;
			this.lbtTen_DvCs.AutoSize = true;
			this.lbtTen_DvCs.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lbtTen_DvCs.Location = new System.Drawing.Point(102, 5);
			this.lbtTen_DvCs.Name = "lbtTen_DvCs";
			this.lbtTen_DvCs.Size = new System.Drawing.Size(22, 13);
			this.lbtTen_DvCs.TabIndex = 1;
			this.lbtTen_DvCs.Text = "     ";
			this.lbtTen_DvCs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboMa_DvCs
			// 
			this.cboMa_DvCs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.cboMa_DvCs.FormattingEnabled = true;
			this.cboMa_DvCs.Location = new System.Drawing.Point(0, 1);
			this.cboMa_DvCs.Name = "cboMa_DvCs";
			this.cboMa_DvCs.Size = new System.Drawing.Size(97, 21);
			this.cboMa_DvCs.TabIndex = 0;
			// 
			// ucMa_DvCs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lbtTen_DvCs);
			this.Controls.Add(this.cboMa_DvCs);
			this.Name = "ucMa_DvCs";
			this.Size = new System.Drawing.Size(359, 24);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public Epoint.Systems.Controls.cboMultiControl cboMa_DvCs;
		private Epoint.Systems.Controls.lblControl lbtTen_DvCs;
	}
}
