using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Epoint.Systems.Controls;
using Epoint.Systems.Resources;
using Epoint.Systems.Librarys;
using Epoint.Systems.Commons;

namespace Epoint.Systems.Customizes
{
    public class toolStripEdit : Epoint.Systems.Controls.tsControl
    {
        public tsbNew tsbNew = new tsbNew();
        public tsbEdit tsbEdit = new tsbEdit();
        public tsbDelete tsbDelete = new tsbDelete();

        public toolStripEdit()
        {
            this.Items.Add(tsbNew);
            this.Items.Add(tsbEdit);
            this.Items.Add(tsbDelete);
            this.Items.Add(new ToolStripSeparator());
        }
    }

    public class tsbNew : tsbControl
    {
        public tsbNew()
        {
            Bitmap Bmp = new Bitmap(Resources.Resource.Add, this.Size);

            this.Image = Bmp;
            this.ToolTipText = Languages.GetLanguage("Add_New");
            this.Text = Languages.GetLanguage("Add_New");
            this.Click += new EventHandler(tsbNew_Click);
        }

        void tsbNew_Click(object sender, EventArgs e)
        {
            Form frm = this.Parent.FindForm().GetType().Name == "frmMain" ? this.Parent.FindForm().ActiveMdiChild : this.Parent.FindForm();

            if (frm == null)
                frm = Common.FindFormChildInTab();

            if (frm == null)
                return;

            ((frmView)frm).Edit(enuEdit.New);
        }
    }

    public class tsbEdit : tsbControl
    {
        public tsbEdit()
        {
            Bitmap Bmp = new Bitmap(Resources.Resource.EditCt, this.Size);

            this.Image = Bmp;
            this.ToolTipText = Languages.GetLanguage("Edit");
            this.Text = Languages.GetLanguage("Edit");
            this.Click += new EventHandler(tsbEdit_Click);
        }

        void tsbEdit_Click(object sender, EventArgs e)
        {
            Form frm = this.Parent.FindForm().GetType().Name == "frmMain" ? this.Parent.FindForm().ActiveMdiChild : this.Parent.FindForm();
            if (frm == null)
                frm = Common.FindFormChildInTab();
            if (frm == null)
                return;

            ((frmView)frm).Edit(enuEdit.Edit);
        }
    }

    public class tsbDelete : tsbControl
    {
        public tsbDelete()
        {
            Bitmap Bmp = new Bitmap(Resources.Resource.delete, this.Size);

            this.Image = Bmp;
            this.ToolTipText = Languages.GetLanguage("Delete");
            this.Text = Languages.GetLanguage("Delete");
            this.Click += new EventHandler(tsbDelete_Click);
        }

        void tsbDelete_Click(object sender, EventArgs e)
        {
            Form frm = this.Parent.FindForm().GetType().Name == "frmMain" ? this.Parent.FindForm().ActiveMdiChild : this.Parent.FindForm();
            if (frm == null)
                frm = Common.FindFormChildInTab();
            if (frm == null)
                return;

            ((frmView)frm).Delete();
        }
    }
}
