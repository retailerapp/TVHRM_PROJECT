using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;

namespace Epoint.Systems.Customizes
{
    public class statusStripMain : StatusStrip
    {
        public UcModuleManagement ucModuleManagement = new UcModuleManagement();
         

        public ToolStripProgressBar tsipProgress = new ToolStripProgressBar();

        public tsilStatus tsilStatus = new tsilStatus();
        public tsilServer tsilServer = new tsilServer();
        public tsilUser tsilUser = new tsilUser();
        public tsilDateTime tsilDateTime = new tsilDateTime();
        public tsilPartition tsilPartition = new tsilPartition();
        public tsilDatabase tsilDatabase = new tsilDatabase();
        public tsilReminder tsilReminder = new tsilReminder();
        public tsiLanguage tsiLanguage = new tsiLanguage();
        public tsbtYear tsbtYear = new tsbtYear();
        public ImageList imageList1;
        private System.ComponentModel.IContainer components;
        //Timer tmProcess = new Timer();
        bool bprocess = false;
        Thread text;
        public statusStripMain()
        {
            InitializeComponent();

            this.RightToLeft = RightToLeft.No;
            this.AutoSize = false;
            this.Dock = DockStyle.Bottom;
            this.ImageList = imageList1;
            this.tsipProgress.Width = 1000;
            //tmProcess.Interval = 1000;
            text = new Thread(new ThreadStart(RunInThread));
            //text.Start();
            this.tsipProgress.Increment(1);
            this.tsipProgress.Maximum = 100;
            //tmProcess.Tick += new EventHandler(tmProcess_Tick);
            Element.sysTimer.Interval = 1000;
            Element.sysTimer.Tick += new EventHandler(sysTimer_Tick);
            this.tsilReminder.Click += new EventHandler(tsilReminder_Click);
            this.tsiLanguage.Click += new EventHandler(tsiLanguage_Click);

            //LoadItem
            this.Items.Add(tsilStatus);

            this.Items.Add(new tsiLabelSeparater());
            this.Items.Add(tsipProgress);
            this.Items.Add(tsilReminder);
            this.Items.Add(tsbtYear);
            this.Items.Add(tsiLanguage);

            //this.Items.Add(tsilServer);
            this.Items.Add(tsilDatabase);
            this.Items.Add(tsilUser);
            this.Items.Add(tsilDateTime);

            this.tsipProgress.Visible = false;
            this.tsilReminder.Visible = false;
        }

        void tsilReminder_Click(object sender, EventArgs e)
        {
            //Commons.Common.AddObjectOnCurentTab(ucModuleManagement);
        }

        void tsiLanguage_Click(object sender, EventArgs e)
        {
            char cLanguage = 'V';

            switch (Convert.ToChar(this.tsiLanguage.Text.Trim()))
            {
                case 'V':
                    cLanguage = 'E';  // tiếng anh                    
                    this.tsiLanguage.ImageKey = "Language_E";
					break;

                case 'E':
                    cLanguage = 'O';  // tiếng hoa                    
                    this.tsiLanguage.ImageKey = "Language_O";
					break;

                case 'O':
                    cLanguage = 'V';  // tiếng Việt
                    this.tsiLanguage.ImageKey = "Language_V";
					break;

                default:
                    cLanguage = 'V'; // tiếng việt
                    this.tsiLanguage.ImageKey = "Language_V";
					break;
            }

            Common.SetSysLanguage(cLanguage);
        }

        void RunInThread()
        {
            if (bprocess)
            {
                //this.tsilDateTime.Text = this.tsilDateTime.Text + "a";
            }
        }

        public void ShowStatus(string strStatusText)
        {

            this.bprocess = true;
            this.tsilStatus.Text = strStatusText.Trim();
            this.text = new Thread(new ThreadStart(RunInThread));
            this.text.Start();

            this.tsipProgress.Value = 80;
            this.tsipProgress.ToolTipText = "Đang xử lý...";
            this.Refresh();
        }

        public void EndShowStatus()
        {
            this.tsilStatus.Text = "Epoint Software Solution";
            if (Parameters.GetParaValue("EPOINTSOLUTION") != null)
                this.tsilStatus.Text = (string)Parameters.GetParaValue("EPOINTSOLUTION");
            //this.text.Abort();
            this.tsipProgress.Value = 100;
            bprocess = false;
        }

