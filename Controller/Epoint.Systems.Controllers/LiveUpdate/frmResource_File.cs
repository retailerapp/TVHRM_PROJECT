using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;
using Epoint.Systems.Customizes;

namespace Epoint.Controllers
{
    public partial class frmResource_File : Epoint.Lists.frmView
	{		

		#region Khai bao bien
		DataTable dtResource;
		DataRow drCurrent;
		BindingSource bdsResource = new BindingSource();
		tlControl tlResource = new tlControl();

        object objFileContent;

		#endregion 				

		#region Contructor
		
		public frmResource_File()
		{
			InitializeComponent();

			tlResource.MouseDoubleClick += new MouseEventHandler(tlResource_MouseDoubleClick);                     
            //cboFile_Type.SelectedValueChanged +=new EventHandler(cboFile_Type_SelectedValueChanged);
            //cboFile_Type.SelectedIndexChanged += new EventHandler(cboFile_Type_SelectedIndexChanged); 
		}

		public override void Load()
		{
            this.cboFile_Type.DataSource = SQLExec.ExecuteReturnDt("SELECT DISTINCT '*' AS File_Type UNION SELECT File_Type FROM SYSRESOURCES_VER ORDER BY 1");
            this.cboFile_Type.DisplayMember = "File_Type";
            this.cboFile_Type.ValueMember = "File_Type";           

            Init();
            Build();
			FillData();
			BindingLanguage();
                        
            if (bdsResource.Count > 0)
            {
                //this.cboFile_Type.Enabled = false;
                DataRow drCurrent = ((DataRowView)bdsResource.Current).Row;
                this.objFileContent = Resource.LoadResource(drCurrent["File_Id"].ToString());
            }

            //Hide button
            btImport.Enabled = false;

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
            htHistory["DIEN_GIAI"] = "Quản lý tập tin";
            strTableName = "SYSRESOURCES_VER";
            strCode = "FILE_ID";
            strName = "FILE_NAME";
        }

		#endregion

		#region Build, FillData

		private void Build()
		{
            tlResource.KeyFieldName = "FILE_ID";
            tlResource.ParentFieldName = "MA_NHOM";
            tlResource.Dock = DockStyle.Fill;

            tlResource.strZone = "RESOURCE_VER";
            tlResource.BuildTreeList(this.isLookup);

            //this.splitContainer1.Panel2.Controls.Add(tlResource);
            this.splControl1.Visible = true;

            if (isLookup)
            {
                this.splitContainer.Panel2.Controls.Add(splControl1);
                this.splControl1.Panel1.Controls.Add(tlResource);
            }
            else
            {
                this.splControl1.Dock = DockStyle.Fill;
                this.splControl1.Panel1.Controls.Add(tlResource);
            }
		}

		public void FillData()
		{
            dtResource = DataTool.SQLGetDataTable("SYSRESOURCES_VER", null, this.strLookupKeyFilter, null);

            //dtResource = SQLExec.ExecuteReturnDt("SELECT * FROM SYSRESOURCES_VER WHERE POSID_CODE ='" + Bien.strPOSID + "' AND Terminal_No ='" + Bien.strTerminal_No+ "'"); 

            bdsResource.DataSource = dtResource;
            
            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsResource;
            ExportControl = tlResource;

            tlResource.DataSource = bdsResource;
            bdsResource.Position = 0;

            if (this.isLookup)
                this.MoveToLookupValue();

            tlResource.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM SYSZONE WHERE ZONE = '" + tlResource.strZone + "'");
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtResource.Rows.Count - 1; i++)
				if (((string)dtResource.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsResource.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsResource.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsResource.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsResource.Current).Row, ref drCurrent);
			else
				drCurrent = dtResource.NewRow();

			frmResource_File_Edit frmEdit = new frmResource_File_Edit();            
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
                else if (enuNew_Edit == enuEdit.Edit && ((string)drHistory[strCode] != (string)((DataRowView)bdsResource.Current)[strCode] || (string)drHistory[strName] != (string)((DataRowView)bdsResource.Current)[strName]))
                {
                    htHistory["UPDATE_TYPE"] = "E";
                    htHistory["CODE_OLD"] = ((DataRowView)bdsResource.Current)[strCode];
                    htHistory["NAME_OLD"] = ((DataRowView)bdsResource.Current)[strName];
                    UpdateHistory();
                }
                //Cập nhật dữ liệu danh mục
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsResource.Position >= 0)
						dtResource.ImportRow(drCurrent);
					else
						dtResource.Rows.Add(drCurrent);

					bdsResource.Position = bdsResource.Find("FILE_ID", drCurrent["FILE_ID"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsResource.Current).Row);
				
