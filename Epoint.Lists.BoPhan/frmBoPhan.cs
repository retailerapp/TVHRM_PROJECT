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
    public partial class frmBoPhan : Epoint.Lists.frmView
	{		

		#region Khai bao bien
		DataTable dtBoPhan;
		DataRow drCurrent;
		BindingSource bdsBoPhan = new BindingSource();
		tlControl tlBoPhan = new tlControl();

		#endregion 				

		#region Contructor
		
		public frmBoPhan()
		{
			InitializeComponent();

			tlBoPhan.MouseDoubleClick += new MouseEventHandler(tlBoPhan_MouseDoubleClick);          
            //btExport.Click +=new EventHandler(btExport_Click);
            //btRefresh.Click += new EventHandler(btRefresh_Click);
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
            htHistory["DIEN_GIAI"] = "Danh mục bộ phận";
            strTableName = "LIBOPHAN";
            strCode = "MA_BP";
            strName = "TEN_BP";
        }

		#endregion

		#region Build, FillData

		private void Build()
		{
			tlBoPhan.KeyFieldName = "MA_BP";
			tlBoPhan.ParentFieldName = "MA_BP_CHA";
			tlBoPhan.Dock = DockStyle.Fill;

			tlBoPhan.strZone = "BoPhan";
			tlBoPhan.BuildTreeList(this.isLookup);
            this.splControl1.Visible = true;
            this.splControl1.Dock = DockStyle.Fill;
            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(tlBoPhan);
            }
            else
            {
                this.splControl1.Panel1.Controls.Add(tlBoPhan);
            }            
		}

		public void FillData()
		{
			dtBoPhan = DataTool.SQLGetDataTable("LIBOPHAN", null, this.strLookupKeyFilter, null);
			bdsBoPhan.DataSource = dtBoPhan;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsBoPhan;
			ExportControl = tlBoPhan;

			tlBoPhan.DataSource = bdsBoPhan;
			bdsBoPhan.Position = 0;

			if (this.isLookup)
				this.MoveToLookupValue();

			tlBoPhan.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM SYSZONE WHERE ZONE = '" + tlBoPhan.strZone + "'");
            tlBoPhan.Select();
		}


		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtBoPhan.Rows.Count - 1; i++)
				if (((string)dtBoPhan.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsBoPhan.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsBoPhan.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsBoPhan.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsBoPhan.Current).Row, ref drCurrent);
			else
				drCurrent = dtBoPhan.NewRow();

			frmBoPhan_Edit frmEdit = new frmBoPhan_Edit();
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
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsBoPhan.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsBoPhan.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsBoPhan.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsBoPhan.Current)[strName];
                    UpdateHistory();
                }
                //Cập nhật dữ liệu danh mục
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsBoPhan.Position >= 0)
						dtBoPhan.ImportRow(drCurrent);
					else
						dtBoPhan.Rows.Add(drCurrent);

					bdsBoPhan.Position = bdsBoPhan.Find("MA_BP", drCurrent["MA_BP"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsBoPhan.Current).Row);
				
				dtBoPhan.AcceptChanges();
			}
			//else
			//    dtBoPhan.RejectChanges();
		}
		
		public override void Delete()
		{
			if (bdsBoPhan.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsBoPhan.Current).Row;
				
			if( !Common.MsgYes_No( Languages.GetLanguage("SURE_DELETE")))
				return;

			
			if (DataTool.SQLCheckExist("LIBOPHAN", "Ma_Bp_Cha", drCurrent["Ma_Bp"]))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Bộ phận: {" + drCurrent["Ten_Bp"].ToString() + "}  đang có bộ phận con" :
					"Deparment: {" + drCurrent["Ten_Bp"].ToString() + "}  have child deparment";

				Common.MsgCancel(strMsg);
				return;
			}

            if (DataTool.SQLCheckExist("vw_SoCai", strCode, drCurrent[strCode]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Bộ phận: {" + drCurrent[strName].ToString() + "}  đã được sử dụng trong chứng từ" :
                    "Deparment: {" + drCurrent[strName].ToString() + "}  used in voucher";

                Common.MsgCancel(strMsg);
                return;
            }
			
			if (DataTool.SQLDelete("LIBOPHAN", drCurrent))
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
                //        DataToolSync1.SQLDelete("LIBOPHAN", drCurrent);
                //    }
                //}
                ////-----------------------

                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();

				bdsBoPhan.RemoveAt(bdsBoPhan.Position);
				dtBoPhan.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsBoPhan.Count <= 0)
				return;

			drCurrent = ((DataRowView)bdsBoPhan.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Bp"];

			frmMergeID frm = new frmMergeID();

			frm.Load("LIBOPHAN", "Ma_Bp", "Ten_Bp", strOldValue, "BoPhan");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge {" + strOldValue + "} to {" + strNewValue + "}?" : "Bạn có muốn gộp mã {" + strOldValue + "} sang {" + strNewValue + "} không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Bp", "LIBOPHAN", strOldValue, strNewValue))
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
                    //        DataToolSync1.SQLMergeID("Ma_Bp", "LIBOPHAN", strOldValue, strNewValue);
                    //    }
                    //}
                    ////----------------------

                    //Cập nhật History
                    htHistory["CODE"] = drCurrent[strCode];
                    htHistory["NAME"] = drCurrent[strName];
                    htHistory["UPDATE_TYPE"] = "M";
                    UpdateHistory();

					bdsBoPhan.RemoveCurrent();
					bdsBoPhan.Position = bdsBoPhan.Find("Ma_Bp", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsBoPhan == null || bdsBoPhan.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsBoPhan.Current).Row;
			DataTable dtTemp = dtBoPhan.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void EnterProcess()
		{
			if (bdsBoPhan.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsBoPhan.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void tlBoPhan_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

        public override void ExportExcel()
        {
            dgvExport.bSortMode = false;
            dgvExport.strZone = "BoPhan";
            dgvExport.BuildGridView();
            dgvExport.DataSource = bdsBoPhan;

            string strTitle = ((Control)ExportControl).FindForm().Text;
            if (strTitle.Contains(","))
                strTitle = strTitle.Split(',')[0];

            ExportList(dgvExport, strTitle);
        }

        public override void RefeshData()
        {
            FillData();
        }
		#endregion 
	}
}