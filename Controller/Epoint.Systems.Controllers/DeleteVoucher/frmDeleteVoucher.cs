using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Elements;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Lists;
using System.Collections;
using Epoint.Systems.Controls;
using Epoint.Systems;

namespace Epoint.Controllers
{
    public partial class frmDeleteVoucher : Epoint.Systems.Customizes.frmView
    {
        string strMa_Ct;
        
        public frmDeleteVoucher()
        {
            InitializeComponent();

            btOk.Click += new EventHandler(btOk_Click);
            btCancel.Click += new EventHandler(btCancel_Click);
            btMa_Ct.Click += new EventHandler(btMa_Ct_Click);
        }

        new public void Load()
        {
            //txtMa_Ct_List.Validating += new CancelEventHandler(txtMa_Ct_Validating);
            this.txtNgay_Ct1.Text = Element.sysNgay_Ct1.ToString();
            this.txtNgay_Ct2.Text = Element.sysNgay_Ct2.ToString();

            this.Build();
            this.FillData();

            this.BindingLanguage();
            this.ShowDialog();
        }
        void Build()
        {
            
        }

        void FillData()
        {
            //Lay du lieu danh muc
            DataTable dtDanhMuc = SQLExec.ExecuteReturnDt("SELECT Object_ID, Object_Name FROM SYSOBJECT WHERE Object_ID LIKE 'LI%'AND Object_Type = 'DATA'");
            cboDanhMuc.DataSource = dtDanhMuc;
            cboDanhMuc.DisplayMember = "Object_Name";
            cboDanhMuc.ValueMember = "Object_ID";

            //Lay So du dau
            DataTable dtDuDau = SQLExec.ExecuteReturnDt("SELECT Object_ID, Object_Name FROM SYSOBJECT WHERE Object_ID LIKE '%DUDAU%'AND Object_Type = 'DATA'");
            cboDuDau.DataSource = dtDuDau;
            cboDuDau.DisplayMember = "Object_Name";
            cboDuDau.ValueMember = "Object_ID";

            DataTable dtNam = SQLExec.ExecuteReturnDt("SELECT DISTINCT Nam FROM SYSNAM");
            cboNam.DataSource = dtNam;
            cboNam.DisplayMember = "Nam";
            cboNam.ValueMember = "Nam";
        }
        