				dtResource.AcceptChanges();
			}
			//else
			//    dtResource.RejectChanges();
		}
		
		public override void Delete()
		{
			if (bdsResource.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsResource.Current).Row;
				
			if( !Common.MsgYes_No( Languages.GetLanguage("SURE_DELETE")))
				return;

			
			if (DataTool.SQLDelete("SYSRESOURCES_VER", drCurrent))
			{
                //Cập nhật History
                htHistory["CODE"] = drCurrent[strCode];
                htHistory["NAME"] = drCurrent[strName];
                htHistory["UPDATE_TYPE"] = "D";
                UpdateHistory();

				bdsResource.RemoveAt(bdsResource.Position);
				dtResource.AcceptChanges();
			}
		}

		public override void MergeID()
		{
            //if (bdsResource.Count <= 0)
            //    return;

            //drCurrent = ((DataRowView)bdsResource.Current).Row;
            //string strOldValue = (string)drCurrent["Ma_Bp"];

            //frmMergeID frm = new frmMergeID();

            //frm.Load("SYSRESOURCES_VER", "Ma_Bp", "Ten_Bp", strOldValue, "BoPhan");

            //if (frm.isAccept)
            //{
            //    string strNewValue = frm.strNewValue;
            //    string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge {" + strOldValue + "} to {" + strNewValue + "}?" : "Bạn có muốn gộp mã {" + strOldValue + "} sang {" + strNewValue + "} không ?";
            //    if (!Common.MsgYes_No(strMsg))
            //        return;

            //    if (DataTool.SQLMergeID("Ma_Bp", "SYSRESOURCES_VER", strOldValue, strNewValue))
            //    {
            //        bdsResource.RemoveCurrent();
            //        bdsResource.Position = bdsResource.Find("Ma_Bp", strNewValue);
            //    }
            //}
		}
        private void RiseVersion()
        {
            int iVersion = 0;
            int.TryParse(Parameters.GetParaValue("VERSION").ToString(), out iVersion);
            Parameters.SetParaValue("VERSION", iVersion + 1);
        }
        private void UploadFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.RestoreDirectory = true;
            dialog.Multiselect = true;
            dialog.Filter = "All files (*.*)|*.*";



            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string strFileName in dialog.FileNames)
                {
                    this.objFileContent = File.ReadAllBytes(strFileName);
                    string strTag = Path.GetExtension(strFileName).Substring(1).ToUpper();
                    string strFile_ID = System.IO.Path.GetFileName(strFileName);
                    string strFile_Name = System.IO.Path.GetFileName(strFileName);

                    //Upload file
                    SaveResource_UpdateFile.SaveFile(strFile_ID, strFile_Name, "", "", strTag, strTag, this.objFileContent, DateTime.Now, "", true);
                }
            }
        }
		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsResource == null || bdsResource.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsResource.Current).Row;
			DataTable dtTemp = dtResource.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void EnterProcess()
		{
			if (bdsResource.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsResource.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien
        void tabResource_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Build();
            this.FillData();
        }
        
		void tlResource_MouseDoubleClick(object sender, MouseEventArgs e)
		{
            //if (this.isLookup)
            //    this.EnterProcess();
            //else
            //    this.Edit(enuEdit.Edit);

            if (bdsResource.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsResource.Current).Row, ref drCurrent);

            if ((Boolean)drCurrent["DUYET"] == true)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "(*." + drCurrent["File_Tag"].ToString() + ")|*." + drCurrent["File_Tag"].ToString() + "|All files (*.*)|*.*";
                dialog.FileName = drCurrent["File_Name"].ToString();
                if (this.objFileContent != null)
                {
                    FileStream stream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                    stream.Write((byte[])this.objFileContent, 0, ((byte[])this.objFileContent).Length);
                    stream.Close();
                    Process.Start(dialog.FileName);
                }
            }           

		}
        void cboFile_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFile_Type.Text.Trim() == "*")
                this.FillData();
            else
            {
                bdsResource.Filter = "File_Type = '" + cboFile_Type.Text.Trim() + "'";
                this.FillData();
            }
        }

        //void btAdd_Click(object sender, EventArgs e)
        //{
        //    Edit(enuEdit.New);
        //}

        //void btEdit_Click(object sender, EventArgs e)
        //{
        //    Edit(enuEdit.Edit);
        //}

        //void btDelete_Click(object sender, EventArgs e)
        //{
        //    Delete();
        //}        
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11) // Tăng version đối với tường hợp
            {
                string mess = Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có muốn tăng phiên bản update?" : "Are you sure version update?";
                if (Common.MsgYes_No(mess, "Y"))
                {
                    RiseVersion();
                    MessageBox.Show("OK!");
                }
            }
            else if (e.KeyCode == Keys.F12) // Tăng version đối với tường hợp
            {
                UploadFile();
                FillData();

                // Tự động tăng VERSION

                if (Parameters.GetParaValue("AUTORISEVERSION") != null && (string)Parameters.GetParaValue("AUTORISEVERSION") == "Y")
                {
                    RiseVersion();
                }

            }
            else { base.OnKeyDown(e); }
        }
		#endregion 
	}
}