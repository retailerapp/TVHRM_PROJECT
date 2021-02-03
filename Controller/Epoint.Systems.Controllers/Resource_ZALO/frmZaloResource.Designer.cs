namespace Epoint.Controllers
{
    partial class frmZaloResource
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
            this.splitContainer_Resource = new System.Windows.Forms.SplitContainer();
            this.cboFile_Type = new Epoint.Systems.Controls.cboControl();
            this.lbtFile_Tag1 = new Epoint.Systems.Controls.lblControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Resource)).BeginInit();
            this.splitContainer_Resource.Panel1.SuspendLayout();
            this.splitContainer_Resource.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_Resource
            // 
            this.splitContainer_Resource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Resource.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Resource.Name = "splitContainer_Resource";
            this.splitContainer_Resource.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Resource.Panel1
            // 
            this.splitContainer_Resource.Panel1.Controls.Add(this.cboFile_Type);
            this.splitContainer_Resource.Panel1.Controls.Add(this.lbtFile_Tag1);
            this.splitContainer_Resource.Size = new System.Drawing.Size(792, 569);
            this.splitContainer_Resource.SplitterDistance = 40;
            this.splitContainer_Resource.TabIndex = 0;
            // 
            // cboFile_Type
            // 
            this.cboFile_Type.AutoCompleteCustomSource.AddRange(new string[] {
            "IMG",
            "XLS",
            "DOC",
            "EXE"});
            this.cboFile_Type.FormattingEnabled = true;
            this.cboFile_Type.InitValue = null;
            this.cboFile_Type.Location = new System.Drawing.Point(131, 9);
            this.cboFile_Type.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboFile_Type.Name = "cboFile_Type";
            this.cboFile_Type.Size = new System.Drawing.Size(150, 21);
            this.cboFile_Type.strValueList = null;
            this.cboFile_Type.TabIndex = 5;
            this.cboFile_Type.UpperCase = false;
            this.cboFile_Type.UseAutoComplete = false;
            this.cboFile_Type.UseBindingValue = false;
            // 
            // lbtFile_Tag1
            // 
            this.lbtFile_Tag1.AutoEllipsis = true;
            this.lbtFile_Tag1.AutoSize = true;
            this.lbtFile_Tag1.BackColor = System.Drawing.Color.Transparent;
            this.lbtFile_Tag1.Location = new System.Drawing.Point(57, 13);
            this.lbtFile_Tag1.Name = "lbtFile_Tag1";
            this.lbtFile_Tag1.Size = new System.Drawing.Size(61, 13);
            this.lbtFile_Tag1.TabIndex = 4;
            this.lbtFile_Tag1.Tag = "File_Tag";
            this.lbtFile_Tag1.Text = "Loại dữ liệu";
            this.lbtFile_Tag1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmZaloResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 569);
            this.Controls.Add(this.splitContainer_Resource);
            this.Name = "frmZaloResource";
            this.Object_ID = "LIBOPHAN";
            this.Tag = "frmResource,F2,F3,F6,F8,ESC";
            this.Text = "frmResource";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer_Resource.Panel1.ResumeLayout(false);
            this.splitContainer_Resource.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Resource)).EndInit();
            this.splitContainer_Resource.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.SplitContainer splitContainer_Resource;
        private Systems.Controls.cboControl cboFile_Type;
        private Systems.Controls.lblControl lbtFile_Tag1;

	}
}