using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Data;
using Epoint.Systems.Controls;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Customizes;

namespace Epoint.Controllers
{
    public partial class frmPermission : Epoint.Systems.Customizes.frmView
    {
        #region Fields

        string strMember_ID = string.Empty;
        string strMember_Type = string.Empty;
        string strObject_Type = string.Empty;
        bool bCheckKey;
        int iBeginRow = -1, iEndRow;

        DataRow drCurrent;

        DataTable dtPermission;
        DataTable dtPermissionTk;
        DataTable dtPermissionDvCs;

        BindingSource bdsPermission = new BindingSource();
        BindingSource bdsPermissionTk = new BindingSource();
        BindingSource bdsPermissionDvCs = new BindingSource();

        dgvControl dgvPermission = new dgvControl();
        dgvControl dgvPermissionTk = new dgvControl();
        dgvControl dgvPermissionDvCs = new dgvControl();

        #endregion

        #region Contructor

        public frmPermission()
        {
            InitializeComponent();

            rbAccessData.CheckedChanged += new EventHandler(rbAccess_CheckedChanged);
            rbAccessExec.CheckedChanged += new EventHandler(rbAccess_CheckedChanged);
            rbAccessReport.CheckedChanged += new EventHandler(rbAccess_CheckedChanged);
            rbAccessSystem.CheckedChanged += new EventHandler(rbAccess_CheckedChanged);
            rbAccessModule.CheckedChanged += new EventHandler(rbAccess_CheckedChanged);
            rdbAccessAccount.CheckedChanged += new EventHandler(rbAccess_CheckedChanged);
            rdbAccessDvCs.CheckedChanged += new EventHandler(rbAccess_CheckedChanged);

            dgvPermission.CellClick += new DataGridViewCellEventHandler(dgvPermission_CellClick);
            dgvPermissionTk.CellClick += new DataGridViewCellEventHandler(dgvPermissionTk_CellClick);
            dgvPermissionDvCs.CellClick += new DataGridViewCellEventHandler(dgvPermissionDvCs_CellClick);

            dgvPermission.KeyDown += new KeyEventHandler(dgvPermission_KeyDown);
            dgvPermissionDvCs.KeyDown += new KeyEventHandler(dgvPermissionDvCs_KeyDown);
            dgvPermissionTk.KeyDown += new KeyEventHandler(dgvPermissionTk_KeyDown);

            dgvPermission.KeyUp += new KeyEventHandler(dgvPermission_KeyUp);
            dgvPermissionDvCs.KeyUp += new KeyEventHandler(dgvPermissionDvCs_KeyUp);
            dgvPermissionTk.KeyUp += new KeyEventHandler(dgvPermissionTk_KeyUp);
        }
        public override void Load()
        {
            this.Build();
            this.FillData();

            this.CheckPermission();

            this.BindingLanguage();
            this.Show();
        }

        public void Load(string strMember_ID, string strMember_Type)
        {
            this.strMember_ID = strMember_ID;
            this.strMember_Type = strMember_Type;
            this.Text = Languages.GetLanguage("Permission") + " : " + strMember_Type + " - " + strMember_ID;

            this.Load();
        }

        #endregion

        #region Build, FillData

        private void Build()
        {
            dgvPermission.strZone = "PERMISSION";
            dgvPermission.BuildGridView();
            dgvPermission.Dock = DockStyle.Fill;
            dgvPermission.Visible = true;

            dgvPermissionTk.strZone = "PERMISSION_ACCOUNT";
            dgvPermissionTk.BuildGridView();
            dgvPermissionTk.Dock = DockStyle.Fill;
            dgvPermissionTk.Visible = false;

            dgvPermissionDvCs.strZone = "PERMISSION_DVCS";
            dgvPermissionDvCs.BuildGridView();
            dgvPermissionDvCs.Dock = DockStyle.Fill;
            dgvPermissionDvCs.Visible = false;

            pnlPermission.Controls.Add(dgvPermission);
            pnlPermission.Controls.Add(dgvPermissionTk);
            pnlPermission.Controls.Add(dgvPermissionDvCs);
        }

        private void FillData()
        {
            //Permission
            string[] strArrParameter_Name = new string[] { "Member_ID", "Object_Type" };
            object[] objArrParameter_Value = new object[] { this.strMember_ID, "" };

            dtPermission = SQLExec.ExecuteReturnDt("Sp_GetPermission", strArrParameter_Name, objArrParameter_Value, CommandType.StoredProcedure);

            bdsPermission.DataSource = dtPermission;
            dgvPermission.DataSource = bdsPermission;

            //PermissionTk
            if (DataTool.SQLCheckExist("sys.Objects", "Name", "Sp_GetPermissionTk"))
            {
                strArrParameter_Name = new string[] { "Member_ID", "Tk" };
                objArrParameter_Value = new object[] { this.strMember_ID, "" };

                dtPermissionTk = SQLExec.ExecuteReturnDt("Sp_GetPermissionTk", strArrParameter_Name, objArrParameter_Value, CommandType.StoredProcedure);

                bdsPermissionTk.DataSource = dtPermissionTk;
                dgvPermissionTk.DataSource = bdsPermissionTk;
            }

            //PermissionDvCs
            if (DataTool.SQLCheckExist("sys.Objects", "Name", "Sp_GetPermissionDvCs"))
            {
                strArrParameter_Name = new string[] { "Member_ID", "Ma_DvCs" };
                objArrParameter_Value = new object[] { this.strMember_ID, "" };

                dtPermissionDvCs = SQLExec.ExecuteReturnDt("Sp_GetPermissionDvCs", strArrParameter_Name, objArrParameter_Value, CommandType.StoredProcedure);

                bdsPermissionDvCs.DataSource = dtPermissionDvCs;
                dgvPermissionDvCs.DataSource = bdsPermissionDvCs;
            }
        }

