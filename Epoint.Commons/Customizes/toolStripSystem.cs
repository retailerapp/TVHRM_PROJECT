using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;
using Epoint.Systems.Resources;
using Epoint.Systems.Commons;

namespace Epoint.Systems.Customizes
{
    public class toolStripSystem : Epoint.Systems.Controls.tsControl
    {
        //public tscbYear tscbYear;
        //public tsbtYear tsbtYear;
        //public tsbLanguage tsbLanguage;
        public tsbDateTime tsbDateTime;
        public tsbDvCs tsbDvCs;
        public tsbHelp tsbHelp;
        public tsbCalc tsbCalc;
        public tsbTeamviewr tsbTeam;
        public tsbRestart tsbRestart;
        public tsbExit tsbExit;

        public toolStripSystem()
        {

            if (!Element.Is_Running)
                return;

            //tscbYear = new tscbYear();
            //tsbtYear = new tsbtYear();
            //tsbLanguage = new tsbLanguage();
            tsbDvCs = new tsbDvCs();
            tsbHelp = new tsbHelp();
            tsbCalc = new tsbCalc();
            tsbTeam = new tsbTeamviewr();
            tsbRestart = new tsbRestart();
            tsbExit = new tsbExit();
            tsbDateTime = new tsbDateTime();

            //this.Items.Add(tscbYear);
            //this.Items.Add(tsbtYear);
            this.Items.Add(tsbTeam);
            //this.Items.Add(tsbDateTime);
            //this.Items.Add(tsbLanguage);            
            //this.Items.Add(new ToolStripSeparator());
            this.Items.Add(tsbDvCs);
            //this.Items.Add(tsbHelp);
            this.Items.Add(tsbCalc);
            //this.Items.Add(tsbTeam);
            this.Items.Add(tsbRestart);
            this.Items.Add(tsbExit);
            //this.Items.Add(new ToolStripSeparator());

            //this.tsbLanguage.Click += new EventHandler(tsbLanguage_Click);
            this.tsbCalc.Click += new EventHandler(tsbCalc_Click);
            this.tsbRestart.Click += new EventHandler(tsbRestart_Click);
            this.tsbExit.Click += new EventHandler(tsbExit_Click);
            this.tsbDvCs.Click += new EventHandler(tsbDvCs_Click);
            this.tsbTeam.Click+= new EventHandler(tsbTeam_Click);
            
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);

            if (this.FindForm() != null)
            {
                if (this.FindForm().GetType().Name == "frmMain")
                {

                    //this.tsbtYear.Enabled = true;
                    this.tsbDvCs.Enabled = true;
                    this.tsbRestart.Visible = true;
                    this.tsbExit.Visible = true;

                }
            }
        }

        public void Restart()
        {
            Application.Restart();
        }

        public void Exit()
        {
            Application.Exit();

        }


        void tsbDvCs_Click(object sender, EventArgs e)
        {
            string strDvcsOld = Element.sysMa_DvCs;
            frmMain frmMain = (frmMain)this.FindForm();

            tsmiControl tsmiDvCs = Common.FindTsmi(frmMain.msMain, 7004);

            Common.RunMethod(tsmiDvCs);
            if (strDvcsOld == Element.sysMa_DvCs)
                return;
            Common.CloseAllForm(frmMain);
        }

        //void tsbLanguage_Click(object sender, EventArgs e)
        //{
        //    char cLanguage = 'V';

        //    switch (Convert.ToChar(this.tsbLanguage.Text.Trim()))
        //    {
        //        case 'V':
        //            cLanguage = 'E';  // tiếng anh
        //            break;

        //        case 'E':
        //            cLanguage = 'O';  // tiếng hoa
        //            break;

        //        case 'O':
        //            cLanguage = 'V';  // tiếng Việt
        //            break;
                
        //        default:
        //            cLanguage = 'V'; // tiếng việt
        //            break;
        //    }

        //    Common.SetSysLanguage(cLanguage);
           

            
        //}

        void tsbCalc_Click(object sender, EventArgs e)
        {
            if (this.FindForm().ActiveMdiChild != null)
                ((frmBase)this.FindForm().ActiveMdiChild).ShowCalc();
            else
                ((frmBase)this.FindForm()).ShowCalc();
        }

        void tsbTeam_Click(object sender, EventArgs e)
        {
            try
            {
                string strFilePath;// (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "Local Settings", @"C:\") + @"\Temp\TeamViewerQS.exe";
                strFilePath = Application.StartupPath + @"\\TeamViewerEP.exe";

                //if (!System.IO.File.Exists(strFilePath))
                //    System.IO.File.WriteAllBytes(strFilePath, Resources.Resource.TeamViewer_Epoint);

                if (System.IO.File.Exists(strFilePath))
                    System.Diagnostics.Process.Start(strFilePath);
            }
            catch { }

        }
        void tsbRestart_Click(object sender, EventArgs e)
        {
            this.Restart();
        }

        void tsbExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            EpointMethod.UpdateDataLics();
            
