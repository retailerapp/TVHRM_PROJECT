using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;

namespace Epoint.Controllers
{
    public partial class frmMaintenanceDB : Epoint.Systems.Customizes.frmView
    {
        BindingSource bdsChechTable = new BindingSource();
        DataTable dtChechTable;

        public frmMaintenanceDB()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(frmMaintenanceDB_KeyDown);
            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            btShrinkDB.Click += new EventHandler(btShrinkDB_Click);

            btStart.Click += new EventHandler(btStart_Click);
            btStop.Click += new EventHandler(btStop_Click);
            btPause.Click += new EventHandler(btPause_Click);
            btContinue.Click += new EventHandler(btContinue_Click);

            this.cboBackupFileList.TextChanged += new EventHandler(cboBackupFileList_TextChanged);
            this.btRestorePath.Click += new EventHandler(btRestore_Click);
        }

        public void Load()
        {
            txtTime.Text = "120000";
            //BuildCheckTable();
            FillCheckTable();
            SetBackupPath();

            BindingLanguage();
            this.Show();
        }

        //void BuildCheckTable()
        //{
        //    dgvCheckTable.strZone = "CHECKTABLE";

        //    dgvCheckTable.BuildGridView(this.isLookup);

        //    dgvCheckTable.ReadOnly = false;

        //    foreach (DataGridViewColumn dgvc in dgvCheckTable.Columns)
        //        dgvc.ReadOnly = true;

        //    if (dgvCheckTable.Columns.Contains("SELECT"))
        //        dgvCheckTable.Columns["SELECT"].ReadOnly = false;
        //}

        void FillCheckTable()
        {
            dtChechTable = DataTool.SQLGetDataTable("SYSDMTABLE", "*, CAST(0 AS BIT) AS [SELECT]", "Table_Name0 <> ''", "Table_Type, Table_Name0");

            bdsChechTable.DataSource = dtChechTable;
            //dgvCheckTable.DataSource = bdsChechTable;

            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsChechTable;
            bdsChechTable.Position = 0;
        }

        void ShrinkDB()
        {
            Common.ShowStatus(Epoint.Systems.Librarys.Languages.GetLanguage("In_Process", Element.sysLanguage));
            string strSqlExec = "DBCC SHRINKDATABASE ('" + Element.sysDatabaseName + "', 0)";

            SQLExec.ExecuteReturnValue(strSqlExec);

            EpointMessage.MsgOk(Epoint.Systems.Librarys.Languages.GetLanguage("End_Process", Element.sysLanguage));
            Common.EndShowStatus();
        }

        void CheckDB()
        {
            Common.ShowStatus(Epoint.Systems.Librarys.Languages.GetLanguage("In_Process", Element.sysLanguage));

            object objMsg = null;
            string strSqlExec = string.Empty;

            if (rdbNomal.Checked)
            {
                strSqlExec = @"	USE Master ; 
								DBCC CHECKDB ('" + Element.sysDatabaseName + @"'); 
								USE " + Element.sysDatabaseName;

                objMsg = SQLExec.ExecuteReturnValue(strSqlExec);
            }
            else if (rdbRepairFast.Checked)
            {
                strSqlExec = @"	USE Master;
								EXEC	sp_dboption '" + Element.sysDatabaseName + @"', single, true;  
								DBCC CHECKDB ('" + Element.sysDatabaseName + @"', REPAIR_FAST); 
								EXEC sp_dboption '" + Element.sysDatabaseName + @"', single, false;
								USE " + Element.sysDatabaseName;

                objMsg = SQLExec.ExecuteReturnValue(strSqlExec);
            }
            else if (rdbRepairRebuild.Checked)
            {
                strSqlExec = @"	USE Master;
								EXEC	sp_dboption '" + Element.sysDatabaseName + @"', single, true;  
								DBCC CHECKDB ('" + Element.sysDatabaseName + @"', REPAIR_REBUILD); 
								EXEC sp_dboption '" + Element.sysDatabaseName + @"', single, false;
								USE " + Element.sysDatabaseName;

                objMsg = SQLExec.ExecuteReturnValue(strSqlExec);
            }
            else if (rdbRepairAllowDataLost.Checked)
            {
                strSqlExec = @"	USE Master;
								EXEC	sp_dboption '" + Element.sysDatabaseName + @"', single, true ;
								DBCC CHECKDB ('" + Element.sysDatabaseName + @"', REPAIR_ALLOW_DATA_LOSS);
								EXEC sp_dboption '" + Element.sysDatabaseName + @"', single, false;
								USE " + Element.sysDatabaseName;

                objMsg = SQLExec.ExecuteReturnValue(strSqlExec);
            }

            if (objMsg != null && objMsg != DBNull.Value)
                EpointMessage.MsgOk(objMsg.ToString());
            else
                EpointMessage.MsgOk(Epoint.Systems.Librarys.Languages.GetLanguage("End_Process", Element.sysLanguage));

            Common.EndShowStatus();
        }

