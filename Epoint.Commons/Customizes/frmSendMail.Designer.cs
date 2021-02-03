using Epoint.Systems.Controls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Epoint.Systems.Customizes
{
	partial class frmChart
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
            this.SuspendLayout();
            // 
            // frmChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);


            this.txtfilename = new txtTextLookup();
            this.lblPath = new lblControl();
            this.btgAccept = new btgAccept();
            this.cboExportType = new cboControl();
            this.lblControl1 = new lblControl();
            base.SuspendLayout();
            this.txtfilename.AutoFilter = null;
            this.txtfilename.bEnabled = true;
            this.txtfilename.bReadOnly = false;
            this.txtfilename.Location = new Point(0x76, 0x41);
            this.txtfilename.Margin = new Padding(2, 0, 2, 2);
            this.txtfilename.Name = "txtfilename";
            this.txtfilename.bRequire = false;
            this.txtfilename.Size = new Size(0xd6, 20);
            this.txtfilename.KeyFilter = "";
            this.txtfilename.TabIndex = 1;
            this.txtfilename.UseAutoFilter = false;
            this.lblPath.AutoEllipsis = true;
            this.lblPath.AutoSize = true;
            this.lblPath.BackColor = Color.Transparent;
            this.lblPath.Location = new Point(15, 0x43);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new Size(0x3a, 13);
            this.lblPath.TabIndex = 2;
            this.lblPath.Tag = "filename";
            this.lblPath.Text = "Tìm tập tin";
            this.lblPath.TextAlign = ContentAlignment.MiddleLeft;
            this.btgAccept.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btgAccept.BackColor = Color.Transparent;
            this.btgAccept.Location = new Point(0x97, 0x94);
            this.btgAccept.Name = "btgAccept";
            this.btgAccept.Size = new Size(0xb5, 0x1d);
            this.btgAccept.TabIndex = 7;
            this.cboExportType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboExportType.FormattingEnabled = true;
            this.cboExportType.Items.AddRange(new object[] { "1 - Export to MS excel", "2 - Export to MS word", "3 - Export to PDF type" });
            this.cboExportType.Location = new Point(0x76, 0x1c);
            this.cboExportType.Margin = new Padding(2, 0, 2, 2);
            this.cboExportType.Name = "cboExportType";
            this.cboExportType.Size = new Size(0xd6, 0x15);
            this.cboExportType.strValueList = "";
            this.cboExportType.TabIndex = 0;
            this.cboExportType.UseAutoComplete = false;
            this.lblControl1.AutoEllipsis = true;
            this.lblControl1.AutoSize = true;
            this.lblControl1.BackColor = Color.Transparent;
            this.lblControl1.Location = new Point(15, 0x1f);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new Size(0x61, 13);
            this.lblControl1.TabIndex = 2;
            this.lblControl1.Tag = "Format";
            this.lblControl1.Text = "Định dạng kết xuất";
            this.lblControl1.TextAlign = ContentAlignment.MiddleLeft;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x160, 0xbd);
            base.Controls.Add(this.cboExportType);
            base.Controls.Add(this.btgAccept);
            base.Controls.Add(this.lblControl1);
            base.Controls.Add(this.lblPath);
            base.Controls.Add(this.txtfilename);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmSendMail";
            base.Tag = "frmSendMail";
            this.Text = "frmSendMail";
            base.ResumeLayout(false);
            base.PerformLayout();


		}
        // Fields
        private btgAccept btgAccept;
        public cboControl cboExportType;
        private lblControl lblControl1;
        private lblControl lblPath;       
        private txtTextLookup txtfilename;

		#endregion

	}
}