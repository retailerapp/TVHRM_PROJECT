using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;

namespace Epoint.Systems.Customizes
{
    public class frmModule : Epoint.Systems.Controls.frmBase
    {
        #region Fields

        #endregion

        #region Cai dat cac phuong thuc

        public frmModule()
        {
            InitializeComponent();

        }


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModule));
            this.SuspendLayout();
            // 
            // frmModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(909, 422);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmModule";
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
                        //Elements.Element.Is_FrmEditRunning = false;
                        //this.Close();
                        //return;		                    
                        if (this.FormBorderStyle == FormBorderStyle.None)
                        {
                            Common.CloseCurrentFormOnMain();
                        }
                        this.Close();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        //if (this.FormBorderStyle == FormBorderStyle.None)
                        //{
                        //    Common.CloseCurrentFormOnMain();
                        //}
                        //this.Close();
                    }
                    return;

            }

            base.OnKeyDown(e);
        }



        #endregion

    }
}
