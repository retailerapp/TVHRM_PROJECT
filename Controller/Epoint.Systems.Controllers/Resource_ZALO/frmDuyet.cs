using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;

using Epoint.Systems;
using System.Windows.Forms;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Elements;

namespace Epoint.Controllers
{
	public partial class frmDuyet : Epoint.Systems.Customizes.frmEdit
	{
		public frmDuyet()
		{
			InitializeComponent();

            //this.tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);

			this.chkDuyet.CheckedChanged += new EventHandler(chkDuyet_CheckedChanged);

			this.btSave.Click += new EventHandler(btSave_Click);			
		}

		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;

			Common.ScaterMemvar(this, ref drEdit);
            if (chkDuyet.Checked)
            {

                chkDuyet.Enabled = false;
                dteNgay_Ky.Enabled = false;
                //Hien thi thong tin nguoi duyet
                txtDuyet_Log.Text = drEdit["Nguoi_Ky"].ToString();

                btSave.Enabled = false;
            }
			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			if (dteNgay_Ky.IsNull)
			{
				Common.MsgCancel(Languages.GetLanguage("Ngay_Ct,Not_Null"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			string strSQLExec = string.Empty;
			Hashtable htPara;

			//Lưu phần Checked vào GLVOUCHER
			if (chkDuyet.Enabled)
			{
				htPara = new Hashtable();
				htPara.Add("DUYET", chkDuyet.Checked);
                htPara.Add("NGAY_KY", dteNgay_Ky.Text);
				htPara.Add("DUYET_LOG", txtDuyet_Log.Text);
                htPara.Add("IDENT00", drEdit["Ident00"]);

                strSQLExec = "UPDATE ZALORESOURCES SET Duyet = @Duyet, Nguoi_Ky = @Duyet_Log,Ngay_Ky = @Ngay_Ky  WHERE Ident00 = @Ident00";
                                
				if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
				{
					drEdit["Duyet"] = chkDuyet.Checked;
					drEdit["Nguoi_Ky"] = txtDuyet_Log.Text;
				}

                //Sync Data                
               
			}

			return true;
		}

		void chkDuyet_CheckedChanged(object sender, EventArgs e)
		{
			if (chkDuyet.Checked)
				this.txtDuyet_Log.Text = Common.GetCurrent_Log();
			else
				this.txtDuyet_Log.Text = string.Empty;

            dteNgay_Ky.Text = Library.DateToStr(DateTime.Now);
			this.btSave.Enabled = true;
		}

		void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Common.ScaterMemvar(this, ref drEdit);

			btSave.Enabled = false;
		}

		void btSave_Click(object sender, EventArgs e)
		{
			if (this.FormCheckValid())
			{
				this.Save();
                this.isAccept = true;
				this.Close();
			}
		}		
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

            //if (!Element.sysIs_Admin)
            //{
            //    if (!Common.CheckPermission("DUYET", Epoint.Systems.enuPermission_Type.Allow_Access))
            //        tabControl1.TabPages.Remove(tabPage3);
            //}

            //Unlock duyet chung tu
            //if (!Element.sysIs_Admin)
            //{
            //    if (Common.CheckPermission("DUYET_UNLOCK", Epoint.Systems.enuPermission_Type.Allow_Access))
            //        chkDuyet.Enabled = true;
            //}

            ////Neu la Admin thi duoc Duyet Unlock
            //if (Element.sysIs_Admin)
            //    chkDuyet.Enabled = true;
            
           
        }
	}
}
