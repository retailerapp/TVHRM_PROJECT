using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Controls;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Elements;
using Epoint.Systems.Customizes;
using Microsoft.Win32;

namespace Epoint
{
    public partial class frmMain : Epoint.Systems.Customizes.frmMain
    {
        private bool bConnectionError = false;
        private int UcModuleHeight = 0;
        Point pUcModule = new Point(0, 0);
        public frmMain()
        {
            InitializeComponent();

            if (Element.Is_Running)
                this.Load();
            
            this.KeyDown += new KeyEventHandler(frmMain_KeyDown);
            this.ucModuleManagement.lvReminder.DoubleClick += new EventHandler(lvReminder_DoubleClick);
            this.ucModuleManagement.lvReminder.KeyDown += new KeyEventHandler(lvReminder_KeyDown);
            this.ssMain.tsilReminder.Click += new EventHandler(tsilReminder_Click);
        }



        public new void Load()
        {
            
            this.LoadToolStrip();
            this.BindingLanguage();

            Element.frmMain = this;
            Element.frmActiveMain = this;
            Element.Is_FrmEditRunning = false;

            tsmiControl tsmi;

            tsmi = new tsmiControl("0. Quản trị hệ thống");
            tsmi.Name = "Main";
            tsmi.frmInstance = Element.frmMain;
            this.ucModuleManagement.AddMenuItem(tsmi);
            this.UcModuleHeight = this.ucModuleManagement.iOrgHeight;
            this.pUcModule = this.ucModuleManagement.Location;
            //Reminder
            //this.SetReminder();
            this.timer1.Tick += new EventHandler(Timer1_Tick);

            if (Collection.Parameters.ContainsKey("TIMER_INTERVAL"))
                this.timer1.Interval = Convert.ToInt32(Collection.Parameters["TIMER_INTERVAL"]);
            else
                this.timer1.Interval = 300000;



        }