        void CheckTable()
        {
            foreach (DataRow dr in dtChechTable.Rows)
            {
                if (!(bool)dr["Select"])
                    continue;

                string strSqlExec = @"	USE Master ; 
									DBCC CHECKTABLE ('" + Element.sysDatabaseName + ".dbo." + (string)dr["Table_Name0"] + @"'); 
									USE " + Element.sysDatabaseName;

                SQLExec.ExecuteReturnValue(strSqlExec);
                Common.ShowStatus("Đang kiểm tra bảng: " + (string)dr["Description"] + " (" + (string)dr["Table_Name0"] + ")");
            }

            EpointMessage.MsgOk(Epoint.Systems.Librarys.Languages.GetLanguage("End_Process", Element.sysLanguage));
            Common.EndShowStatus();
        }

        void SetBackupPath()
        {
            string strStartupPath = Application.StartupPath + @"\Backup\", strBackupDeviceName = string.Empty;
            string strRestorePath = string.Empty;
            string strCopyFromPath = string.Empty;
            string strCopyToPath = string.Empty;

            DataTable dtBackupFileList = DataTool.SQLGetDataTable("sys.backup_devices", "Name, Physical_Name", "Name LIKE '" + Element.sysDatabaseName + "%'", "Name");

            cboBackupFileList.lstItem.Size = new Size(500, 300);
            cboBackupFileList.lstItem.strZone = "BACKUP_LIST";
            cboBackupFileList.lstItem.BuildListView();

            cboBackupFileList.lstItem.DataSource = dtBackupFileList;

            if (dtBackupFileList.Rows.Count > 0)
            {
                strRestorePath = (string)dtBackupFileList.Rows[dtBackupFileList.Rows.Count - 1]["Physical_Name"];
                strBackupDeviceName = (string)dtBackupFileList.Rows[dtBackupFileList.Rows.Count - 1]["Name"];

                strCopyFromPath = strStartupPath + strBackupDeviceName + ".Bak";
                strCopyToPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + strBackupDeviceName + ".Bak";
            }


            txtBackupPath.Text = (string)Parameters.GetParaValue("BACKUP_PATH");
            txtAutoBackupPath.Text = (string)Parameters.GetParaValue("BACKUP_PATH");
            txtRestorePath.Text = strRestorePath;
            cboBackupFileList.Text = strBackupDeviceName;
        }

        
        void Backup()
        {
            string strCommand = string.Empty, strBackupName = string.Empty, strBackupPath = string.Empty;
            strBackupName = Element.sysDatabaseName + "_" +
                            DateTime.Now.Year + "_" +
                            DateTime.Now.Month.ToString().PadLeft(2, '0') + "_" +
                            DateTime.Now.Day.ToString().PadLeft(2, '0') + "_" +
                            DateTime.Now.Hour.ToString().PadLeft(2, '0') + "h_" +
                            DateTime.Now.Minute.ToString().PadLeft(2, '0') + "m_" +
                            DateTime.Now.Second.ToString().PadLeft(2, '0') + "s";

            strBackupPath = txtBackupPath.Text + strBackupName + ".Bak";

            Common.ShowStatus(Languages.GetLanguage("In_Process"));

            //strCommand = "USE MASTER ;" +
            //    //"EXEC Sp_addumpdevice 'disk', '" + strBackName + "', '" + strBackupPath + "' ;" +
            //              "BACKUP DATABASE " + Element.sysDatabaseName + " TO " + strBackName + "; " +
            //              "USE " + Element.sysDatabaseName;

            //SQLExec.Execute("USE MASTER ;" +
            //                "EXEC Sp_addumpdevice 'disk', '" + strBackName + "', '" + strBackupPath + "' ;");

            strCommand = "USE MASTER ;" +
                            "EXEC Sp_addumpdevice 'disk', '" + strBackupName + "', '" + strBackupPath + "' ;" +
                            "BACKUP DATABASE " + Element.sysDatabaseName + " TO " + strBackupName + "; " +
                            "USE " + Element.sysDatabaseName;

            if (SQLExec.Execute(strCommand))
                EpointMessage.MsgOk(Languages.GetLanguage("END_PROCESS"));

            Common.EndShowStatus();
        }
        void Restore()
        {
            string strRestorePath = string.Empty;
            strRestorePath = txtRestorePath.Text;

            //if (!System.IO.File.Exists(strRestorePath))
            //{
            //    string strMsg = "File :" + strRestorePath + Languages.GetLanguage("NOT_EXISTS");
            //    EpointMessage.MsgCancel(strMsg);
            //    return;
            //}

            string strCommand = string.Empty;
            strCommand = "USE MASTER " +
                            "RESTORE DATABASE " + Element.sysDatabaseName + " " +
                            "FROM DISK = '" + strRestorePath + "' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10 ;" +
                            "USE " + Element.sysDatabaseName;

            Common.ShowStatus(Languages.GetLanguage("IN_PROCESS"));

            if (SQLExec.Execute(strCommand))
                EpointMessage.MsgOk(Languages.GetLanguage("END_PROCESS"));

            Common.EndShowStatus();
        }