        #endregion

        #region Methods

        private void CheckPermission()
        {
            //Tô màu
            dgvPermission.EnableHeadersVisualStyles = false; //Cho phép vẽ lại Header
            dgvPermissionTk.EnableHeadersVisualStyles = false; //Cho phép vẽ lại Header
            dgvPermissionDvCs.EnableHeadersVisualStyles = false; //Cho phép vẽ lại Header

            DataGridViewCellStyle dgvcStyleAllow = new DataGridViewCellStyle();
            dgvcStyleAllow.ForeColor = System.Drawing.Color.Blue;

            DataGridViewCellStyle dgvcStyleDeny = new DataGridViewCellStyle();
            dgvcStyleDeny.ForeColor = System.Drawing.Color.Red;


            if (rdbAccessAccount.Checked)
            {
                dgvPermission.Visible = false;
                dgvPermissionTk.Visible = true;
                dgvPermissionDvCs.Visible = false;

                //Tô màu
                foreach (DataGridViewColumn dgvc in dgvPermissionTk.Columns)
                {
                    if (dgvc.Name.StartsWith("ALLOW"))
                        dgvc.HeaderCell.Style = dgvcStyleAllow;
                    else if (dgvc.Name.StartsWith("DENY"))
                        dgvc.HeaderCell.Style = dgvcStyleDeny;
                }

                return;
            }
            else if (rdbAccessDvCs.Checked)
            {
                dgvPermission.Visible = false;
                dgvPermissionTk.Visible = false;
                dgvPermissionDvCs.Visible = true;

                //Tô màu
                foreach (DataGridViewColumn dgvc in dgvPermissionDvCs.Columns)
                {
                    if (dgvc.Name.StartsWith("ALLOW"))
                        dgvc.HeaderCell.Style = dgvcStyleAllow;
                    else if (dgvc.Name.StartsWith("DENY"))
                        dgvc.HeaderCell.Style = dgvcStyleDeny;
                }

                return;
            }
            else
            {
                dgvPermission.Visible = true;
                dgvPermissionTk.Visible = false;
                dgvPermissionDvCs.Visible = false;

                if (rbAccessData.Checked)
                    strObject_Type = "DATA";
                else if (rbAccessExec.Checked)
                    strObject_Type = "EXEC";
                else if (rbAccessReport.Checked)
                    strObject_Type = "REPORT";
                else if (rbAccessSystem.Checked)
                    strObject_Type = "SYSTEM";
                else
                    strObject_Type = "MODULE";

                bdsPermission.Filter = "Object_Type = '" + strObject_Type + "'";

                if (rbAccessData.Checked)
                {
                    dgvPermission.Columns["Allow_All"].Visible = true;
                    dgvPermission.Columns["Allow_Access"].Visible = true;
                    dgvPermission.Columns["Allow_New"].Visible = true;
                    dgvPermission.Columns["Allow_Edit"].Visible = true;
                    dgvPermission.Columns["Allow_Delete"].Visible = true;
                    dgvPermission.Columns["Allow_View"].Visible = true;
                    dgvPermission.Columns["Allow_Duyet"].Visible = true;

                    if (dgvPermission.Columns.Contains("Deny_Access"))
                    {
                        dgvPermission.Columns["Deny_Access"].Visible = true;
                        dgvPermission.Columns["Deny_New"].Visible = true;
                        dgvPermission.Columns["Deny_Edit"].Visible = true;
                        dgvPermission.Columns["Deny_Delete"].Visible = true;
                        dgvPermission.Columns["Deny_View"].Visible = true;
                    }
                }
                else
                {
                    dgvPermission.Columns["Allow_All"].Visible = false;
                    dgvPermission.Columns["Allow_Access"].Visible = true;
                    dgvPermission.Columns["Allow_New"].Visible = false;
                    dgvPermission.Columns["Allow_Edit"].Visible = false;
                    dgvPermission.Columns["Allow_Delete"].Visible = false;
                    dgvPermission.Columns["Allow_View"].Visible = false;
                    dgvPermission.Columns["Allow_Duyet"].Visible = false;

                    if (dgvPermission.Columns.Contains("Deny_Access"))
                    {
                        dgvPermission.Columns["Deny_Access"].Visible = true;
                        dgvPermission.Columns["Deny_New"].Visible = false;
                        dgvPermission.Columns["Deny_Edit"].Visible = false;
                        dgvPermission.Columns["Deny_Delete"].Visible = false;
                        dgvPermission.Columns["Deny_View"].Visible = false;
                    }
                }

                //Set Color
                foreach (DataGridViewColumn dgvc in dgvPermission.Columns)
                {
                    if (dgvc.Name.StartsWith("ALLOW"))
                        dgvc.HeaderCell.Style = dgvcStyleAllow;
                    else if (dgvc.Name.StartsWith("DENY"))
                        dgvc.HeaderCell.Style = dgvcStyleDeny;
                }
            }
        }

