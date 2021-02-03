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


namespace Epoint.Modules.KPI
{
    public partial class frmKPIType : Epoint.Lists.frmView
	{
		#region Khai bao bien

		DataTable dtType;
		BindingSource bdsType = new BindingSource();
		dgvControl dgvType = new dgvControl();

		DataRow drCurrent;
		public string strType = string.Empty;

		#endregion

		#region Contructor

		public frmKPIType()
		{
			InitializeComponent();

			this.dgvType.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvKhac_CellMouseDoubleClick);
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
            strTableName = "KPITYPE";
            strCode = "KPIID";
            strName = "DESCR";
        }
		#endregion

		#region Build, FillData
		private void Build()
		{		
			dgvType.Dock = DockStyle.Fill;
			dgvType.strZone = "KPITYPE";
			dgvType.BuildGridView(this.isLookup);

            this.splControl1.Visible = true;
            this.splControl1.Dock = DockStyle.Fill;

            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(dgvType);
            }
            else
            {
                this.splControl1.Panel1.Controls.Add(dgvType);
            }
		}

		private void FillData()
		{
			dtType = DataTool.SQLGetDataTable("KPITYPE", null, this.strLookupKeyFilter, null);

			bdsType.DataSource = dtType;
			dgvType.DataSource = bdsType;
			bdsType.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsType;
			ExportControl = dgvType;

			if (this.isLookup)
				this.MoveToLookupValue();

            dgvType.Select();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtType.Rows.Count - 1; i++)
				if (((string)dtType.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsType.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsType.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsType.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsType.Current).Row, ref drCurrent);
			else
				drCurrent = dtType.NewRow();

			frmKPIType_Edit frmEdit = new frmKPIType_Edit();

			//if (strType != string.Empty)
			//{
			//	drCurrent["Type"] = strType;
			//}

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
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsType.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsType.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsType.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsType.Current)[strName];
                    UpdateHistory();
                }
                //Cập nhật dữ liệu danh mục
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsType.Position >= 0)
						dtType.ImportRow(drCurrent);
					else
						dtType.Rows.Add(drCurrent);

					bdsType.Position = bdsType.Find("TypeId", drCurrent["TypeId"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsType.Current).Row);

				dtType.AcceptChanges();
			}
			else
				dtType.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsType.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsType.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("KPIType", drCurrent))
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
                
                bdsType.RemoveAt(bdsType.Position);
				dtType.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsType == null || bdsType.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsType.Current).Row;
			DataTable dtTemp = dtType.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsType.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsType.Current).Row;
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
        //    dgvExport.bSortMode = false;
        //    dgvExport.strZone = "Khac";
        //    dgvExport.BuildGridView();
        //    dgvExport.DataSource = bdsType;

        //    string strTitle = ((Control)ExportControl).FindForm().Text;
        //    if (strTitle.Contains(","))
        //        strTitle = strTitle.Split(',')[0];

        //    ExportList(dgvExport, strTitle);
        }

        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }

		#endregion 
	}
}