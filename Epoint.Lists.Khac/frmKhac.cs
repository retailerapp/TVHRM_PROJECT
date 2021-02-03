using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;
using Epoint.Systems;
using Epoint.Systems.Elements;


namespace Epoint.Lists
{
    public partial class frmKhac : Epoint.Lists.frmView
	{
		#region Khai bao bien

		DataTable dtKhac;
		BindingSource bdsKhac = new BindingSource();
		dgvControl dgvKhac = new dgvControl();

		DataRow drCurrent;
		public string strType = string.Empty;

		#endregion

		#region Contructor

		public frmKhac()
		{
			InitializeComponent();

			this.dgvKhac.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvKhac_CellMouseDoubleClick);
            btExport.Click += new EventHandler(btExport_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);
		}
		
		public override void Load()
		{
            Init();
            Build();
			FillData();
			BindingLanguage();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

		public void Load(string strType)
		{
			this.strType = strType;

			this.Load();
		}

		public override void LoadLookup()
		{
			this.Load();
		}
        private void Init()
        {
            htHistory["DIEN_GIAI"] = "Danh mục khác";
            strTableName = "LIKHAC";
            strCode = "TYPE_ID";
            strName = "TYPE_NAME";
        }
		#endregion

		#region Build, FillData
		private void Build()
		{		
			dgvKhac.Dock = DockStyle.Fill;
			dgvKhac.strZone = "Khac";
			dgvKhac.BuildGridView(this.isLookup);

            this.splControl1.Visible = true;
            this.splControl1.Dock = DockStyle.Fill;

            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(dgvKhac);
            }
            else
            {
                this.splControl1.Panel1.Controls.Add(dgvKhac);
            }
		}

		private void FillData()
		{
			if(strType != string.Empty && strType != null)
			{
				if (strLookupKeyFilter == string.Empty || strLookupKeyFilter == null)
					strLookupKeyFilter = "Type = '" + strType + "'";
				else
					strLookupKeyFilter = strLookupKeyFilter + " AND (Type = '" + strType + "')";
			}
			dtKhac = DataTool.SQLGetDataTable("LIKHAC", null, this.strLookupKeyFilter, null);

			bdsKhac.DataSource = dtKhac;
			dgvKhac.DataSource = bdsKhac;
			bdsKhac.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsKhac;
			ExportControl = dgvKhac;

			if (this.isLookup)
				this.MoveToLookupValue();

            dgvKhac.Select();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtKhac.Rows.Count - 1; i++)
				if (((string)dtKhac.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsKhac.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsKhac.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsKhac.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsKhac.Current).Row, ref drCurrent);
			else
				drCurrent = dtKhac.NewRow();

			frmKhac_Edit frmEdit = new frmKhac_Edit();

			if (strType != string.Empty)
			{
				drCurrent["Type"] = strType;
				frmEdit.txtType.Enabled = false;
			}

			frmEdit.Load(enuNew_Edit, drCurrent);

			//Accept
			if (frmEdit.isAccept)
			{
                //Cập nhật History
                DataRow drHistory = drCurrent;
                htHistory["CODE"] = drHistory[strCode];
                htHistory["NAME"] = drHistory[strName];

                if (enuNew_Edit == enuEdit.New)
                {
                    htHistory["UPDATE_TYPE"] = "N";
                    UpdateHistory();
                }
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsKhac.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsKhac.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsKhac.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsKhac.Current)[strName];
                    UpdateHistory();
                }
                //Cập nhật dữ liệu danh mục
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsKhac.Position >= 0)
						dtKhac.ImportRow(drCurrent);
					else
						dtKhac.Rows.Add(drCurrent);

					bdsKhac.Position = bdsKhac.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsKhac.Current).Row);

				dtKhac.AcceptChanges();
			}
			else
				dtKhac.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsKhac.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsKhac.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("LIKHAC", drCurrent))
			{
                ////Sync Delete----------
                //string Is_Sync = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'"));
                //if (Is_Sync == "1")
                //{
                //    SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
                //    if (sqlCon.State != ConnectionState.Open)
                //    {
                //        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
                //        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang bị gián đoạn. Vui lòng chờ trong ít phút !" : "The synchronization process is interrupted. Please wait a few minutes !";
                //        Common.MsgCancel(strMsg);
                //    }
                //    else
                //    {
                //        DataToolSync1.SQLDelete("LIKHAC", drCurrent);
                //    }
                //}
                ////-----------------------

                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();
                
                bdsKhac.RemoveAt(bdsKhac.Position);
				dtKhac.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsKhac.Count <= 0)
				return;

			drCurrent = ((DataRowView)bdsKhac.Current).Row;
			string strOldValue = (string)drCurrent["Type_ID"];

			frmMergeID frm = new frmMergeID();

			frm.Load("LIKHAC", "Type_ID", "Type_Name", strOldValue, "Khac");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Type_ID", "LIKHAC", strOldValue, strNewValue))
				{
                    ////Sync data-------------
                    //string Is_Sync = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM SYSPARAMETER WHERE Parameter_ID = 'SYNC_BEGIN'"));
                    //if (Is_Sync == "1")
                    //{
                    //    SqlConnection sqlCon = SQLExecSync1.GetNewSQLConnectionSync1();
                    //    if (sqlCon.State != ConnectionState.Open)
                    //    {
                    //        SQLExec.Execute("UPDATE SYSPARAMETER SET Parameter_Value = 0 WHERE Parameter_ID = 'SYNC_BEGIN'");
                    //        string strMsg1 = Element.sysLanguage == enuLanguageType.Vietnamese ? "Quá trình đồng bộ đang bị gián đoạn. Vui lòng chờ trong ít phút !" : "The synchronization process is interrupted. Please wait a few minutes !";
                    //        Common.MsgCancel(strMsg1);
                    //    }
                    //    else
                    //    {
                    //        DataToolSync1.SQLMergeID("Type_ID", "LIKHAC", strOldValue, strNewValue);
                    //    }
                    //}
                    ////----------------------

                    //Cập nhật History
                    htHistory["CODE"] = drCurrent[strCode];
                    htHistory["NAME"] = drCurrent[strName];
                    htHistory["UPDATE_TYPE"] = "D";
                    UpdateHistory();

					bdsKhac.RemoveCurrent();
					bdsKhac.Position = bdsKhac.Find("Type_ID", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsKhac == null || bdsKhac.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsKhac.Current).Row;
			DataTable dtTemp = dtKhac.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsKhac.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsKhac.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvKhac_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			this.EnterProcess();
		}

        void btExport_Click(object sender, EventArgs e)
        {
            dgvExport.bSortMode = false;
            dgvExport.strZone = "Khac";
            dgvExport.BuildGridView();
            dgvExport.DataSource = bdsKhac;

            string strTitle = ((Control)ExportControl).FindForm().Text;
            if (strTitle.Contains(","))
                strTitle = strTitle.Split(',')[0];

            ExportList(dgvExport, strTitle);
        }

        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }

		#endregion 
	}
}