        void ConfigAutoBackup()
        {
            //void Kiểm tra tồn tại thủ tục trong database MSDB
            if (!DataTool.SQLCheckExist("msdb.dbo.sysobjects", "name", "Sp_ConfigAutoBackup"))
            {
                SQLExec.Execute(Epoint.Controllers.MaintenanceDB.rsMaintenanceDB.Sp_ConfigAutoBackup);
                //Epoint.Controllers.MaintenanceDB.rsMaintenanceDB
            }

            //Kiểm tra giờ hợp lệ hay không

            int iActiveDay = 0;

            if (chkCN.Checked)
                iActiveDay = 1;
            if (chkThu2.Checked)
                iActiveDay = iActiveDay + 2;
            if (chkThu3.Checked)
                iActiveDay = iActiveDay + 4;
            if (chkThu4.Checked)
                iActiveDay = iActiveDay + 8;
            if (chkThu5.Checked)
                iActiveDay = iActiveDay + 16;
            if (chkThu6.Checked)
                iActiveDay = iActiveDay + 32;
            if (chkThu7.Checked)
                iActiveDay = iActiveDay + 64;

            Hashtable ht = new Hashtable();

            ht["_SERVERNAME"] = Element.sysConnection.DataSource;
            ht["_DATABASENAME"] = Element.sysDatabaseName;
            ht["_JOBNAME"] = "BACKUPDB_" + Element.sysDatabaseName;
            ht["_BACKUPPATH"] = txtAutoBackupPath.Text;
            ht["_ACTIVESTARTDATE"] = int.Parse(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0'));
            ht["_FREQ_INTERVAL"] = iActiveDay;
            ht["_ACTIVESTARTTIME"] = int.Parse(txtTime.Text.Replace(":", ""));

            SQLExec.Execute("USE MSDB; EXEC MSDB.dbo.Sp_ConfigAutoBackup @SERVERNAME = @_SERVERNAME, @DATABASENAME = @_DATABASENAME, @JOBNAME = @_JOBNAME, @BACKUPPATH = @_BACKUPPATH, @ACTIVESTARTDATE = @_ACTIVESTARTDATE, @FREQ_INTERVAL = @_FREQ_INTERVAL, @ACTIVESTARTTIME = @_ACTIVESTARTTIME ; USE " + Element.sysDatabaseName, ht, CommandType.Text);

            EpointMessage.MsgOk(Languages.GetLanguage("END_PROCESS"));
        }

        void frmMaintenanceDB_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && tabCheckDB.SelectedTab == tpCheckTable)
            //{
            //    if (e.KeyCode == Keys.A)
            //        foreach (DataRow dr in dtChechTable.Rows)
            //            dr["Select"] = true;

