namespace Epoint.Systems.Customizes
{
	partial class UcTreeMain
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
			this.tvMain = new Epoint.Systems.Controls.tvControl();
			this.SuspendLayout();
			// 
			// tvMain
			// 
			this.tvMain.BackColor = System.Drawing.Color.White;
			this.tvMain.DataSource = null;
			this.tvMain.DisplayFieldName = "";
			this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tvMain.KeyFieldName = "";
			this.tvMain.Location = new System.Drawing.Point(0, 0);
			this.tvMain.Name = "tvMain";
			this.tvMain.ParentFieldName = "";
			this.tvMain.Size = new System.Drawing.Size(249, 426);
			this.tvMain.TabIndex = 0;
			// 
			// UcTreeMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.tvMain);
			this.Name = "UcTreeMain";
			this.Size = new System.Drawing.Size(249, 426);
			this.ResumeLayout(false);

		}

		#endregion

		public Epoint.Systems.Controls.tvControl tvMain;


	}
}