        void sysTimer_Tick(object sender, EventArgs e)
        {
            this.tsilDateTime.Text = DateTime.Now.ToString();

            if (Element.Reminder_count > 0)
            {
                if (this.tsilReminder.ForeColor == ColorTable.TextStatusReminder)
                {
                    this.tsilReminder.ForeColor = ColorTable.TextStatusReminder_Acctive;

                }
                else
                {
                    this.tsilReminder.ForeColor = ColorTable.TextStatusReminder;
                    //this.tsilReminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
                }
            }
            else
                this.tsilReminder.ForeColor = ColorTable.TextStatusReminder;
            //
            //if (true)
            //{
            //    this.tsilReminder.ImageKey = "Nhac_Viec";
            //    this.tsilReminder.ForeColor = ColorTable.TextStatusReminder_Acctive;
            //    this.tsilReminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            //}
            //else
            //{
            //    this.tsilReminder.ImageKey = "Nhac_Viec_Active";
            //    this.tsilReminder.ForeColor = ColorTable.TextStatusReminder_Acctive;
            //    this.tsilReminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            //}
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(statusStripMain));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Database");
            this.imageList1.Images.SetKeyName(1, "User");
            this.imageList1.Images.SetKeyName(2, "server");
            this.imageList1.Images.SetKeyName(3, "Clock");
            this.imageList1.Images.SetKeyName(4, "Partition");
            this.imageList1.Images.SetKeyName(5, "Reminder");
            this.imageList1.Images.SetKeyName(6, "Nhac_Viec");
            this.imageList1.Images.SetKeyName(7, "Nhac_Viec_Active");
            this.imageList1.Images.SetKeyName(8, "Language_E.png");
            this.imageList1.Images.SetKeyName(9, "Language_O.png");
            this.imageList1.Images.SetKeyName(10, "Language_V.png");
            this.ResumeLayout(false);

        }

  }

    public class tsiLabelSeparater : ToolStripStatusLabel
    {
        public tsiLabelSeparater()
        {
            this.Spring = true;
        }
    }

    public class tsilStatus : tsslControl
    {
        public tsilStatus()
        {
            this.Text = "Epoint Software Solution ";
            if (Parameters.GetParaValue("EPOINTSOLUTION") != null)
                this.Text = (string)Parameters.GetParaValue("EPOINTSOLUTION");
            this.ForeColor = Elements.ColorTable.TextStatusProcess;
            this.AutoSize = true;
            this.ImageKey = "Status";
        }
    }

    public class tsilServer : tsslControl
    {
        public tsilServer()
        {
            this.Text = Element.sysConnection.DataSource;
            this.ForeColor = Elements.ColorTable.TextStatusServer;
            this.Alignment = ToolStripItemAlignment.Right;
            this.RightToLeft = RightToLeft.No;
            //this.Width = 100;
            this.AutoSize = true;
            this.ImageKey = "Server";
        }
    }
    public class tsilDatabase : tsslControl
    {
        public tsilDatabase()
        {
            this.Text = Element.sysConnection.Database;
            this.ForeColor = Elements.ColorTable.TextStatusDatabase;
            this.Alignment = ToolStripItemAlignment.Right;
            this.RightToLeft = RightToLeft.No;
            //this.Width = 100;
            this.AutoSize = true;
            this.ImageKey = "Database";
        }
    }
    public class tsilUser : tsslControl
    {
        public tsilUser()
        {
            this.Text = Element.sysUser_Id;
            this.Alignment = ToolStripItemAlignment.Right;
            this.RightToLeft = RightToLeft.No;
            //this.Width = 100;
            this.AutoSize = true;
            this.ImageKey = "User";
        }
    }

    public class tsilDateTime : tsslControl
    {
        public tsilDateTime()
        {
            this.Text = DateTime.Now.ToString();
            this.ForeColor = Elements.ColorTable.TextStatusDatetime;
            this.Alignment = ToolStripItemAlignment.Right;
            this.RightToLeft = RightToLeft.No;
            //this.AutoSize = true;
            this.AutoSize = true;
            this.ImageKey = "Clock";
        }
    }

    public class tsilPartition : tsslControl
    {
        public tsilPartition()
        {
            this.Alignment = ToolStripItemAlignment.Right;
            this.RightToLeft = RightToLeft.No;
            this.Width = 200;
            this.ImageKey = "Partition";

            //Hiển thị Partition
            this.Text = Commons.Common.GetPartitionCurrent().ToString();
        }
    }
    public class tsilReminder : tsslControl
    {
        public tsilReminder()
        {
            this.Text = Languages.GetLanguage("Reminder");
            this.Alignment = ToolStripItemAlignment.Right;
            this.RightToLeft = RightToLeft.No;
            this.Width = 100;
            this.ImageKey = "Nhac_Viec";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif",10F ,System.Drawing.FontStyle.Bold);
        }
    }

    public class tsiLanguage : tsslControl
    {
        public tsiLanguage()
        {
            this.Text = ((char)Element.sysLanguage).ToString();
            this.Alignment = ToolStripItemAlignment.Left;
            this.RightToLeft = RightToLeft.No;
            this.AutoSize = false;
            this.Width = 70;
            if (Element.sysLanguage == enuLanguageType.Vietnamese)
                this.ImageKey = "Language_V";
            if (Element.sysLanguage == enuLanguageType.English)
                this.ImageKey = "Language_E";
            if (Element.sysLanguage == enuLanguageType.Other)
                this.ImageKey = "Language_O";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Elements.ColorTable.TextLanguageV;
        }
    }
    public class tsbtYear : ToolStripButton
    {//Chua tim dc cach ReadOnly, va LostFocus khi mat con tro

        public tsbtYear()
        {
            if (!Element.Is_Running)
                return;

            Bitmap bmp = new Bitmap(Resources.Resource.Year, this.Size);

            this.Padding = new Padding(1);
            this.AutoSize = false;
            this.Width = 70;
            this.Image = bmp;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Color.Blue;
            this.Overflow = ToolStripItemOverflow.AsNeeded;
            this.CheckState = CheckState.Checked;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.ToolTipText = Languages.GetLanguage("Working_Year");

            this.Text = Element.sysWorkingYear.ToString().Trim();
        }
    }


}
