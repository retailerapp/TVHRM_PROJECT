namespace Epoint.Systems.Customizes
{
    partial class ucNarMain
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
            this.NarMain = new Epoint.Systems.Controls.NarvarControl();
            ((System.ComponentModel.ISupportInitialize)(this.NarMain)).BeginInit();
            this.SuspendLayout();
            // 
            // NarMain
            // 
            this.NarMain.ActiveGroup = null;
            this.NarMain.AllowSelectedLink = true;
            this.NarMain.Appearance.Background.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.NarMain.Appearance.Background.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.NarMain.Appearance.Background.Options.UseBackColor = true;
            this.NarMain.BackColor = System.Drawing.Color.White;
            this.NarMain.DataSource = null;
            this.NarMain.DisplayFieldName = "";
            this.NarMain.DisplayFieldNameItem = "";
            //this.NarMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NarMain.EachGroupHasSelectedLink = true;
            this.NarMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NarMain.ForeColor = System.Drawing.Color.Red;
            this.NarMain.KeyFieldName = "";
            this.NarMain.KeyFieldNameItem = "";
            this.NarMain.Location = new System.Drawing.Point(0, 0);
            this.NarMain.LookAndFeel.SkinName = "SkinNav:Office 2007 Blue";
            this.NarMain.Name = "NarMain";
            this.NarMain.NavigationPaneGroupClientHeight = 160;
            this.NarMain.NavigationPaneMaxVisibleGroups = 10;
            this.NarMain.OptionsNavPane.ExpandedWidth = 231;
            this.NarMain.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.NarMain.ParentFieldName = "";
            this.NarMain.ParentFieldNameItem = "";
            this.NarMain.Size = new System.Drawing.Size(231, 426);
            this.NarMain.SkinExplorerBarViewScrollStyle = DevExpress.XtraNavBar.SkinExplorerBarViewScrollStyle.ScrollBar;
            this.NarMain.TabIndex = 0;
            this.NarMain.TableNarbarItem = null;
            this.NarMain.View = new DevExpress.XtraNavBar.ViewInfo.NavigationPaneViewInfoRegistrator();
            // 
            // ucNarMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.NarMain);
            this.Name = "ucNarMain";
            this.Size = new System.Drawing.Size(231, 426);
            ((System.ComponentModel.ISupportInitialize)(this.NarMain)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		public Epoint.Systems.Controls.NarvarControl NarMain;


	}
}