        #endregion

        #region Events
        #region Events dgv
        void dgvPermission_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = false;
            }
        }

        void dgvPermissionDvCs_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = false;
            }
        }

        void dgvPermissionTk_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = false;
            }
        }
        void dgvPermission_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = true;
            }

            //if (e.Control && e.KeyCode == Keys.A)
            //{
            //    DataGridViewCell dgvCell = ((dgvControl)sender).CurrentCell;
            //    string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            //    if (!Common.Inlist(strColumnName, "ALLOW_VIEW,ALLOW_ACCESS,ALLOW_NEW,ALLOW_EDIT,ALLOW_DELETE,DENY_VIEW,DENY_ACCESS,DENY_NEW,DENY_EDIT,DENY_DELETE"))
            //        return;


            //    CheckHD(dgvPermission, strColumnName, 0, dgvPermission.RowCount -1);
            //}
        }

        void dgvPermissionTk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = true;
            }
        }

        void dgvPermissionDvCs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                bCheckKey = true;
            }
        }
        
        #endregion

        void rbAccess_CheckedChanged(object sender, EventArgs e)
        {
            this.CheckPermission();
        }
        private void CheckHD(dgvControl dgvPermission, string strColumnName, int beg, int end)
        {
            if (beg > end)
            {
                int temp = beg;
                beg = end;
                end = temp ;
            }
            else
                beg = beg + 1;

            //DataTable dt = dgvPermission.DataSource as DataTable;
            for (int i = beg; i <= end; i++)
            {

                dgvPermission.Rows[i].Cells[strColumnName].Value = !(bool)dgvPermission.Rows[i].Cells[strColumnName].Value;

                if (Common.CheckPermission("PERMISSION", enuPermission_Type.Allow_Access) || Epoint.Systems.Elements.Element.sysIs_Admin)
                {

                    //drCurrent = dtPermission.Rows[i];
                    drCurrent = ((DataRowView)bdsPermission.Current).Row;
                    drCurrent.AcceptChanges();

                    bool bAllow_View = (bool)drCurrent["ALLOW_VIEW"],
                        bAllow_Access = (bool)drCurrent["ALLOW_ACCESS"],
                        bAllow_New = (bool)drCurrent["ALLOW_NEW"],
                        bAllow_Edit = (bool)drCurrent["ALLOW_EDIT"],
                        bAllow_Delete = (bool)drCurrent["ALLOW_DELETE"],
                        bAllow_Duyet = (bool)drCurrent["ALLOW_DUYET"];

                    bool bDeny_View = (bool)drCurrent["DENY_VIEW"],
                        bDeny_Access = (bool)drCurrent["DENY_ACCESS"],
                        bDeny_New = (bool)drCurrent["DENY_NEW"],
                        bDeny_Edit = (bool)drCurrent["DENY_EDIT"],
                        bDeny_Delete = (bool)drCurrent["DENY_DELETE"];

                    string strSQLExec;
                    int iIdent00;

                    Hashtable htPara = new Hashtable();
                    htPara.Add("MEMBER_ID", strMember_ID);
                    htPara.Add("OBJECT_ID", (string)drCurrent["Object_ID"]);
                    htPara.Add("ALLOW_VIEW", bAllow_View);
                    htPara.Add("ALLOW_ACCESS", bAllow_Access);
                    htPara.Add("ALLOW_NEW", bAllow_New);
                    htPara.Add("ALLOW_EDIT", bAllow_Edit);
                    htPara.Add("ALLOW_DELETE", bAllow_Delete);
                    htPara.Add("ALLOW_DUYET", bAllow_Delete);

                    if (drCurrent["Ident00"] == DBNull.Value || Convert.ToInt32(drCurrent["Ident00"]) == 0) //Chưa tồn tại
                    {
                        strSQLExec = @"INSERT INTO SYSPERMISSION (Member_ID, Object_ID, Allow_View, Allow_Access, Allow_New, Allow_Edit, Allow_Delete, Allow_Duyet) 
										VALUES (@Member_ID, @Object_ID, @Allow_View, @Allow_Access, @Allow_New, @Allow_Edit, @Allow_Delete, @Allow_Duyet) 
									SELECT @@IDENTITY";

                        iIdent00 = Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, htPara, CommandType.Text));

                        if (iIdent00 != 0)
                        {
                            drCurrent["Allow_View"] = bAllow_View; //Allow
                            drCurrent["Allow_Access"] = bAllow_Access;
                            drCurrent["Allow_New"] = bAllow_New;
                            drCurrent["Allow_Edit"] = bAllow_Edit;
                            drCurrent["Allow_Delete"] = bAllow_Delete;
                            drCurrent["Allow_Duyet"] = bAllow_Duyet;
                            drCurrent["Deny_View"] = bDeny_View; //Deny
                            drCurrent["Deny_Access"] = bDeny_Access;
                            drCurrent["Deny_New"] = bDeny_New;
                            drCurrent["Deny_Edit"] = bDeny_Edit;
                            drCurrent["Deny_Delete"] = bDeny_Delete;
                            drCurrent["Ident00"] = iIdent00;
                        }
                    }
                    else //Đã tồn tại
                    {
                        htPara.Add("IDENT00", Convert.ToInt32(drCurrent["Ident00"]));
                        strSQLExec = @"UPDATE SYSPERMISSION SET Allow_View = @Allow_View, Allow_Access = @Allow_Access, Allow_New = @Allow_New, Allow_Edit = @Allow_Edit, Allow_Delete = @Allow, Allow_Duyet = @Allow_Duyet WHERE Ident00 = @Ident00";

                        if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
                        {
                            drCurrent["Allow_View"] = bAllow_View; //Allow
                            drCurrent["Allow_Access"] = bAllow_Access;
                            drCurrent["Allow_New"] = bAllow_New;
                            drCurrent["Allow_Edit"] = bAllow_Edit;
                            drCurrent["Allow_Delete"] = bAllow_Delete;
                            drCurrent["Allow_Duyet"] = bAllow_Duyet;
                            drCurrent["Deny_View"] = bDeny_View; //Deny
                            drCurrent["Deny_Access"] = bDeny_Access;
                            drCurrent["Deny_New"] = bDeny_New;
                            drCurrent["Deny_Edit"] = bDeny_Edit;
                            drCurrent["Deny_Delete"] = bDeny_Delete;
                        }
                    }

                    //Nếu check [Allow] và [Deny] bị gỡ ra toàn bộ -> Thì xóa hẳn khỏi SYSPERMISSION
                    if (drCurrent["Ident00"] != DBNull.Value && Convert.ToInt32(drCurrent["Ident00"]) != 0)
                    {
                        bool bUncheckAll = true;

                        if (dgvPermission.Columns.Contains("Allow_View") && dgvPermission.Columns["Allow_View"].Visible && ((bool)drCurrent["Allow_View"] || (bool)drCurrent["Deny_View"]))
                            bUncheckAll = false;
                        if (dgvPermission.Columns.Contains("Allow_Access") && dgvPermission.Columns["Allow_Access"].Visible && ((bool)drCurrent["Allow_Access"] || (bool)drCurrent["Deny_Access"]))
                            bUncheckAll = false;
                        if (dgvPermission.Columns.Contains("Allow_New") && dgvPermission.Columns["Allow_New"].Visible && ((bool)drCurrent["Allow_New"] || (bool)drCurrent["Deny_New"]))
                            bUncheckAll = false;
                        if (dgvPermission.Columns.Contains("Allow_Edit") && dgvPermission.Columns["Allow_Edit"].Visible && ((bool)drCurrent["Allow_Edit"] || (bool)drCurrent["Deny_Edit"]))
                            bUncheckAll = false;
                        if (dgvPermission.Columns.Contains("Allow_Delete") && dgvPermission.Columns["Allow_Delete"].Visible && ((bool)drCurrent["Allow_Delete"] || (bool)drCurrent["Deny_Delete"]))
                            bUncheckAll = false;
                        
                        if (bUncheckAll)
                            if (SQLExec.Execute("DELETE FROM SYSPERMISSION WHERE Ident00 = " + drCurrent["Ident00"].ToString().Trim()))
                                drCurrent["Ident00"] = 0;
                    }
                }
            }
        }
        
        void dgvPermission_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            //string strColumnName = dgvPermission.Columns[e.ColumnIndex].Name;
            ///////////////////////////////
            DataGridViewCell dgvCell = ((dgvControl)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            if (strColumnName == "ALLOW_ALL")
            {
                
                
                if (Common.CheckPermission("PERMISSION", enuPermission_Type.Allow_Access) || Epoint.Systems.Elements.Element.sysIs_Admin)
                {

                   drCurrent = ((DataRowView)bdsPermission.Current).Row;
                   drCurrent[strColumnName] = !(bool)drCurrent[strColumnName];
                   drCurrent.AcceptChanges();

                   drCurrent["ALLOW_VIEW"] = drCurrent["ALLOW_ALL"];
                   drCurrent["ALLOW_ACCESS"]= drCurrent["ALLOW_ALL"];
                   drCurrent["ALLOW_NEW"]= drCurrent["ALLOW_ALL"];
                   drCurrent["ALLOW_EDIT"] = drCurrent["ALLOW_ALL"];
                   drCurrent["ALLOW_DELETE"] = drCurrent["ALLOW_ALL"];
                   drCurrent["ALLOW_DUYET"] = drCurrent["ALLOW_ALL"];
                   drCurrent.AcceptChanges();

                    bool bAllow_View = (bool)drCurrent["ALLOW_VIEW"],
                        bAllow_Access = (bool)drCurrent["ALLOW_ACCESS"],
                        bAllow_New = (bool)drCurrent["ALLOW_NEW"],
                        bAllow_Edit = (bool)drCurrent["ALLOW_EDIT"],
                        bAllow_Delete = (bool)drCurrent["ALLOW_DELETE"],
                        bAllow_Duyet = (bool)drCurrent["ALLOW_DUYET"];

                    bool bDeny_View = (bool)drCurrent["DENY_VIEW"],
                        bDeny_Access = (bool)drCurrent["DENY_ACCESS"],
                        bDeny_New = (bool)drCurrent["DENY_NEW"],
                        bDeny_Edit = (bool)drCurrent["DENY_EDIT"],
                        bDeny_Delete = (bool)drCurrent["DENY_DELETE"];

                    string strSQLExec;
                    int iIdent00;

                    Hashtable htPara = new Hashtable();
                    htPara.Add("MEMBER_ID", strMember_ID);
                    htPara.Add("OBJECT_ID", (string)drCurrent["Object_ID"]);
                    htPara.Add("ALLOW_VIEW", bAllow_View);
                    htPara.Add("ALLOW_ACCESS", bAllow_Access);
                    htPara.Add("ALLOW_NEW", bAllow_New);
                    htPara.Add("ALLOW_EDIT", bAllow_Edit);
                    htPara.Add("ALLOW_DELETE", bAllow_Delete);
                    htPara.Add("ALLOW_DUYET", bAllow_Duyet);

                    if (drCurrent["Ident00"] == DBNull.Value || Convert.ToInt32(drCurrent["Ident00"]) == 0) //Chưa tồn tại
                    {
                        strSQLExec = @"INSERT INTO SYSPERMISSION (Member_ID, Object_ID, Allow_View, Allow_Access, Allow_New, Allow_Edit, Allow_Delete, Allow_Duyet) 
										VALUES (@Member_ID, @Object_ID, @Allow_View, @Allow_Access, @Allow_New, @Allow_Edit, @Allow_Delete, @Allow_Duyet) 
									SELECT @@IDENTITY";

                        iIdent00 = Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, htPara, CommandType.Text));

                        if (iIdent00 != 0)
                        {
                            drCurrent["Allow_View"] = bAllow_View; //Allow
                            drCurrent["Allow_Access"] = bAllow_Access;
                            drCurrent["Allow_New"] = bAllow_New;
                            drCurrent["Allow_Edit"] = bAllow_Edit;
                            drCurrent["Allow_Delete"] = bAllow_Delete;
                            drCurrent["Allow_Duyet"] = bAllow_Duyet;
                            drCurrent["Deny_View"] = bDeny_View; //Deny
                            drCurrent["Deny_Access"] = bDeny_Access;
                            drCurrent["Deny_New"] = bDeny_New;
                            drCurrent["Deny_Edit"] = bDeny_Edit;
                            drCurrent["Deny_Delete"] = bDeny_Delete;
                            drCurrent["Ident00"] = iIdent00;
                        }
                    }
                    else //Đã tồn tại
                    {
                        htPara.Add("IDENT00", Convert.ToInt32(drCurrent["Ident00"]));
                        strSQLExec = @"UPDATE SYSPERMISSION SET Allow_View = @Allow_View, Allow_Access = @Allow_Access, Allow_New = @Allow_New, Allow_Edit = @Allow_Edit, Allow_Delete = @Allow_Delete, Allow_Duyet = @Allow_Duyet WHERE Ident00 = @Ident00";

                        if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
                        {
                            drCurrent["Allow_View"] = bAllow_View; //Allow
                            drCurrent["Allow_Access"] = bAllow_Access;
                            drCurrent["Allow_New"] = bAllow_New;
                            drCurrent["Allow_Edit"] = bAllow_Edit;
                            drCurrent["Allow_Delete"] = bAllow_Delete;
                            drCurrent["Allow_Duyet"] = bAllow_Duyet;
                            drCurrent["Deny_View"] = bDeny_View; //Deny
                            drCurrent["Deny_Access"] = bDeny_Access;
                            drCurrent["Deny_New"] = bDeny_New;
                            drCurrent["Deny_Edit"] = bDeny_Edit;
                            drCurrent["Deny_Delete"] = bDeny_Delete;
                        }
                    }

                    //Nếu check [Allow] và [Deny] bị gỡ ra toàn bộ -> Thì xóa hẳn khỏi SYSPERMISSION
                    if (drCurrent["Ident00"] != DBNull.Value && Convert.ToInt32(drCurrent["Ident00"]) != 0)
                    {
                        bool bUncheckAll = true;

                        if (dgvPermission.Columns.Contains("Allow_View") && dgvPermission.Columns["Allow_View"].Visible && ((bool)drCurrent["Allow_View"] || (bool)drCurrent["Deny_View"]))
                            bUncheckAll = false;
                        if (dgvPermission.Columns.Contains("Allow_Access") && dgvPermission.Columns["Allow_Access"].Visible && ((bool)drCurrent["Allow_Access"] || (bool)drCurrent["Deny_Access"]))
                            bUncheckAll = false;
                        if (dgvPermission.Columns.Contains("Allow_New") && dgvPermission.Columns["Allow_New"].Visible && ((bool)drCurrent["Allow_New"] || (bool)drCurrent["Deny_New"]))
                            bUncheckAll = false;
                        if (dgvPermission.Columns.Contains("Allow_Edit") && dgvPermission.Columns["Allow_Edit"].Visible && ((bool)drCurrent["Allow_Edit"] || (bool)drCurrent["Deny_Edit"]))
                            bUncheckAll = false;
                        if (dgvPermission.Columns.Contains("Allow_Delete") && dgvPermission.Columns["Allow_Delete"].Visible && ((bool)drCurrent["Allow_Delete"] || (bool)drCurrent["Deny_Delete"]))
                            bUncheckAll = false;

                        if (bUncheckAll)
                            if (SQLExec.Execute("DELETE FROM SYSPERMISSION WHERE Ident00 = " + drCurrent["Ident00"].ToString().Trim()))
                                drCurrent["Ident00"] = 0;
                    }
                }
            }


            if (!Common.Inlist(strColumnName, "ALLOW_VIEW,ALLOW_ACCESS,ALLOW_NEW,ALLOW_EDIT,ALLOW_DELETE,ALLOW_DUYET,DENY_VIEW,DENY_ACCESS,DENY_NEW,DENY_EDIT,DENY_DELETE"))
                return;


            if (!bCheckKey)
            {   
                iBeginRow = dgvPermission.CurrentRow.Index;
            }
            else
            {
                if (iBeginRow == -1)
                {   
                    iBeginRow = dgvPermission.CurrentRow.Index;
                }
                else
                {                    
                    iEndRow = dgvPermission.CurrentRow.Index;
                }
                CheckHD(dgvPermission, strColumnName, iBeginRow, iEndRow);
                iBeginRow = iEndRow;
            }

            //////////////////////////////////
            if (bCheckKey)
                return;

            if (Common.CheckPermission("PERMISSION", enuPermission_Type.Allow_Access) || Epoint.Systems.Elements.Element.sysIs_Admin)
            {
                drCurrent = ((DataRowView)bdsPermission.Current).Row;
                drCurrent.AcceptChanges();

                bool bAllow_View = (bool)drCurrent["ALLOW_VIEW"],
                    bAllow_Access = (bool)drCurrent["ALLOW_ACCESS"],
                    bAllow_New = (bool)drCurrent["ALLOW_NEW"],
                    bAllow_Edit = (bool)drCurrent["ALLOW_EDIT"],
                    bAllow_Delete = (bool)drCurrent["ALLOW_DELETE"],
                    bAllow_Duyet = (bool)drCurrent["ALLOW_DUYET"];

                bool bDeny_View = (bool)drCurrent["DENY_VIEW"],
                    bDeny_Access = (bool)drCurrent["DENY_ACCESS"],
                    bDeny_New = (bool)drCurrent["DENY_NEW"],
                    bDeny_Edit = (bool)drCurrent["DENY_EDIT"],
                    bDeny_Delete = (bool)drCurrent["DENY_DELETE"];

                if (strColumnName == "ALLOW_VIEW") //Allow
                    bAllow_View = !(bool)drCurrent[strColumnName];
                else if (strColumnName == "ALLOW_ACCESS")
                    bAllow_Access = !(bool)drCurrent[strColumnName];
                else if (strColumnName == "ALLOW_NEW")
                    bAllow_New = !(bool)drCurrent[strColumnName];
                else if (strColumnName == "ALLOW_EDIT")
                    bAllow_Edit = !(bool)drCurrent[strColumnName];
                else if (strColumnName == "ALLOW_DELETE")
                    bAllow_Delete = !(bool)drCurrent[strColumnName];
                else if (strColumnName == "ALLOW_DUYET")
                    bAllow_Duyet = !(bool)drCurrent[strColumnName];
                else if (strColumnName == "DENY_VIEW") //Deny: Allow luôn ngược với Deny
                    bDeny_View = !(bool)drCurrent[strColumnName];
                else if (strColumnName == "DENY_ACCESS")
                    bDeny_Access = !(bool)drCurrent[strColumnName];
                else if (strColumnName == "DENY_NEW")
                    bDeny_New = !(bool)drCurrent[strColumnName];
                else if (strColumnName == "DENY_EDIT")
                    bDeny_Edit = !(bool)drCurrent[strColumnName];
                else if (strColumnName == "DENY_DELETE")
                    bDeny_Delete = !(bool)drCurrent[strColumnName];

                string strSQLExec;
                int iIdent00;

                Hashtable htPara = new Hashtable();
                htPara.Add("MEMBER_ID", strMember_ID);
                htPara.Add("OBJECT_ID", (string)drCurrent["Object_ID"]);
                htPara.Add("ALLOW_VIEW", bAllow_View);
                htPara.Add("ALLOW_ACCESS", bAllow_Access);
                htPara.Add("ALLOW_NEW", bAllow_New);
                htPara.Add("ALLOW_EDIT", bAllow_Edit);
                htPara.Add("ALLOW_DELETE", bAllow_Delete);
                htPara.Add("ALLOW_DUYET", bAllow_Duyet);

                if (drCurrent["Ident00"] == DBNull.Value || Convert.ToInt32(drCurrent["Ident00"]) == 0) //Chưa tồn tại
                {
                    strSQLExec = @"INSERT INTO SYSPERMISSION (Member_ID, Object_ID, Allow_View, Allow_Access, Allow_New, Allow_Edit, Allow_Delete, Allow_Duyet) 
										VALUES (@Member_ID, @Object_ID, @Allow_View, @Allow_Access, @Allow_New, @Allow_Edit, @Allow_Delete, @Allow_Duyet) 
									SELECT @@IDENTITY";

                    iIdent00 = Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, htPara, CommandType.Text));

                    if (iIdent00 != 0)
                    {
                        drCurrent["Allow_View"] = bAllow_View; //Allow
                        drCurrent["Allow_Access"] = bAllow_Access;
                        drCurrent["Allow_New"] = bAllow_New;
                        drCurrent["Allow_Edit"] = bAllow_Edit;
                        drCurrent["Allow_Delete"] = bAllow_Delete;
                        drCurrent["Allow_Duyet"] = bAllow_Duyet;
                        drCurrent["Deny_View"] = bDeny_View; //Deny
                        drCurrent["Deny_Access"] = bDeny_Access;
                        drCurrent["Deny_New"] = bDeny_New;
                        drCurrent["Deny_Edit"] = bDeny_Edit;
                        drCurrent["Deny_Delete"] = bDeny_Delete;
                        drCurrent["Ident00"] = iIdent00;
                    }
                }
                else //Đã tồn tại
                {
                    htPara.Add("IDENT00", Convert.ToInt32(drCurrent["Ident00"]));
                    strSQLExec = @"UPDATE SYSPERMISSION SET Allow_View = @Allow_View, Allow_Access = @Allow_Access, Allow_New = @Allow_New, Allow_Edit = @Allow_Edit, Allow_Delete = @Allow_Delete, Allow_Duyet = @Allow_Duyet WHERE Ident00 = @Ident00";

                    if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
                    {
                        drCurrent["Allow_View"] = bAllow_View; //Allow
                        drCurrent["Allow_Access"] = bAllow_Access;
                        drCurrent["Allow_New"] = bAllow_New;
                        drCurrent["Allow_Edit"] = bAllow_Edit;
                        drCurrent["Allow_Delete"] = bAllow_Delete;
                        drCurrent["Allow_Duyet"] = bAllow_Duyet;
                        drCurrent["Deny_View"] = bDeny_View; //Deny
                        drCurrent["Deny_Access"] = bDeny_Access;
                        drCurrent["Deny_New"] = bDeny_New;
                        drCurrent["Deny_Edit"] = bDeny_Edit;
                        drCurrent["Deny_Delete"] = bDeny_Delete;
                    }
                }

                //Nếu check [Allow] và [Deny] bị gỡ ra toàn bộ -> Thì xóa hẳn khỏi SYSPERMISSION
                if (drCurrent["Ident00"] != DBNull.Value && Convert.ToInt32(drCurrent["Ident00"]) != 0)
                {
                    bool bUncheckAll = true;

                    if (dgvPermission.Columns.Contains("Allow_View") && dgvPermission.Columns["Allow_View"].Visible && ((bool)drCurrent["Allow_View"] || (bool)drCurrent["Deny_View"]))
                        bUncheckAll = false;
                    if (dgvPermission.Columns.Contains("Allow_Access") && dgvPermission.Columns["Allow_Access"].Visible && ((bool)drCurrent["Allow_Access"] || (bool)drCurrent["Deny_Access"]))
                        bUncheckAll = false;
                    if (dgvPermission.Columns.Contains("Allow_New") && dgvPermission.Columns["Allow_New"].Visible && ((bool)drCurrent["Allow_New"] || (bool)drCurrent["Deny_New"]))
                        bUncheckAll = false;
                    if (dgvPermission.Columns.Contains("Allow_Edit") && dgvPermission.Columns["Allow_Edit"].Visible && ((bool)drCurrent["Allow_Edit"] || (bool)drCurrent["Deny_Edit"]))
                        bUncheckAll = false;
                    if (dgvPermission.Columns.Contains("Allow_Delete") && dgvPermission.Columns["Allow_Delete"].Visible && ((bool)drCurrent["Allow_Delete"] || (bool)drCurrent["Deny_Delete"]))
                        bUncheckAll = false;

                    if (bUncheckAll)
                        if (SQLExec.Execute("DELETE FROM SYSPERMISSION WHERE Ident00 = " + drCurrent["Ident00"].ToString().Trim()))
                            drCurrent["Ident00"] = 0;
                }
            }
        }

        void dgvPermissionTk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string strColumnName = dgvPermissionTk.Columns[e.ColumnIndex].Name;

            if (!Common.Inlist(strColumnName, "ALLOW_VIEW,ALLOW_ACCESS,ALLOW_NEW,ALLOW_EDIT,ALLOW_DELETE,ALLOW_DUYET"))
                return;

            if (!bCheckKey)
            {
                iBeginRow = dgvPermissionTk.CurrentRow.Index;                
            }
            else
            {
                if (iBeginRow == -1)
                {
                    iBeginRow = dgvPermissionTk.CurrentRow.Index;
                }
                else
                {
                    iEndRow = dgvPermissionTk.CurrentRow.Index;
                }
                CheckHD(dgvPermissionTk, strColumnName, iBeginRow, iEndRow);
                iBeginRow = iEndRow;
            }

            //////////////////////////////////
            if (bCheckKey)
                return;

            if (Common.CheckPermission("PERMISSION", enuPermission_Type.Allow_Access) || Epoint.Systems.Elements.Element.sysIs_Admin)
            {
                drCurrent = ((DataRowView)bdsPermissionTk.Current).Row;
                drCurrent.AcceptChanges();

                bool bAllow = !(bool)drCurrent[strColumnName];
                string strSQLExec;
                int iIdent00;

                if (drCurrent["Ident00"] == DBNull.Value || Convert.ToInt32(drCurrent["Ident00"]) == 0)
                {
                    strSQLExec = @"INSERT INTO SYSPERMISSIONTK (Member_ID, Tk, " + strColumnName + @") 
										VALUES ('" + strMember_ID + "', '" + (string)drCurrent["Tk"] + "', " + (bAllow ? "1" : "0") + @")
									SELECT @@IDENTITY";

                    iIdent00 = Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec));

                    if (iIdent00 != 0)
                    {
                        drCurrent[strColumnName] = bAllow;
                        drCurrent["Ident00"] = iIdent00;
                    }
                }
                else
                {
                    iIdent00 = Convert.ToInt32(drCurrent["Ident00"]);
                    strSQLExec = @"UPDATE SYSPERMISSIONTK SET " + strColumnName + " = " + (bAllow ? "1" : "0") + " WHERE Ident00 = '" + iIdent00.ToString().Trim() + "'";

                    if (SQLExec.Execute(strSQLExec))
                        drCurrent[strColumnName] = bAllow;
                }
            }
        }

        void dgvPermissionDvCs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string strColumnName = dgvPermissionDvCs.Columns[e.ColumnIndex].Name;

            if (!Common.Inlist(strColumnName, "ALLOW_VIEW,ALLOW_ACCESS,ALLOW_NEW,ALLOW_EDIT,ALLOW_DELETE,ALLOW_DUYET"))
                return;

            if (!bCheckKey)
            {
                iBeginRow = dgvPermissionDvCs.CurrentRow.Index;                
            }
            else
            {
                if (iBeginRow == -1)
                {
                    iBeginRow = dgvPermissionDvCs.CurrentRow.Index;                    
                }
                else
                {
                    iEndRow = dgvPermissionDvCs.CurrentRow.Index;                 
                }
                CheckHD(dgvPermissionDvCs, strColumnName, iBeginRow, iEndRow);
                iBeginRow = iEndRow;
            }

            //////////////////////////////////
            if (bCheckKey)
                return;

            if (Common.CheckPermission("PERMISSION", enuPermission_Type.Allow_Access) || Epoint.Systems.Elements.Element.sysIs_Admin)
            {
                drCurrent = ((DataRowView)bdsPermissionDvCs.Current).Row;
                drCurrent.AcceptChanges();

                bool bAllow = !(bool)drCurrent[strColumnName];
                string strSQLExec;
                int iIdent00;

                if (drCurrent["Ident00"] == DBNull.Value || Convert.ToInt32(drCurrent["Ident00"]) == 0)
                {
                    strSQLExec = @"INSERT INTO SYSPERMISSIONDVCS (Member_ID, Ma_DvCs, " + strColumnName + @") 
										VALUES ('" + strMember_ID + "', '" + (string)drCurrent["Ma_DvCs"] + "', " + (bAllow ? "1" : "0") + @")
									SELECT @@IDENTITY";

                    iIdent00 = Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec));

                    if (iIdent00 != 0)
                    {
                        drCurrent[strColumnName] = !bAllow;
                        drCurrent["Ident00"] = iIdent00;
                    }
                }
                else
                {
                    iIdent00 = Convert.ToInt32(drCurrent["Ident00"]);
                    strSQLExec = @"UPDATE SYSPERMISSIONDVCS SET " + strColumnName + " = " + (bAllow ? "1" : "0") + " WHERE Ident00 = '" + iIdent00.ToString().Trim() + "'";

                    if (SQLExec.Execute(strSQLExec))
                        drCurrent[strColumnName] = bAllow;
                }
            }
        }

        void btLoad_DmTk_Click(object sender, EventArgs e)
        {
            if (EpointMessage.MsgYes_No("Bạn có chắc chắn load danh mục tài khoản vào phân quyền tài khoản không?"))
            {
                string strSQLExec = @"
					INSERT INTO SYSPERMISSIONTk (Member_ID, Tk, Allow_Access, Allow_New, Allow_Edit, Allow_Delete, Allow_View)
						SELECT '" + strMember_ID + @"' AS Member_ID, Tk, 1, 1, 1, 1, 1 
							FROM LITAIKHOAN 
							WHERE LEN(Tk) = 3 AND Tk NOT LIKE 'N%' AND 
								Tk NOT IN (SELECT Tk FROM SYSPERMISSIONTk WHERE Member_ID = '" + strMember_ID + @"')";

                //FillData lại cho phân quyền tài khoản
                if (SQLExec.Execute(strSQLExec))
                {
                    string[] strArrParameter_Name = new string[] { "Member_ID", "Tk" };
                    object[] objArrParameter_Value = new object[] { this.strMember_ID, "" };

                    dtPermissionTk = SQLExec.ExecuteReturnDt("Sp_GetPermissionTk", strArrParameter_Name, objArrParameter_Value, CommandType.StoredProcedure);

                    bdsPermissionTk.DataSource = dtPermissionTk;
                    dgvPermissionTk.DataSource = bdsPermissionTk;
                }
            }
        }

        #endregion

    }
}

