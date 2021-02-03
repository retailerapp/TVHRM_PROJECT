using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Epoint.Systems.Librarys;
using Epoint.Systems.Customizes;
using Epoint.Systems.Commons;

namespace Epoint.Systems.Commons
{
    public class frmProcessBar : Epoint.Systems.Controls.frmBase
    {
        #region Fields

        public ProgressBar proBarRelease;
        public Controls.txtTextBox txtExpr;
        public Controls.lblControl lblStatus;
        public Controls.btControl btOK;
        public bool bIsEnter = true;
        Thread newThread;
        System.Threading.Thread thread = null;
        Thread thrPro = null;
        private System.Windows.Forms.Timer TimerProcess = null;
        private PictureBox pictureBox1;
        frmView frm;

        #endregion

        #region Cai dat cac phuong thuc

        public frmProcessBar()
        {
            InitializeComponent();
            btOK.Click += new EventHandler(btOK_Click);
            proBarRelease.PerformStep();
        }
        public frmProcessBar(frmView frm)
        {
            InitializeComponent();
            this.frm = frm;
            btOK.Click += new EventHandler(btOK_Click);
            proBarRelease.PerformStep();
            this.Refresh();
        }
        void btOK_Click(object sender, EventArgs e)
        {
            bIsEnter = false;
            this.Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            lock (this)
            {
                base.OnLoad(e);
                this.Show();
                this.Enabled = false;
                this.pictureBox1.Visible = false;
                //TimerProcess = new System.Windows.Forms.Timer();
                //TimerProcess.Interval = 1000;
                //TimerProcess.Start();
                //TimerProcess.Tick += new EventHandler(TimerProcess_Tick);
                //thrPro = new Thread(new ThreadStart(ThreadPro));
                //thrPro.Start();
                frm.EpointRelease();
                proBarRelease.Value = proBarRelease.Maximum;
                //TimerProcess.Stop();
                this.Enabled = true;
                this.btOK.Enabled = true;
                //this.pictureBox1.Visible = false;
                this.Refresh();
                //ThreadStart thrStart = new ThreadStart(ThreadShow);
                //newThread = new Thread(thrStart);
                //newThread.Start(); // Dữ liệu truyền vào là một số nguyên 
                //txtExpr.Text = string.Empty;
                //Thread.Sleep(0);

                //this.Activate();
                //thread = new System.Threading.Thread(new System.Threading.ThreadStart(Start));
                //thread.IsBackground = false;
                //thread.ApartmentState = System.Threading.ApartmentState.STA;
                //thread.Start();
            }
        }
        public virtual void Load()
        {

        }
        
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessBar));
            this.proBarRelease = new System.Windows.Forms.ProgressBar();
            this.txtExpr = new Epoint.Systems.Controls.txtTextBox();
            this.lblStatus = new Epoint.Systems.Controls.lblControl();
            this.btOK = new Epoint.Systems.Controls.btControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // proBarRelease
            // 
            this.proBarRelease.Location = new System.Drawing.Point(14, 30);
            this.proBarRelease.Name = "proBarRelease";
            this.proBarRelease.Size = new System.Drawing.Size(482, 35);
            this.proBarRelease.Step = 1;
            this.proBarRelease.TabIndex = 0;
            // 
            // txtExpr
            // 
            this.txtExpr.bEnabled = true;
            this.txtExpr.bIsLookup = false;
            this.txtExpr.bReadOnly = false;
            this.txtExpr.bRequire = false;
            this.txtExpr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtExpr.ForeColor = System.Drawing.Color.Red;
            this.txtExpr.KeyFilter = "";
            this.txtExpr.Location = new System.Drawing.Point(13, 65);
            this.txtExpr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.txtExpr.Multiline = true;
            this.txtExpr.Name = "txtExpr";
            this.txtExpr.ReadOnly = true;
            this.txtExpr.Size = new System.Drawing.Size(482, 171);
            this.txtExpr.TabIndex = 2;
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
            this.lblStatus.Tag = "Status";
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btOK.Enabled = false;
            this.btOK.Image = global::Epoint.Systems.Commons.Properties.Resources.accepted1;
            this.btOK.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btOK.Location = new System.Drawing.Point(205, 240);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(85, 30);
            this.btOK.TabIndex = 8;
            this.btOK.Tag = "OK";
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Epoint.Systems.Commons.Properties.Resources.loadingQ;
            this.pictureBox1.Location = new System.Drawing.Point(403, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // frmProcessBar
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btOK;
            this.ClientSize = new System.Drawing.Size(506, 271);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtExpr);
            this.Controls.Add(this.proBarRelease);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcessBar";
            this.Tag = "PROCESS";
            this.Text = "Process";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        #region Xu ly su kien
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (bIsEnter)
                e.Cancel = true;
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
        }
        public void SetStatus(string strStatus)
        {
            this.lblStatus.Text = strStatus;
        }
        public void AddMessage(string strMessage)
        {
            txtExpr.Text = txtExpr.Text + "\r\n" + strMessage;
            txtExpr.SelectionStart = txtExpr.Text.Length;
            this.Refresh();
            txtExpr.ScrollToCaret();
            txtExpr.Focus();
            txtExpr.Refresh();
            this.Refresh();
            if (proBarRelease.Value < proBarRelease.Maximum)
            {
                proBarRelease.Value ++;
            }
        }
        public void ThreadShow()
        {
            
            
        }
        public void ThreadPro()
        {

            
        }

        void TimerProcess_Tick(object sender, EventArgs e)
        {
            
        }
        public void setValue(int iValue)
        {
            if (iValue <= proBarRelease.Maximum)
                proBarRelease.Value = iValue;
        }
        public void setMaxValue(int iMaxValue)
        {

            proBarRelease.Maximum = iMaxValue;
        }
       
        #endregion

    }
}
