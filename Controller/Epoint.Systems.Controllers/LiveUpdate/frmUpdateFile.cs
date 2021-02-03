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
    public partial class frmUpdateFile : Epoint.Systems.Customizes.frmView
    {
        string strMa_Ct;
        public frmUpdateFile()
        {
            InitializeComponent();

            btOk.Click += new EventHandler(btOk_Click);
            btCancel.Click += new EventHandler(btCancel_Click);            
        }

        new public void Load()
        {
            if (Element.sysLanguage == Systems.enuLanguageType.Vietnamese)
            {
                lblDongY.Text = "Nhấn 'Đồng ý' để tiếp tục cập nhật phiên bản mới nhất. Quá trình cập nhật sẽ mất vài phút !";
                lblHuyBo.Text = "Nhấn 'Hủy bỏ' để ngưng quá trình cập nhật !";
            }
            if (Element.sysLanguage == Systems.enuLanguageType.English)
            {
                lblDongY.Text = "Click 'Accept' to continue to update the latest version. The update process will take a few minutes !";
                lblHuyBo.Text = "Click 'Cancel' to stop the update process !";
            }
            if (Element.sysLanguage == Systems.enuLanguageType.Other)
            {
                lblDongY.Text = "點擊“接受”，以不斷更新的最新版本。更新過程SE VAI分鐘！";
                lblHuyBo.Text = "點擊“取消”停止更新過程！";
            }

            this.BindingLanguage();
            this.Show();
        }

        void btOk_Click(object sender, EventArgs e)
        {
            //Load form update
            string strFilePath = Application.StartupPath + @"\\LiveUpdate.exe";
            if (System.IO.File.Exists(strFilePath))
                System.Diagnostics.Process.Start(strFilePath);

            //Exit
            Common.CloseCurrentForm();
            Application.Exit();
        }
        
        void btCancel_Click(object sender, EventArgs e)
        {
            Common.CloseCurrentForm();
        }

        private void frmUpdateFile_Load(object sender, EventArgs e)
        {

        }
    }
}