            this.Exit();
        }

        
    }

    public class tscbYear : ToolStripComboBox
    {

        public tscbYear()
        {
            if (!Element.Is_Running)
                return;

            this.Padding = new Padding(1);
            this.AutoSize = false;
            this.Width = 80;
            //this.Height = 80;
            this.FlatStyle = FlatStyle.Popup;
            this.ComboBox.TabStop = false;
            this.Overflow = ToolStripItemOverflow.AsNeeded;
            this.ComboBox.Capture = false;

            this.ToolTipText = Languages.GetLanguage("Working_Year");
            this.Text = Languages.GetLanguage("Working_Year");

            DataTable dtNam = DataTool.SQLGetDataTable("SYSNAM", "", "Ma_DvCs = '" + Element.sysMa_DvCs + "'", "Nam");

            if (dtNam.Rows.Count > 0)
            {
                for (int i = 0; i <= dtNam.Rows.Count - 1; i++)
                {
                    DataRow dr = dtNam.Rows[i];

                    this.Items.Add((int)dr["Nam"]);

                    if (Element.sysWorkingYear == (int)dr["Nam"])
                    {
                        this.SelectedIndex = i;
                    }
                }
            }
            else
            {
                this.Items.Add(DateTime.Now.Year);
                this.SelectedIndex = 0;
            }
        }
    }

    //public class tsbtYear : ToolStripButton
    //{//Chua tim dc cach ReadOnly, va LostFocus khi mat con tro

    //    public tsbtYear()
    //    {
    //        if (!Element.Is_Running)
    //            return;

    //        this.Padding = new Padding(1);
    //        this.AutoSize = false;
    //        this.Width = 80;
    //        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    //        this.ForeColor = Color.Blue;
    //        this.Overflow = ToolStripItemOverflow.AsNeeded;
    //        this.CheckState = CheckState.Checked;
    //        this.TextAlign = ContentAlignment.MiddleLeft;
    //        this.ToolTipText = Languages.GetLanguage("Working_Year");

    //        this.Text = Element.sysWorkingYear.ToString().Trim();
    //    }
    //}


    //public class tsbLanguage : tsbControl
    //{
    //    public tsbLanguage()
    //    {
    //        this.DisplayStyle = ToolStripItemDisplayStyle.Text;
    //        this.Text = ((char)Element.sysLanguage).ToString();
    //        this.TextAlign = ContentAlignment.MiddleCenter;
    //        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    //        this.ForeColor = Elements.ColorTable.TextLanguageV;
    //        this.ToolTipText = Languages.GetLanguage("Language");
    //    }
    //}
    public class tsbDateTime : tsbControl
    {
        public tsbDateTime()
        {
            this.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.Text = DateTime.Now.ToString();
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Elements.ColorTable.TextLanguageV;
            this.ToolTipText = Languages.GetLanguage("Language");
        }
    }
    public class tsbDvCs : tsbControl
    {
        public tsbDvCs()
        {
            Bitmap bmp = new Bitmap(Resources.Resource.Home, this.Size);

            this.Image = bmp;
            this.ToolTipText = Languages.GetLanguage("Business_Cell");
            this.Text = Languages.GetLanguage("Business_Cell");

        }
    }

    public class tsbCalc : tsbControl
    {
        public tsbCalc()
        {
            Bitmap bmp = new Bitmap(Resources.Resource.Calc, this.Size);

            this.Image = bmp;
            this.ToolTipText = Languages.GetLanguage("Calculator");
            this.Text = Languages.GetLanguage("Calculator");
        }
    }
    public class tsbTeamviewr : tsbControl
    {
        public tsbTeamviewr()
        {
            Bitmap bmp = new Bitmap(Resources.Resource.Teamviewer_48, this.Size);

            this.Image = bmp;
            this.ToolTipText = Languages.GetLanguage("Teamviewer");
            this.Text = Languages.GetLanguage("Teamviewer");
        }
    }

    public class tsbHelp : tsbControl
    {
        public tsbHelp()
        {
            Bitmap bmp = new Bitmap(Resources.Resource.help_48, this.Size);

            this.Image = bmp;
            this.ToolTipText = Languages.GetLanguage("Help");
        }
    }

    public class tsbRestart : tsbControl
    {
        public tsbRestart()
        {
            Bitmap bmp = new Bitmap(Resources.Resource.Reload, this.Size);

            this.Image = bmp;
            this.ToolTipText = Languages.GetLanguage("Restart");
            this.Text = Languages.GetLanguage("Khoi_Dong");
        }
    }

    public class tsbExit : tsbControl
    {
        public tsbExit()
        {
            Bitmap bmp = new Bitmap(Resources.Resource.exit, this.Size);

            this.Image = bmp;
            this.ToolTipText = Languages.GetLanguage("ExitProgram");
            this.Text = Languages.GetLanguage("Thoat");
        }
    }

    public class tsbClose : tsbControl
    {
        public tsbClose()
        {
            Bitmap bmp = new Bitmap(Resources.Resource.Exit1, this.Size);

            this.Image = bmp;
            this.ToolTipText = Languages.GetLanguage("Close");
        }
    }
}
