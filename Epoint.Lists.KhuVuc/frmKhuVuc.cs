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
	public partial class frmKhuVuc : Epoint.Lists.frmView
	{

		#region Khai bao bien
		DataTable dtKhuVuc;
		DataRow drCurrent;
		BindingSource bdsKhuVuc = new BindingSource();
		dgvControl dgvKhuVuc = new dgvControl();
        tlControl tlKhuVuc = new tlControl();

		#endregion 						

		#region Contructor

		public frmKhuVuc()
		{
			InitializeComponent();
            			
            tlKhuVuc.MouseDoubleClick += new MouseEventHandler(tlKhuVuc_MouseDoubleClick);
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

		public override void LoadLookup()
		{
			this.Load();
		}
        private void Init()
        {
            htHistory["DIEN_GIAI"] = "Danh mục khu vực";
            strTableName = "LIKHUVUC";
            strCode = "MA_KV";
            strName = "TEN_KV";
        }
		#endregion

		#region Build
		private void Build()
		{
            tlKhuVuc.KeyFieldName = "MA_KV";
            tlKhuVuc.ParentFieldName = "MA_KV_CHA";
            tlKhuVuc.Dock = DockStyle.Fill;

            tlKhuVuc.strZone = "KhuVuc";
            tlKhuVuc.BuildTreeList(this.isLookup);
            this.splControl1.Visible = true;
            this.splControl1.Dock = DockStyle.Fill;
            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(tlKhuVuc);
            }
            else
            {
                this.splControl1.Panel1.Controls.Add(tlKhuVuc);
            }
		}

		public void FillData()
		{
            dtKhuVuc = DataTool.SQLGetDataTable("LIKHUVUC", null, this.strLookupKeyFilter, null);
            bdsKhuVuc.DataSource = dtKhuVuc;

            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsKhuVuc;
            ExportControl = tlKhuVuc;

            tlKhuVuc.DataSource = bdsKhuVuc;
            bdsKhuVuc.Position = 0;

            if (this.isLookup)
                this.MoveToLookupValue();

            tlKhuVuc.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM SYSZONE WHERE ZONE = '" + tlKhuVuc.strZone + "'");
            tlKhuVuc.Select();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtKhuVuc.Rows.Count - 1; i++)
				if (((string)dtKhuVuc.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsKhuVuc.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsKhuVuc.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsKhuVuc.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsKhuVuc.Current).Row, ref drCurrent);
			else
				drCurrent = dtKhuVuc.NewRow();

			frmKhuVuc_Edit frmEdit = new frmKhuVuc_Edit();
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
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsKhuVuc.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsKhuVuc.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsKhuVuc.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsKhuVuc.Current)[strName];
                    UpdateHistory();
                }
                //Cập nhật dữ liệu danh mục
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsKhuVuc.Position >= 0)
						dtKhuVuc.ImportRow(drCurrent);
					else
						dtKhuVuc.Rows.Add(drCurrent);

					bdsKhuVuc.Position = bdsKhuVuc.Find("MA_KV", drCurrent["MA_KV"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsKhuVuc.Current).Row);

				dtKhuVuc.AcceptChanges();
			}
            //else
            //    dtKhuVuc.RejectChanges();
		}

		public override void Delete()
		{
            if (bdsKhuVuc.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsKhuVuc.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;


            if (DataTool.SQLCheckExist("LIKHUVUC", "Ma_Kv_Cha", drCurrent["Ma_Kv"]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Khu vực: {" + drCurrent["Ten_Kv"].ToString() + "}  đang có khu vực con" :
                    "Area: {" + drCurrent["Ten_Kv"].ToString() + "}  have child area";

                Common.MsgCancel(strMsg);
                return;
            }

            if (DataTool.SQLCheckExist("vw_DoanhThu", strCode, drCurrent[strCode]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Khu vực: {" + drCurrent[strName].ToString() + "}  đã được sử dụng trong chứng từ" :
                    "Area: {" + drCurrent[strName].ToString() + "}  used in voucher";

                Common.MsgCancel(strMsg);
                return;
            }

            if (DataTool.SQLDelete("LIKHUVUC", drCurrent))
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
                //        DataToolSync1.SQLDelete("LIKHUVUC", drCurrent);
                //    }
                //}
                ////-----------------------

                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();
                
                bdsKhuVuc.RemoveAt(bdsKhuVuc.Position);
                dtKhuVuc.AcceptChanges();
            }
		}

        public override void MergeID()
        {
            if (bdsKhuVuc.Count <= 0)
                return;

            drCurrent = ((DataRowView)bdsKhuVuc.Current).Row;
            string strOldValue = (string)drCurrent["Ma_Kv"];

            frmMergeID frm = new frmMergeID();

            frm.Load("LIKHUVUC", "Ma_Kv", "Ten_Kv", strOldValue, "KhuVuc");

            if (frm.isAccept)
            {
                string strNewValue = frm.strNewValue;
                string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge {" + strOldValue + "} to {" + strNewValue + "}?" : "Bạn có muốn gộp mã {" + strOldValue + "} sang {" + strNewValue + "} không ?";
                if (!Common.MsgYes_No(strMsg))
                    return;

                if (DataTool.SQLMergeID("Ma_Kv", "LIKHUVUC", strOldValue, strNewValue))
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
                    //        DataToolSync1.SQLMergeID("Ma_Kv", "LIKHUVUC", strOldValue, strNewValue);
                    //    }
                    //}
                    ////----------------------

                    //Cập nhật History
                    htHistory["CODE"] = drCurrent[strCode];
                    htHistory["NAME"] = drCurrent[strName];
                    htHistory["UPDATE_TYPE"] = "D";
                    UpdateHistory();

                    bdsKhuVuc.RemoveCurrent();
                    bdsKhuVuc.Position = bdsKhuVuc.Find("Ma_Kv", strNewValue);
                }
            }
        }

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsKhuVuc == null || bdsKhuVuc.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsKhuVuc.Current).Row;
			DataTable dtTemp = dtKhuVuc.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsKhuVuc.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsKhuVuc.Current).Row;
				this.Close();
                //Common.CloseCurrentFormOnMain();
			}
		}

		#endregion 

		#region Su kien

        void tlKhuVuc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.isLookup)
                this.EnterProcess();
            else
                this.Edit(enuEdit.Edit);
        }

        void btExport_Click(object sender, EventArgs e)
        {
            dgvExport.bSortMode = false;
            dgvExport.strZone = "KhuVuc";
            dgvExport.BuildGridView();
            dgvExport.DataSource = bdsKhuVuc;

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