        void btOk_Click(object sender, EventArgs e)
        {
            string strSQL = string.Empty;
            string strTable_PH = string.Empty;
            string strTable_Ct = string.Empty;

            if (tabControl1.SelectedTab == tabPageDeleteVoucher)
            {
                if (txtMa_Ct.Text !="")
                {
                    string[] Dmct = txtMa_Ct.Text.Split(new char[] { ',' });                    
                    foreach (string strMa_Ct in Dmct)
                    {
                        //Lay ra ten Table can xoa du lieu
                        strTable_PH = (string)SQLExec.ExecuteReturnValue("SELECT Table_Ph FROM SYSDMCT WHERE Ma_Ct ='" + strMa_Ct + "'");
                        strTable_Ct = (string)SQLExec.ExecuteReturnValue("SELECT Table_Ct FROM SYSDMCT WHERE Ma_Ct ='" + strMa_Ct + "'");

                        //Thuc hien xoa du lieu
                        if (Common.MsgYes_No(Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có chắc chắn xóa không !" : Element.sysLanguage == enuLanguageType.English ? "Are you sure !" : "你確定 !") 
                                    && strTable_PH != "" && strTable_Ct != "")
                        {
                            strSQL = "DELETE FROM " + strTable_Ct + " WHERE Ma_Ct = '" + strMa_Ct + "' AND Ngay_Ct BETWEEN '" + Convert.ToDateTime(txtNgay_Ct1.Text).ToShortDateString() + "' AND '" +
                                            Convert.ToDateTime(txtNgay_Ct1.Text).ToShortDateString() + "' \r\n" + 
                                        " DELETE FROM " + strTable_PH + " WHERE Ma_Ct = '" + strMa_Ct + "' AND Ngay_Ct BETWEEN '" + Convert.ToDateTime(txtNgay_Ct1.Text).ToShortDateString() + "' AND '" +
                                            Convert.ToDateTime(txtNgay_Ct1.Text).ToShortDateString() + "'" ;

                            SQLExec.Execute(strSQL);
                            strSQL = string.Empty;
                        }
                    }                    
                }
            }

            if (tabControl1.SelectedTab == tabPageDeleteList)
            {
                if (Common.MsgYes_No(Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có chắc chắn xóa không !" : Element.sysLanguage == enuLanguageType.English ? "Are you sure !" : "你確定 !"))
                {
                    strSQL = "DELETE FROM " + cboDanhMuc.SelectedValue.ToString();
                    SQLExec.Execute(strSQL);
                    strSQL = string.Empty;
                }                
            }

            if (tabControl1.SelectedTab == tabPageDeleteDuDau)
            {
                if (Common.MsgYes_No(Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có chắc chắn xóa không !" : Element.sysLanguage == enuLanguageType.English ? "Are you sure !" : "你確定 !"))
                {
                    if (cboDuDau.SelectedValue.ToString() == "INDUDAU")
                    {
                        strSQL = "DELETE FROM " + cboDuDau.SelectedValue.ToString() + " WHERE YEAR(Ngay_Ct) = " + cboNam.SelectedValue.ToString() + " AND Ma_DvCs ='" + Element.sysMa_DvCs + "'";
                        SQLExec.Execute(strSQL);
                        strSQL = string.Empty;
                    }

                    if (cboDuDau.SelectedValue.ToString() == "GLDUDAU")
                    {
                        strSQL = "DELETE FROM " + cboDuDau.SelectedValue.ToString() + " WHERE Nam = " + cboNam.SelectedValue.ToString() + " AND Ma_DvCs ='" + Element.sysMa_DvCs + "'";
                        SQLExec.Execute(strSQL);
                        strSQL = string.Empty;
                    }

                    if (cboDuDau.SelectedValue.ToString() == "GLDUDAUXDCB")
                    {
                        strSQL = "DELETE FROM " + cboDuDau.SelectedValue.ToString() + " WHERE YEAR(Ngay_Ct) = " + cboNam.SelectedValue.ToString() + " AND Ma_DvCs ='" + Element.sysMa_DvCs + "'";
                        SQLExec.Execute(strSQL);
                        strSQL = string.Empty;
                    }

                    if (cboDuDau.SelectedValue.ToString() == "GLDUDAUHANTT")
                    {
                        strSQL = "DELETE FROM " + cboDuDau.SelectedValue.ToString() + " WHERE Nam = " + cboNam.SelectedValue.ToString() + " AND Ma_DvCs ='" + Element.sysMa_DvCs + "'";
                        SQLExec.Execute(strSQL);
                        strSQL = string.Empty;
                    }
                }                
            }

            if (tabControl1.SelectedTab == tabPageDeleteConditional)
            {
                if (rtbConditional.Text != "" && Common.MsgYes_No(Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có chắc chắn xóa không !" : Element.sysLanguage == enuLanguageType.English ? "Are you sure !" : "你確定 !"))
                {
                    strSQL = rtbConditional.Text;
                    SQLExec.Execute(strSQL);
                    strSQL = string.Empty;
                }
            }
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            //this.Close();
            Common.CloseCurrentForm();
        }
        
        void chkAll_Click(object sender, EventArgs e)
        {

        }

        void btMa_Ct_Click(object sender, EventArgs e)
        {
            string strValue = txtMa_Ct.Text.Trim();

            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Ct", "", true, "", "");
            if (drLookup == null)
                txtMa_Ct.Text = string.Empty;
            else
            {
                txtMa_Ct.Text = drLookup["MuiltiSelectValue"].ToString();
            }
        }
    }
}
