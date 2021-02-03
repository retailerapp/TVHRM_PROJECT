using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Bpoint.Systems.Librarys;
using Bpoint.Systems.Commons;

namespace Bpoint.Systems.Commons
{
    public class EpointProcessBox : Bpoint.Systems.Controls.frmBase
	{
		#region Fields

		//các thuộc tính điều khiển Lookup
		public bool isLookup = false;
		public string strLookupColumn = string.Empty;
		public string strLookupValue = string.Empty;
		public bool bLookupRequire = true;
		public string strLookupKeyFilter = string.Empty;
        public string strLookupKeyValid = string.Empty;
        public ProgressBar proBarRelease;
        public Controls.txtTextBox txtExpr;
        public Controls.lblControl lblStatus;
        public Controls.btControl btOK;
		public bool bIsEnter = true;

		

		#endregion

		#region Cai dat cac phuong thuc

        public EpointProcessBox()
		{
			InitializeComponent();			
		}
		
		public virtual void Load()
		{

		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessBar));
            this.proBarRelease = new System.Windows.Forms.ProgressBar();
            this.txtExpr = new Bpoint.Systems.Controls.txtTextBox();
            this.lblStatus = new Bpoint.Systems.Controls.lblControl();
            this.btOK = new Bpoint.Systems.Controls.btControl();
            this.SuspendLayout();
            // 
            // proBarRelease
            // 
            this.proBarRelease.Location = new System.Drawing.Point(12, 28);
            this.proBarRelease.Name = "proBarRelease";
            this.proBarRelease.Size = new System.Drawing.Size(482, 23);
            this.proBarRelease.Step = 1;
            this.proBarRelease.TabIndex = 0;
            // 
            // txtExpr
            // 
            this.txtExpr.bEnabled = true;
            this.txtExpr.bReadOnly = false;
            this.txtExpr.bRequire = false;
            this.txtExpr.KeyFilter = "";
            this.txtExpr.Location = new System.Drawing.Point(12, 53);
            this.txtExpr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtExpr.Multiline = true;
            this.txtExpr.Name = "txtExpr";
            this.txtExpr.ReadOnly = true;
            this.txtExpr.Size = new System.Drawing.Size(482, 90);
            this.txtExpr.TabIndex = 2;
            this.txtExpr.Text = "message";
            this.txtExpr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtExpr.UseAutoFilter = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(217, 9);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(51, 16);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Tag = "";
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btOK.Enabled = false;
            this.btOK.Location = new System.Drawing.Point(209, 148);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(78, 28);
            this.btOK.TabIndex = 8;
            this.btOK.Tag = "";
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            // 
            // frmProcessBar
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btOK;
            this.ClientSize = new System.Drawing.Size(506, 179);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtExpr);
            this.Controls.Add(this.proBarRelease);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcessBar";
            this.Text = "Process";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		
		#endregion

		#region Xu ly su kien

		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);

			
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{	
		}
        public void Show()
        {
            ThreadStart thrStart = new ThreadStart(ThreadShow);
            Thread newThread = new Thread(thrStart);
            newThread.Start(); // Dữ liệu truyền vào là một số nguyên 
            Thread.Sleep(0);
        }
        public void SetStatus(string strStatus)
        {
            lblStatus.Text = strStatus;
        }
        public void AddMessage(string strMessage)
        {
            txtExpr.Text = txtExpr.Text + "\n" + strMessage;
        }
        public void ShowOK(bool bshow)
        {
            btOK.Enabled = bshow;
        }
        public void ThreadShow()
        {
            
            this.ShowDialog();
        }
		#endregion

	}	
}
