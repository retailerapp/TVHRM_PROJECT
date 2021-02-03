using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Controls;

namespace Epoint.Lists
{
	public partial class frmDoiTuong : Epoint.Lists.frmView
	{
		#region Khai bao bien

		private DataTable dtDoiTuong;
		private DataRow drCurrent;
		private BindingSource bdsDoiTuong = new BindingSource();
        private dgvGridControl dgvDoiTuong = new dgvGridControl();

		public string strMa_Nh_Dt = string.Empty;
		public bool bLookupByGroup = false;
		public bool bLastLookupProcess = false;
		public bool bFind = false;

		#endregion 

		#region Contructor
		public frmDoiTuong()
		{
			InitializeComponent();

            //this.dgvDoiTuong.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDoiTuong_CellMouseDoubleClick);
            this.dgvDoiTuong.dgvGridView.DoubleClick += new EventHandler(dgvDoiTuong_CellMouseDoubleClick);
            btExport.Click += new EventHandler(btExport_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);
		}

		public override void Load()
		{
			this.Load(strMa_Nh_Dt);
		}

		public void Load(string strMa_Nh_Dt)
		{
			this.strMa_Nh_Dt = strMa_Nh_Dt;

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
			if (!bLastLookupProcess && Parameters.GetParaValue("ACCESS_DT").ToString() == "1") //Truy cap theo nhom
			{
				string strWhere = this.strLookupColumn + " LIKE '" + this.strLookupValue + "%'";

				if (this.strLookupKeyFilter != string.Empty && this.strLookupKeyFilter != null)
				{
					if (this.strLookupValue == "/" || this.strLookupValue == @"\")
						strWhere = strLookupKeyFilter;
					else
						strWhere = "(" + strLookupKeyFilter + ") AND (" + strWhere + ")";
				}

				DataTable dtFind = DataTool.SQLGetDataTable("LIDOITUONG", null, strWhere, null);

				if (dtFind.Rows.Count > 0)
				{
					strLookupKeyFilter = strWhere;
					bFind = true;
					this.Load();
				}
				else
					this.LoadLookupByGroup();
			}
			else
				this.Load();
		}

		private void LoadLookupByGroup()
		{//Lookup danh muc doi tuong theo nhom

			string strValue = string.Empty;
			bool bRequire = this.bLookupRequire;
			string strKeyFilter = this.strLookupKeyFilter;

			frmDoiTuongNh frm = new frmDoiTuongNh();
			frm.bEnterFinish = false;

			Lookup.ShowLookup(frm, "LIDOITUONGNH", "Ma_Nh_Dt", strValue, bRequire, "", "Nh_Cuoi = 1");

			this.bIsEnter = frm.bIsEnter;
			this.drLookup = frm.drLookup;
			this.Close();
		}

        private void Init()
        {
            htHistory["DIEN_GIAI"] = "Danh mục đối tượng";
            strTableName = "LIDOITUONG";
            strCode = "MA_DT";
            strName = "TEN_DT";            
        }

		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvDoiTuong.Dock = DockStyle.Fill;


            this.splControl1.Visible = true;
            this.splControl1.Dock = DockStyle.Fill;
            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(dgvDoiTuong);
            }
            else
            {
                this.splControl1.Panel1.Controls.Add(dgvDoiTuong);
            }

			dgvDoiTuong.strZone = "DoiTuong";
			dgvDoiTuong.BuildGridView(this.isLookup);

			ExportControl = dgvDoiTuong;
		}

		public void FillData()	
		{
			string strKey = string.Empty;
			if (this.isLookup)
				strKey = (this.strLookupKeyFilter == null ? string.Empty : this.strLookupKeyFilter);
			else
				strKey = (strMa_Nh_Dt == string.Empty ? string.Empty : "Ma_Nh_Dt = '" + strMa_Nh_Dt + "'");

			//Kiểm tra đối tượng: dùng chung danh mục với CRM
			DataTable dtDoiTuongCheck = SQLExec.ExecuteReturnDt("SELECT TOP 0 * FROM LIDOITUONG WHERE 0 = 1");
			if (dtDoiTuongCheck.Columns.Contains("Deleted"))
				strKey += (strKey == string.Empty ? string.Empty : " AND ") + "(Deleted <> 1)";

			//Chỉ show những dữ liệu cần thiết có khai báo trong Zone, Column
			string strSQLExec = @"
				DECLARE @_ColumnList NVARCHAR(1000) 
				SET @_ColumnList = ''
				SELECT @_ColumnList = @_ColumnList + ',' + Column_ID FROM SYSCOLUMN WHERE Zone = '" + dgvDoiTuong.strZone + @"'
				SELECT CASE WHEN LEN(@_ColumnList) > 0 THEN RIGHT(@_ColumnList, LEN(@_ColumnList)-1) ELSE '' END ";
			string strFieldList = SQLExec.ExecuteReturnValue(strSQLExec).ToString();

			if (strFieldList != string.Empty)
				dtDoiTuong = DataTool.SQLGetDataTable("LIDOITUONG", strFieldList, strKey, "Ma_Dt");
			else
				dtDoiTuong = DataTool.SQLGetDataTable("LIDOITUONG", null, strKey, "Ma_Dt");

			bdsDoiTuong.DataSource = dtDoiTuong;
			dgvDoiTuong.DataSource = bdsDoiTuong;

            //Vi tri mac dinh
			if (bdsDoiTuong.Count >= 0)
				bdsDoiTuong.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDoiTuong;

			if (this.isLookup)
				this.MoveToLookupValue();
            
            dgvDoiTuong.Select();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == String.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDoiTuong.Rows.Count - 1; i++)
				if (((string)dtDoiTuong.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDoiTuong.Position = i;
					break;
				}
		}
		#endregion 

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDoiTuong.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai
			if (bdsDoiTuong.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDoiTuong.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtDoiTuong.NewRow();
				drCurrent["Ma_Nh_Dt"] = strMa_Nh_Dt;
			}

