using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems;
using Epoint.Systems.Controls;
using Epoint.Systems.Librarys;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;

namespace Epoint.Controllers
{
	public partial class frmLicense : Epoint.Systems.Customizes.frmEdit
	{
        #region Phuong thuc

        public frmLicense()
		{
			InitializeComponent();

			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			BindingLanguage();
			this.ShowDialog();
		}		

		

		
        #endregion

        #region Su kien

		void btAccept_Click(object sender, EventArgs e)
		{
			
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "key files (*.key)|*.key";
            ofd.RestoreDirectory = true;

            ofd.InitialDirectory = System.Windows.Forms.Application.StartupPath;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofd.FileName;

            }
        }
        #endregion 		
	}
}