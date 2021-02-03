namespace Epoint.Controllers
{
	partial class frmResource_File
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
            this.cboFile_Type = new Epoint.Systems.Controls.cboControl();
            this.lbtFile_Tag1 = new Epoint.Systems.Controls.lblControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlControl2.SuspendLayout();
            this.splControl1.Panel2.SuspendLayout();
            this.splControl1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splControl1
            // 
            this.splControl1.Size = new System.Drawing.Size(943, 569);
            this.splControl1.SplitterDistance = 508;
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
            this.cboFile_Type.Location = new System.Drawing.Point(97, 8);
            this.cboFile_Type.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.cboFile_Type.Name = "cboFile_Type";
            this.cboFile_Type.Size = new System.Drawing.Size(150, 21);
            this.cboFile_Type.strValueList = null;
            this.cboFile_Type.TabIndex = 5;
            this.cboFile_Type.UseAutoComplete = false;
            this.cboFile_Type.UseBindingValue = false;
            // 
            // lbtFile_Tag1
            // 
            this.lbtFile_Tag1.AutoEllipsis = true;
            this.lbtFile_Tag1.AutoSize = true;
            this.lbtFile_Tag1.BackColor = System.Drawing.Color.Transparent;
            this.lbtFile_Tag1.Location = new System.Drawing.Point(31, 13);
            this.lbtFile_Tag1.Name = "lbtFile_Tag1";
            this.lbtFile_Tag1.Size = new System.Drawing.Size(61, 13);
            this.lbtFile_Tag1.TabIndex = 4;
            this.lbtFile_Tag1.Tag = "File_Tag";
            this.lbtFile_Tag1.Text = "Loại dữ liệu";
            this.lbtFile_Tag1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cboFile_Type);
            this.splitContainer1.Panel1.Controls.Add(this.lbtFile_Tag1);
            this.splitContainer1.Size = new System.Drawing.Size(943, 569);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 6;
            // 
            // frmResource_File
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 569);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmResource_File";
            this.Object_ID = "LIBOPHAN";
            this.Tag = "frmResource_File,F2,F3,F6,F8,ESC";
            this.Text = "frmResource_File";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.splControl1, 0);
            this.pnlControl2.ResumeLayout(false);
            this.splControl1.Panel2.ResumeLayout(false);
            this.splControl1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private Systems.Controls.lblControl lbtFile_Tag1;
        private Systems.Controls.cboControl cboFile_Type;
        private System.Windows.Forms.SplitContainer splitContainer1;

	}
}