			frmDoiTuong_Edit frmEdit = new frmDoiTuong_Edit();
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
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsDoiTuong.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsDoiTuong.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsDoiTuong.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsDoiTuong.Current)[strName];
                    UpdateHistory();
                }
                //Cập nhật dữ liệu danh mục
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDoiTuong.Position >= 0)
						dtDoiTuong.ImportRow(drCurrent);
					else
						dtDoiTuong.Rows.Add(drCurrent);

					bdsDoiTuong.Position = bdsDoiTuong.Find("MA_DT", drCurrent["MA_DT"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDoiTuong.Current).Row);
				}

				//dtDoiTuong.AcceptChanges();
				drCurrent.AcceptChanges();
			}
			else
				//dtDoiTuong.RejectChanges();
				drCurrent.RejectChanges();
		}
		
		public override void Delete()
		{
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}

			if (bdsDoiTuong.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDoiTuong.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLCheckExist("vw_SoCai", strCode, drCurrent[strCode]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Đối tượng: {" + drCurrent[strName].ToString() + "}  đã được sử dụng trong chứng từ" :
                    "Object: {" + drCurrent[strName].ToString() + "}  used in voucher";

                Common.MsgCancel(strMsg);
                return;
            }

            if (DataTool.SQLCheckExist("GLDUDAU", strCode, drCurrent[strCode]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Đối tượng: {" + drCurrent[strName].ToString() + "}  đã được sử dụng trong số dư đầu kỳ" :
                    "Object: {" + drCurrent[strName].ToString() + "}  used in opening balance";

                Common.MsgCancel(strMsg);
                return;
            }

			if (DataTool.SQLDelete("LIDOITUONG", drCurrent))
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
                //        DataToolSync1.SQLDelete("LIDOITUONG", drCurrent);
                //    }
                //}
                ////-----------------------

                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();
                
                bdsDoiTuong.RemoveAt(bdsDoiTuong.Position);
				dtDoiTuong.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if(bdsDoiTuong.Count <= 0)
				return;
			
			drCurrent = ((DataRowView)bdsDoiTuong.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Dt"];

			frmMergeID frm = new frmMergeID();

			frm.Load("LIDOITUONG", "Ma_Dt", "Ten_Dt", strOldValue, "DoiTuong");			

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Are you sure to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Dt", "LIDOITUONG", strOldValue, strNewValue))
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
                    //        DataToolSync1.SQLMergeID("Ma_Dt", "LIDOITUONG", strOldValue, strNewValue);
                    //    }
                    //}
                    ////----------------------

                    //Cập nhật History
                    htHistory["CODE"] = drCurrent[strCode];
                    htHistory["NAME"] = drCurrent[strName];
                    htHistory["UPDATE_TYPE"] = "D";
                    UpdateHistory();

					bdsDoiTuong.RemoveCurrent();
					bdsDoiTuong.Position = bdsDoiTuong.Find("MA_DT", strNewValue);
				}
			}
		}

		#endregion

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDoiTuong == null || bdsDoiTuong.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDoiTuong.Current).Row;
			DataTable dtTemp = dtDoiTuong.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void  EnterProcess()
		{
			if (bdsDoiTuong.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDoiTuong.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

        //void dgvDoiTuong_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (this.isLookup)
        //        this.EnterProcess();
        //    else
        //        this.Edit(enuEdit.Edit);
        //}
        void dgvDoiTuong_CellMouseDoubleClick(object sender, EventArgs e)
        {
            if (this.isLookup)
                this.EnterProcess();
            else
                this.Edit(enuEdit.Edit);
        }
		protected override void OnClosed(EventArgs e)
		{
			if (bFind && !this.bIsEnter)
				LoadLookupByGroup();

			base.OnClosed(e);
		}

        void btExport_Click(object sender, EventArgs e)
        {
            BindingSource bdsExport = new BindingSource();

            dgvExport.bSortMode = false;
            dgvExport.strZone = "DoiTuong";
            dgvExport.BuildGridView();

            Hashtable htExport = new Hashtable();
            //Mac dinh Ma_Data --> theo tham so he thong
            if ((string)Parameters.GetParaValue("AUTO_DEFAULT_MA_DATA") == "1")
                htExport["MA_DVCS"] = "*";
            else
                htExport["MA_DVCS"] = Element.sysMa_Data;

            //Mac dinh Ma_Data --> theo SYSDMDVCS_DEFAULTLIST
            string strMa_Data = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT Ma_DvCs FROM SYSDMDVCS_DEFAULTLIST WHERE Ma_Dm ='" + this.Object_ID + "'"));
            if (strMa_Data == "*")
                htExport["MA_DVCS"] = strMa_Data;

            DataTable dtExport = new DataTable();
            dtExport = SQLExec.ExecuteReturnDt("sp_ExportList_DoiTuong", htExport, CommandType.StoredProcedure);
            bdsExport.DataSource = dtExport;
            dgvExport.DataSource = bdsExport;

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