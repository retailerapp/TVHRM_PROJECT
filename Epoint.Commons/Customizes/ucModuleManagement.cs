using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using Epoint.Systems.Controls;
using Epoint.Systems.Elements;
using Epoint.Systems.Commons;
using Epoint.Systems.Data;

namespace Epoint.Systems.Customizes
{
    public partial class UcModuleManagement : UserControl
    {
        public int iOrgHeight = 0;
        Point orgP = new Point(0, 0);
        Timer tm = new Timer();
        public System.Windows.Forms.ListView lvOpeningModule = new ListView();

        #region Contructor

        public UcModuleManagement()
        {
            InitializeComponent();

            this.SetColor();

            this.lvOpeningModule.DoubleClick += new EventHandler(lvOpeningModule_DoubleClick);
            this.lvOpeningModule.KeyDown += new KeyEventHandler(lvOpeningModule_KeyDown);

            this.btHide.Click += new EventHandler(btHide_Click);

            this.Load();
            orgP = new Point(this.Location.X, this.Location.Y);
            tm.Interval = 1000;
            tm.Start();
            tm.Tick += new EventHandler(tm_Tick);
        }

        void tm_Tick(object sender, EventArgs e)
        {
           if (Element.Reminder_count > 0)
            {

                if (lblTitle.ForeColor == Color.White)
                    lblTitle.ForeColor = Color.Red;
                else
                    lblTitle.ForeColor = Color.White;
            }
           
            
        }

        public new void Load()
        {
            //this.lvReminder.Size = this.lvOpeningModule.Size;
            //this.lvReminder.Location = this.lvOpeningModule.Location;
            this.iOrgHeight = this.Height;
            this.Height = this.Height - this.lvReminder.Height;
            this.lvReminder.Visible = false;
            this.lvOpeningModule.Visible = false;
        }

        #endregion

        #region Methods

        public void SetModuleCount()
        {
            //this.btOpeningModule.Text = Librarys.Languages.GetLanguage((string)this.btOpeningModule.Tag) + " (" + this.lvOpeningModule.Items.Count.ToString() + ")";
        }

        public void SetColor()
        {
            this.btHide.BackColor = Color.FromArgb(0, 255, 255, 255);
            this.lvReminder.BackColor = Color.FromArgb(255, 216, 228, 248);

            if (lvReminder.Visible)
            {
                this.BackColor = Color.FromArgb(255, 157, 185, 235);
                //this.panel1.BackColor = this.BackColor;
            }
            else
            {
                this.BackColor = System.Drawing.Color.Transparent;
                //this.panel1.BackColor = System.Drawing.Color.Transparent;
            }
        }

        public void AddMenuItem(tsmiControl tsmi)
        {
            lviOpeningModule lvi = new lviOpeningModule();

            lvi.Name = tsmi.Name;
            lvi.Tag = tsmi.Tag;
            lvi.Text = tsmi.Text.Replace("&", "");
            lvi.tsmi = tsmi;
            lvi.ImageKey = "Bullet";

            this.lvOpeningModule.Items.Add(lvi);

            this.SetModuleCount();
        }

        public void RemoveMenuItem(tsmiControl tsmi)
        {
            foreach (ListViewItem lvi in this.lvOpeningModule.Items)
            {
                if (lvi.Name == tsmi.Name)
                {
                    this.lvOpeningModule.Items.Remove(lvi);
                }
            }

            this.SetModuleCount();
        }

        private void ActiveModule()
        {
            if (this.lvOpeningModule.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvOpeningModule.SelectedItems[0];

                if (lvi.GetType().Name == "lviOpeningModule")
                {
                    Form frm = ((lviOpeningModule)lvi).tsmi.frmInstance;

                    if (frm != null)
                    {
                        Elements.Element.frmActiveMain = frm;
                    }
                }
            }
            
            
        }

        #endregion

        #region Events

        void btHide_Click(object sender, EventArgs e)
        {
            if (this.lvReminder.Visible)
            {
                //this.Location = orgP;
                //this.orgP = new Point(this.Location.X, this.Location.Y);
                this.iOrgHeight = this.Height;
                this.Height = panel1.Height - lvReminder.Height;
                this.lvReminder.Visible = false;

                this.btHide.ImageKey = "play";
                //this.Location = new Point(this.Location.X, this.Location.Y + this.iOrgHeight - this.Height);
            }
            else
            {
                //this.orgP = new Point(this.Location.X, this.Location.Y);
                this.Height = this.iOrgHeight + this.lvReminder.Height ;
                //this.Location = orgP;
                this.lvReminder.Visible = true;

                this.btHide.ImageKey = "stop";
                //this.Location = new Point(this.Location.X, 0);
            }
            this.SetColor();
        }

        void lvOpeningModule_DoubleClick(object sender, EventArgs e)
        {
            this.ActiveModule();
        }

        void lvOpeningModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ActiveModule();
        }

        #endregion
    }

    public class lviOpeningModule : ListViewItem
    {
        public tsmiControl tsmi = null;
    }
}
