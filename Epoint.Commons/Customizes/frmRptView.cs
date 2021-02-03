using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;

namespace Epoint.Systems.Customizes
{
    public class frmRptView : Epoint.Systems.Controls.frmBase
    {
        #region Fields

        #endregion

        #region Cai dat cac phuong thuc

        public frmRptView()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptView));
            this.SuspendLayout();
            // 
            // frmRptView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptView";
            this.ResumeLayout(false);

        }



        #endregion

        #region Xu ly su kien

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    try
                    {
                       this.Close();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        
                        //this.Close();
                    }
                    return;

            }

           
        }



        #endregion

    }
}
