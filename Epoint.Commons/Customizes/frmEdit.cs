using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using Epoint.Systems.Controls;

namespace Epoint.Systems.Customizes
{
    public class frmEdit : Epoint.Systems.Controls.frmBase
    {
        #region Bien

        public bool isAccept = false;
        public enuEdit enuNew_Edit = enuEdit.New;
        public dicControl dicName = new dicControl();
        public DataRow drEdit;

        #endregion

        #region Phuong thuc

        public frmEdit()
        {
            InitializeComponent();
            this.BindingLanguage();
            Commons.Common.InitSystemCulture();
            //this.ResetTextChange(this);
            
        }

        void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEdit));
            this.SuspendLayout();
            // 
            // frmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(517, 297);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEdit";
            this.ResumeLayout(false);

        }

        public void LoadEditName()
        {
            foreach (Control ctrl in Controls)
            {
                if (!ctrl.Name.StartsWith("lbt"))
                    continue;

                Control ctrlCode = this.Controls.Find(ctrl.Tag.ToString().Trim(), false)[0];

                // Ô nhập mã rỗng
                if (ctrlCode.Text.Trim() == string.Empty)
                    continue;

                string strName = ctrl.Name.Substring(3);
                string strCode = ctrlCode.Name.Substring(3);
                string strCodeValue = ctrlCode.Text.Trim();

            }
        }

        #endregion

        #region Su kien

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                foreach (Control control in base.Controls)
                {
                    if ((control.GetType().Name.ToUpper() == "AUTOFILTER") && control.Visible)
                    {
                        control.Visible = false;
                        return;
                    }
                }
                this.isAccept = false;
                base.Close();
            }
            else
            {
                base.OnKeyDown(e);
            }


            //switch (e.KeyCode)
            //{
            //    case Keys.Escape:
            //        isAccept = false;
            //        this.Close();
            //        //Commons.EpointMethod.CloseCurrentForm();
            //        return;
            //}

            //base.OnKeyDown(e);
        }
        
        
        public void ResetTextChange(Control ctr)
        {

            if (ctr.GetType() == typeof(txtTextBox))
            {
                txtTextBox t = (txtTextBox)ctr;
                t.bTextChange = false;
            }
            if (ctr.GetType() == typeof(txtTextLookup))
            {
                txtTextLookup t = (txtTextLookup)ctr;
                t.bTextChange = false;
            }
            foreach (Control ctrl in ctr.Controls)
            {
                ResetTextChange(ctrl);
            }         

        }
        private void SetBorderTextBox(Control ctr, PaintEventArgs e)
        {
            Color cl = Commons.Common.GetColorBoder();
            foreach (Control ctrl in ctr.Controls)
            {
                if (ctrl.HasChildren)
                {
                    foreach (Control ctrChild in ctrl.Controls)
                    {
                        SetBorderTextBox(ctrChild, e);
                    }
                }
                if (ctrl.GetType() == typeof(txtTextBox))
                {

                    //ctrl.Location.
                    txtTextBox t = (txtTextBox)ctrl;
                    if (t.bRequire)
                    {
                        Graphics g = e.Graphics;
                        Rectangle newRect = new Rectangle(ctrl.Location.X - 1, ctrl.Location.Y - 1,
                             ctrl.Width + 1, ctrl.Height + 1);
                        g.DrawRectangle(new Pen(cl, 1), newRect);
                    }
                }
                else if (ctrl.GetType() == typeof(txtDateTime))
                {

                    //ctrl.Location.
                    txtDateTime t = (txtDateTime)ctrl;
                    if (t.bRequire)
                    {
                        Graphics g = e.Graphics;
                        Rectangle newRect = new Rectangle(ctrl.Location.X - 1, ctrl.Location.Y - 1,
                             ctrl.Width + 1, ctrl.Height + 1);
                        g.DrawRectangle(new Pen(cl, 1), newRect);
                    }
                }

            }
        }
        #endregion

    }
}