            //    else if (e.KeyCode == Keys.U)
            //        foreach (DataRow dr in dtChechTable.Rows)
            //            dr["Select"] = false;
            //}
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            if (tabCheckDB.SelectedTab == tpCheckDB)
                CheckDB();

            //else if (tabCheckDB.SelectedTab == tpCheckTable)
            //    CheckTable();

            else if (tabCheckDB.SelectedTab == tpBackup)
                Backup();

            else if (tabCheckDB.SelectedTab == tpRestore)
                Restore();

            else if (tabCheckDB.SelectedTab == tpAutoBackup)
                ConfigAutoBackup();

        }

        void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btShrinkDB_Click(object sender, EventArgs e)
        {
            this.ShrinkDB();
        }

        #region Service Panel
        void btContinue_Click(object sender, EventArgs e)
        {
            object objMsg = SQLExec.ExecuteReturnValue("master..xp_cmdShell 'NET CONTINUE EpointSERVICE'");
            if (objMsg != null && objMsg != DBNull.Value)
                EpointMessage.MsgOk(objMsg.ToString());
        }

        void btPause_Click(object sender, EventArgs e)
        {
            object objMsg = SQLExec.ExecuteReturnValue("master..xp_cmdShell 'NET PAUSE EpointSERVICE'");
            if (objMsg != null && objMsg != DBNull.Value)
                EpointMessage.MsgOk(objMsg.ToString());
        }

        void btStop_Click(object sender, EventArgs e)
        {
            object objMsg = SQLExec.ExecuteReturnValue("master..xp_cmdShell 'NET STOP EpointSERVICE'");
            if (objMsg != null && objMsg != DBNull.Value)
                EpointMessage.MsgOk(objMsg.ToString());
        }

        void btStart_Click(object sender, EventArgs e)
        {
            object objMsg = SQLExec.ExecuteReturnValue("master..xp_cmdShell 'NET START EpointSERVICE'");
            if (objMsg != null && objMsg != DBNull.Value)
                EpointMessage.MsgOk(objMsg.ToString());
        }
        #endregion

        void cboBackupFileList_TextChanged(object sender, EventArgs e)
        {
            if (cboBackupFileList.lviItem != null && cboBackupFileList.lviItem.SubItems.Count > 0)
                txtRestorePath.Text = cboBackupFileList.lviItem.SubItems["Physical_Name"].Text;
        }

        void btRestore_Click(object sender, EventArgs e)
        {
            string strStartPath = Application.StartupPath + @"\Backup";

            OpenFileDialog ofdlg = new OpenFileDialog();

            ofdlg.InitialDirectory = strStartPath;
            ofdlg.DefaultExt = "Bak";
            ofdlg.Filter = "*.Bak|*.Bak";

            if (ofdlg.ShowDialog() != DialogResult.OK)
                return;

            txtRestorePath.Text = ofdlg.FileName;
        }
    }
}
