using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Elements;
using Epoint.Systems.Data;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;

namespace Epoint.Controllers
{
    public partial class frmParameters : Epoint.Systems.Customizes.frmView
	{
		#region Fields

		string strModule_IdList = "0";

		private DataTable dtParameters = new DataTable();
		private BindingSource bdsParameters = new BindingSource();

		private DataRow drCurrent;

		private ContextMenuStrip cmsParameters = new ContextMenuStrip();
		private ContextMenuStrip cmsParametersNew = new ContextMenuStrip();

        private tlControl tlParameters = new tlControl();

		#endregion

		#region Contructor

		public frmParameters()
		{
			InitializeComponent();            
		}

		public void Load(string strModule_IdList)
		{
			this.strModule_IdList = strModule_IdList;
            			
            this.Build();
			this.BuildContextMenu();
			this.FillData();
			this.BindingLanguage();

			this.Show();
		}

		#endregion

		#region Methods
        
        private void Build()
        {
            tlParameters.KeyFieldName = "PARAMETER_ID";
            tlParameters.ParentFieldName = "PARAMETER_ID_PARENT";
            tlParameters.Dock = DockStyle.Fill;

            tlParameters.strZone = "PARAMETERS_GRID2";
            tlParameters.BuildTreeList(false);

            this.Controls.Add(tlParameters);
        }

        private void BuildContextMenu()
		{			
			ToolStripMenuItem tsmiParameters_New = new ToolStripMenuItem();
			ToolStripMenuItem tsmiParameters_Edit = new ToolStripMenuItem();
			ToolStripMenuItem tsmiParameters_Delete = new ToolStripMenuItem();

			tsmiParameters_New.Name = "Parameters_New";
			tsmiParameters_New.Text = Languages.GetLanguage("NEW");

			tsmiParameters_Edit.Name = "Parameters_Edit";
			tsmiParameters_Edit.Text = Languages.GetLanguage("EDIT");

			tsmiParameters_Delete.Name = "Parameters_Delete";
			tsmiParameters_Delete.Text = Languages.GetLanguage("DELETE");

			cmsParameters.Items.AddRange(new ToolStripItem[] { tsmiParameters_New, tsmiParameters_Edit, tsmiParameters_Delete });

			//cmsParametersNew
			ToolStripMenuItem tsmiParametersNew_New = new ToolStripMenuItem();

			tsmiParametersNew_New.Name = "Parameters_New";
			tsmiParametersNew_New.Text = Languages.GetLanguage("NEW");

			cmsParametersNew.Items.Add(tsmiParametersNew_New);
		}

		private void FillData()
		{
			//Xay dung DataGrid
            dtParameters = DataTool.SQLGetDataTable("SYSPARAMETER", "*", "Visible = 1", "Stt"); //Hien thi nhung tham so co Visible la 1

			bdsParameters.DataSource = dtParameters;
			tlParameters.DataSource = bdsParameters;

			tlParameters.ExpandAll();

			bdsSearch = bdsParameters;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			//Neu sua ma khong ton tai dong nao
			if (bdsParameters.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;            		

			//Chi copy khi ton tai it nhat 1 dong
			if (bdsParameters.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsParameters.Current).Row, ref drCurrent);
			else
				drCurrent = dtParameters.NewRow();

			//Xuat hien cua so Edit
			frmParameters_Edit frmEdit = new frmParameters_Edit();

			frmEdit.Load(enuNew_Edit, ref drCurrent);

			if (frmEdit.isAccept == true)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsParameters.Position >= 0)
						dtParameters.ImportRow(drCurrent);
					else
						dtParameters.Rows.Add(drCurrent);

				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsParameters.Current).Row);

				dtParameters.AcceptChanges();
			}
			else
				dtParameters.RejectChanges();
			
			this.Refresh();
		}

		public override void Delete()
		{
			if (bdsParameters.Position < 0)
				return;			

			drCurrent = ((DataRowView)bdsParameters.Current).Row;

			//Kiểm tra phân quyền

			//Xóa
            if (DataTool.SQLCheckExist("SYSPARAMETER", "Parameter_ID_Parent", drCurrent["PARAMETER_ID"]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Loại : {" + drCurrent["PARAMETER_ID"].ToString() + "}  đang có tham số" :
                    "Type: {" + drCurrent["PARAMETER_ID"].ToString() + "}  have Parameters";

                Common.MsgOk(strMsg);
                return;
            }

            if (Common.MsgYes_No("Bạn có chắc chắn xóa không?", "N"))
            {
                if (DataTool.SQLDelete("SYSPARAMETER", drCurrent))
                {
                    bdsParameters.RemoveAt(bdsParameters.Position);
                    dtParameters.AcceptChanges();                    
                }
                this.Refresh();                
            }
		}

		#endregion

		#region Events
		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			Parameters.FillParameters();
		}
        
        #endregion
	}
}