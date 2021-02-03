using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Epoint.Systems.Elements;
using Epoint.Systems.Customizes;
using Epoint.Systems.Data;
using Epoint.Systems.Commons;
using Epoint.Systems.Librarys;
using Epoint.Lists;
using System.Collections;

namespace Epoint.Controllers
{
    public partial class frmUpdateKey : Epoint.Systems.Customizes.frmView
    {
        string strMa_Ct;
        public frmUpdateKey()
        {
            InitializeComponent();

            btOk.Click += new EventHandler(btOk_Click);
            btCancel.Click += new EventHandler(btCancel_Click);
            btFile.Click += new EventHandler(btFile_Click);
        }

        new public void Load()
        {
            this.BindingLanguage();
            this.Show();
        }

        void btOk_Click(object sender, EventArgs e)
        {
            if (txtFile_Name.Text == string.Empty)
                return;
            if (!File.Exists(txtFile_Name.Text))
                EpointMessage.MsgOk(Epoint.Systems.Librarys.Languages.GetLanguage("NotValid_Key", Element.sysLanguage));
            if (EpointMethod.EpointUpdateKey(txtFile_Name.Text))
                EpointMessage.MsgOk(Epoint.Systems.Librarys.Languages.GetLanguage("Valid_Key", Element.sysLanguage));
            else
                EpointMessage.MsgOk(Epoint.Systems.Librarys.Languages.GetLanguage("NotValid_Key", Element.sysLanguage));
                
            Common.CloseCurrentForm();
            Application.Restart();
        }
        void btFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xls files (*.key)|*.key";
            ofd.RestoreDirectory = true;

            ofd.InitialDirectory = System.Windows.Forms.Application.StartupPath;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFile_Name.Text = ofd.FileName;

            }
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            Common.CloseCurrentForm();
        }
    }
}
