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


namespace Epoint.Controllers
{
	public partial class frmDmDvCs_DefaultList : Epoint.Lists.frmView
	{

		#region Khai bao bien
		DataTable dtDmDvCs_DefaultList;
		DataRow drCurrent;
		BindingSource bdsDmDvCs_DefaultList = new BindingSource();		
        tlControl tlDmDvCs_DefaultList = new tlControl();

		#endregion

		#region Contructor

		public frmDmDvCs_DefaultList()
		{
			InitializeComponent();

			tlDmDvCs_DefaultList.MouseDoubleClick += new MouseEventHandler(tlDmDvCs_DefaultList_MouseDoubleClick);
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
            htHistory["DIEN_GIAI"] = "Khai báo ĐVCS mặc định cho danh mục";
            strTableName = "SYSDMDVCS_DEFAULTLIST";
            strCode = "MA_DM";
            strName = "TEN_DM";
        }
		#endregion

		#region Build, FillData
		private void Build()
		{                 
            tlDmDvCs_DefaultList.KeyFieldName = "MA_DM";
            tlDmDvCs_DefaultList.ParentFieldName = "MA_DM";
            tlDmDvCs_DefaultList.Dock = DockStyle.Fill;

            tlDmDvCs_DefaultList.strZone = "DMDVCS_DEFAULTLIST";
            tlDmDvCs_DefaultList.BuildTreeList(this.isLookup);

            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(tlDmDvCs_DefaultList);
            }
            else
            {
                this.splControl1.Panel1.Controls.Add(tlDmDvCs_DefaultList);
            }
		}

		public void FillData()
		{            
            dtDmDvCs_DefaultList = DataTool.SQLGetDataTable("SYSDMDVCS_DEFAULTLIST", null, this.strLookupKeyFilter, null);
            bdsDmDvCs_DefaultList.DataSource = dtDmDvCs_DefaultList;

            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsDmDvCs_DefaultList;
            ExportControl = tlDmDvCs_DefaultList;

            tlDmDvCs_DefaultList.DataSource = bdsDmDvCs_DefaultList;
            bdsDmDvCs_DefaultList.Position = 0;

            if (this.isLookup)
                this.MoveToLookupValue();

            tlDmDvCs_DefaultList.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM SYSZONE WHERE ZONE = '" + tlDmDvCs_DefaultList.strZone + "'");
            tlDmDvCs_DefaultList.Select();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmDvCs_DefaultList.Rows.Count - 1; i++)
				if (((string)dtDmDvCs_DefaultList.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmDvCs_DefaultList.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmDvCs_DefaultList.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmDvCs_DefaultList.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmDvCs_DefaultList.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmDvCs_DefaultList.NewRow();

			frmDmDvCs_DefaultList_Edit frmEdit = new frmDmDvCs_DefaultList_Edit();
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
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsDmDvCs_DefaultList.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsDmDvCs_DefaultList.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsDmDvCs_DefaultList.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsDmDvCs_DefaultList.Current)[strName];
                    UpdateHistory();
                }
                //Cập nhật dữ liệu danh mục
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmDvCs_DefaultList.Position >= 0)
						dtDmDvCs_DefaultList.ImportRow(drCurrent);
					else
						dtDmDvCs_DefaultList.Rows.Add(drCurrent);

					bdsDmDvCs_DefaultList.Position = bdsDmDvCs_DefaultList.Find("MA_DM", drCurrent["MA_DM"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmDvCs_DefaultList.Current).Row);

				dtDmDvCs_DefaultList.AcceptChanges();
			}
            //else
            //    dtDmDvCs_DefaultList.RejectChanges();
		}

		public override void Delete()
		{           
            if (bdsDmDvCs_DefaultList.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsDmDvCs_DefaultList.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;
            
            if (DataTool.SQLDelete("SYSDMDVCS_DEFAULTLIST", drCurrent))
            {
                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();
                
                bdsDmDvCs_DefaultList.RemoveAt(bdsDmDvCs_DefaultList.Position);
                dtDmDvCs_DefaultList.AcceptChanges();
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

			if (bdsDmDvCs_DefaultList == null || bdsDmDvCs_DefaultList.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmDvCs_DefaultList.Current).Row;
			DataTable dtTemp = dtDmDvCs_DefaultList.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void  EnterProcess()
		{
			if (bdsDmDvCs_DefaultList.Position < 0)
				return;

            if (isLookup && EnterValid())
            {
                drLookup = ((DataRowView)bdsDmDvCs_DefaultList.Current).Row;
                this.Close();             
            }         
		}

		#endregion 

		#region Su kien
        void tlDmDvCs_DefaultList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.isLookup)
                this.EnterProcess();
            else
                this.Edit(enuEdit.Edit);
        }

        void btExport_Click(object sender, EventArgs e)
        {
            dgvExport.bSortMode = false;
            dgvExport.strZone = "DmDvcs_DefaultList";
            dgvExport.BuildGridView();
            dgvExport.DataSource = bdsDmDvCs_DefaultList;

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