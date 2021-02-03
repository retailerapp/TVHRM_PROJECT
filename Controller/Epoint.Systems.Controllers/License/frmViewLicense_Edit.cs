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
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;

namespace Epoint.Controllers
{
    public partial class frmViewLicense_Edit : Epoint.Systems.Customizes.frmEdit
    {

        object objFileContent;

        #region Phuong thuc
        public frmViewLicense_Edit()
        {
            InitializeComponent();

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }


        new public void Load(enuEdit enuNew_Edit,ref DataRow drEdit)
        {
            //this.drEdit = drEdit;
            //this.enuNew_Edit = enuNew_Edit;
            //this.Tag = (char)enuNew_Edit + ", " + this.Tag;

            //Common.ScaterMemvar(this, ref drEdit);

            //this.ShowDialog();
            base.drEdit = drEdit;
            base.enuNew_Edit = enuNew_Edit;
            base.Tag = ((char)((ushort)enuNew_Edit)) + ", " + base.Tag;
            Common.ScaterMemvar(this, ref drEdit);
            
            this.LoadDicName();
            base.ShowDialog();
        }



        private void LoadDicName()
        {
            
        }





        private bool FormCheckValid()
        {
            if (txtTen_Dvcs.Text.Trim() == string.Empty)
            {
                EpointMessage.MsgCancel("Tên file không đc rỗng");
                return false;
            }

            return true;
        }

        private bool Save()
        {
            Common.GatherMemvar(this, ref this.drEdit);
            if (!this.FormCheckValid())
            {
                return false;
            }
            if (!DataTool.SQLUpdate(base.enuNew_Edit, "SYSLICS", ref this.drEdit))
            {
                return false;
            }
            return true;

        }
    

        #endregion

        #region Su kien



        void btAccept_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                isAccept = true;
                this.Close();
            }
        }
        void btCancel_Click(object sender, EventArgs e)
        {
            isAccept = false;
            this.Close();
        }
        #endregion


    }
}