        void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.Visible && this.ucModuleManagement.Visible)
                this.SetReminder();
        }

        public void SetReminder()
        {
            if (bConnectionError)
                return;

            Hashtable htPara = new Hashtable();
            htPara.Add("MEMBER_ID", Element.sysUser_Id);
            htPara.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            DataTable dtReminder;

            dtReminder = SQLExec.ExecuteReturnDt("sp_GetReminder", htPara, CommandType.StoredProcedure);
            int iRemider_count = (int)Common.SumDCValue(dtReminder, "Remider_count", "");
            Element.Reminder_count = iRemider_count;
            if (dtReminder == null)
            {
                bConnectionError = true;
                return;
            }

            int i = 0;

            if (dtReminder != null)
            {
                foreach (DataRow dr in dtReminder.Rows)
                {

                    if (Common.CheckPermission(dr["Reminder_ID"].ToString(), enuPermission_Type.Allow_Access))
                    {
                        if (base.ucModuleManagement.lvReminder.Items.Count <= i)
                        {
                            ListViewItem item = new ListViewItem((string)dr["Description"])
                            {
                                Name = dr["Stt"].ToString(),
                                ImageKey = "Bullet"
                            };

                            this.ucModuleManagement.lvReminder.Items.Add(item);
                        }
                        else
                        {
                            this.ucModuleManagement.lvReminder.Items[i].Text = (string)dr["Description"];
                        }

                        i++;
                    }
                }
            }
        }

        public void ViewReminder()
        {


            if (base.ucModuleManagement.lvReminder.SelectedItems[0].Name == "8")
            {
                if (Common.tabPageExistsOnMain("Remindertodo"))
                {
                    Form form = (Form)Common.RunMethod("Epoint.Modules.CRM:Modules.CRM.frmToDo:Load", null);
                    Common.AddFormOnTab(form, "Remindertodo","Reminder");
                }
            }
            else if (Common.Inlist(base.ucModuleManagement.lvReminder.SelectedItems[0].Name, "1,2,4") && Common.tabPageExistsOnMain("Reminder"))
            {
                object[] objPara = new object[] { Convert.ToInt16(base.ucModuleManagement.lvReminder.SelectedItems[0].Name) };
                Form form2 = (Form)Common.RunMethod("Epoint.Controllers:Controllers.frmReminder:Load", objPara);
                Common.AddFormOnTab(form2, "Reminder", "Reminder");
            }


        }

        void tsilReminder_Click(object sender, EventArgs e)
        {

            Form frm = new Epoint.Systems.Customizes.frmView();
            frm.Size = new System.Drawing.Size(300, 200);
            frm.Controls.Add(this.ucModuleManagement);
            frm.Tag = "RMD";
            frm.Name = "frmRMD";
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Text = Languages.GetLanguage("Reminder");
            this.ucModuleManagement.Location = new Point(0, 0);
            this.ucModuleManagement.lvReminder.Visible = true;
            this.ucModuleManagement.lvOpeningModule.Visible = false;
            this.ucModuleManagement.Height = this.UcModuleHeight;
            this.ucModuleManagement.Dock = DockStyle.Fill;
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            //frm.KeyDown += new KeyEventHandler(frm_KeyDown);
            //frm.KeyPress += new KeyPressEventHandler(frm_KeyPress);
            frm.ShowDialog();

            //Common.AddObjectOnCurentTab(uc);
        }

        void frm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        void frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucModuleManagement.Dock = DockStyle.Bottom;
            ucModuleManagement.Width = pnlLeftScreen.Width - 20;
            this.pnImage.Controls.Add(this.ucModuleManagement);
            this.ucModuleManagement.Dock = DockStyle.Bottom;
            this.ucModuleManagement.Height = this.ucModuleManagement.Height - this.ucModuleManagement.lvReminder.Height;
            this.ucModuleManagement.lvReminder.Visible = false;
            //ucModuleManagement.Width = 250;
            //ucModuleManagement.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            //this.ucModuleManagement.Location = this.pUcModule; 
            //ucModuleManagement.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        }
        
        public bool Backup()
        {
            if (Collection.Parameters["ALLOW_AUTOBACKUP"].ToString() == "0")
                if (!EpointMessage.MsgYes_No(EpointMessage.GetMessage("BACKUP"), "Y"))
                    return false;

            lock (this)
            {
                //string strCommand = string.Empty,
                //        strBackupName = string.Empty,
                //        strBackupPath = string.Empty;

                //strBackupPath = Collection.Parameters["BACKUP_PATH"].ToString();
                //strBackupName = Element.sysDatabaseName + "_" +
                //                DateTime.Now.Year + "" +
                //                DateTime.Now.Month.ToString().PadLeft(2, '0') + "" +
                //                DateTime.Now.Day.ToString().PadLeft(2, '0') + "_" +
                //                DateTime.Now.Hour.ToString().PadLeft(2, '0') + "h_" +
                //                DateTime.Now.Minute.ToString().PadLeft(2, '0') + "m_" +
                //                DateTime.Now.Second.ToString().PadLeft(2, '0') + "s";

                //strBackupPath = strBackupPath + strBackupName + ".Bak";

                //strCommand = "USE MASTER ;" +
                //                "EXEC Sp_addumpdevice 'disk', '" + strBackupName + "', '" + strBackupPath + "' ;" +
                //                "BACKUP DATABASE " + Element.sysDatabaseName + " TO " + strBackupName + "; " +
                //                "USE " + Element.sysDatabaseName;

                ////                strCommand = @"use Epoint;
                ////                               EXEC [sp_DBBackup] '" + Element.sysDatabaseName + "', '" + strBackupPath + "'";

                //Common.ShowStatus(Languages.GetLanguage("IN_PROCESS") + " backup Database...");

                //if (SQLExec.Execute(strCommand))
                //{
                //    EpointMessage.MsgOk("Dữ liệu đã được backup vào tập tin " + strBackupPath);
                //    return true;
                //}
                //else
                //{
                //    EpointMessage.MsgCancel("Không thể backup được dữ liệu " + strBackupPath);
                //    return false;
                //}

                return EpointMethod.BackupDatabase();
            }

            return true;
        }

        void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.F12)
            {
                if (Collection.Parameters.ContainsKey("ALLOW_REMOTE"))
                {
                    if (((string)Collection.Parameters["ALLOW_REMOTE"]).StartsWith("0"))
                        return;
                }

                string strFilePath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "Local Settings", @"C:\") + @"\Temp\TeamViewerQS.exe";
                strFilePath = Application.StartupPath + @"\\TeamViewerQS.exe";

                if (!System.IO.File.Exists(strFilePath))
                    System.IO.File.WriteAllBytes(strFilePath, Epoint.Properties.Resources.TeamViewerQS);

                if (System.IO.File.Exists(strFilePath))
                    System.Diagnostics.Process.Start(strFilePath);
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Control && e.KeyCode == Keys.K)
            {
                Epoint.frmKey fk = new frmKey();
                fk.ShowDialog();
            }
            if (e.Control && e.Shift && e.KeyCode ==Keys.E)
            {
                Epoint.frmInfo fi = new frmInfo();
                fi.Load();
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {

            if (Common.tabExistsOnMain())
                if (MessageBox.Show(EpointMessage.GetMessage("EXIT"), "Message",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.No)
                    e.Cancel = true;
            // update acount server
            //this.Hide();
            //EpointMethod.UpdateDataLics();
        }
        protected override void OnClosed(EventArgs e)
        {
            //if (MessageBox.Show(Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có muốn backup dữ liệu không?" : "Would you like to backup database?", "Message",
            //            MessageBoxButtons.YesNoCancel,
            //            MessageBoxIcon.Question,
            //            MessageBoxDefaultButton.Button2) == DialogResult.Cancel) 


            //Backup dữ liệu
            string strSQLExec;

            if (!Collection.Parameters.ContainsKey("LASTBACKUP_DATE"))
            {
                strSQLExec = "INSERT INTO SYSPARAMETER (Parameter_ID, Parameter_Value, Parameter_Type, Visible, Parameter_Desc, Module_ID) " +
                    " VALUES (@Parameter_ID, @Parameter_Value, @Parameter_Type, @Visible, @Parameter_Desc, @Module_ID)";

                Hashtable htPara = new Hashtable();
                htPara.Add("PARAMETER_ID", "LASTBACKUP_DATE");
                htPara.Add("PARAMETER_VALUE", "1/1/1900");
                htPara.Add("PARAMETER_TYPE", "D");
                htPara.Add("VISIBLE", "0");
                htPara.Add("PARAMETER_DESC", "Ngày backup cuối cùng");
                htPara.Add("MODULE_ID", 7001);

                if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
                    Collection.Parameters.Add("LASTBACKUP_DATE", "1/1/1900");
            }

            if (!Collection.Parameters.ContainsKey("BACKUP_PERIOD"))
            {
                strSQLExec = "INSERT INTO SYSPARAMETER (Parameter_ID, Parameter_Value, Parameter_Type, Visible, Parameter_Desc, Module_ID) " +
                    " VALUES (@Parameter_ID, @Parameter_Value, @Parameter_Type, @Visible, @Parameter_Desc, @Module_ID)";

                Hashtable htPara = new Hashtable();
                htPara.Add("PARAMETER_ID", "BACKUP_PERIOD");
                htPara.Add("PARAMETER_VALUE", 7);
                htPara.Add("PARAMETER_TYPE", "N");
                htPara.Add("VISIBLE", "1");
                htPara.Add("PARAMETER_DESC", "Kỳ hạn backup");
                htPara.Add("MODULE_ID", 7001);

                if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
                    Collection.Parameters.Add("BACKUP_PERIOD", "7");
            }

            if (Collection.Parameters.ContainsKey("LASTBACKUP_DATE") && Collection.Parameters.ContainsKey("BACKUP_PERIOD"))
            {
                object objLastBackupDate = DataTool.SQLGetNameByCode("SYSPARAMETER", "Parameter_ID", "Parameter_Value", "LASTBACKUP_DATE");
                object objBackupPeriod = DataTool.SQLGetNameByCode("SYSPARAMETER", "Parameter_ID", "Parameter_Value", "BACKUP_PERIOD");

                DateTime dLastBackupDate;
                if (!DateTime.TryParse((string)objLastBackupDate, out dLastBackupDate))
                    dLastBackupDate = Convert.ToDateTime("1/1/1900");

                int iBackupPeriod;
                if (!int.TryParse((string)objBackupPeriod, out iBackupPeriod))
                    iBackupPeriod = 7;

                if (iBackupPeriod > 0 && DateTime.Now.Subtract(dLastBackupDate).TotalDays >= iBackupPeriod)
                {
                    if (EpointMethod.BackupDatabase())
                    {
                        EpointMethod.DeleteBackup();
                        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = '" + Library.DateToStr(DateTime.Now) + "' WHERE Parameter_ID = 'LASTBACKUP_DATE'");
                    }
                }
            }

          

            base.OnClosed(e);
        }

        #region ViewReminder

        void lvReminder_DoubleClick(object sender, EventArgs e)
        {
            ViewReminder();
            Control f = this.ucModuleManagement.Parent;
            if (f != null && f.Name == "frmRMD")
                if (f.Tag.ToString() == "RMD")
                {
                    Form fm = (Form)f;
                    fm.Close();
                }
        }

        void lvReminder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ViewReminder();
                Control f = this.ucModuleManagement.Parent;
                if (f != null)
                    if (f.Tag.ToString() == "RMD" && f.Name == "frmRMD")
                    {
                        Form fm = (Form)f;
                        fm.Close();
                    }
            }
        }

        void frmReminder_Disposed(object sender, EventArgs e)
        {
            this.pnlScreen.Visible = true;
        }

        #endregion


    }
}